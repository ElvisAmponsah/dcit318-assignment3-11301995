using System;
using System.Collections.Generic;
using System.Linq;

public class Repository<T>
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public List<T> GetAll()
    {
        return items;
    }

    public T? GetById(Func<T, bool> predicate)
    {
        return items.FirstOrDefault(predicate);
    }

    public bool Remove(Func<T, bool> predicate)
    {
        var item = items.FirstOrDefault(predicate);
        if (item != null)
        {
            items.Remove(item);
            return true;
        }
        return false;
    }

    public bool Update(Func<T, bool> predicate, T updatedItem)
    {
        var item = items.FirstOrDefault(predicate);
        if (item != null)
        {
            items.Remove(item);
            items.Add(updatedItem);
            return true;
        }
        return false;
    }

    public List<T> FindAll(Func<T, bool> predicate)
    {
        return items.Where(predicate).ToList();
    }

    public int Count()
    {
        return items.Count;
    }

    public bool Exists(Func<T, bool> predicate)
    {
        return items.Any(predicate);
    }
}

public class Patient
{
    public int Id { get; }
    public string Name { get; }
    public int Age { get; }
    public string Gender { get; }

    public Patient(int id, string name, int age, string gender)
    {
        Id = id;
        Name = name;
        Age = age;
        Gender = gender;
    }

    public override string ToString()
    {
        return $"Patient(Id: {Id}, Name: {Name}, Age: {Age}, Gender: {Gender})";
    }
}

public class Prescription
{
    public int Id { get; }
    public int PatientId { get; }
    public string MedicationName { get; }
    public DateTime DateIssued { get; }

    public Prescription(int id, int patientId, string medicationName, DateTime dateIssued)
    {
        Id = id;
        PatientId = patientId;
        MedicationName = medicationName;
        DateIssued = dateIssued;
    }

    public override string ToString()
    {
        return $"Prescription(Id: {Id}, PatientId: {PatientId}, Medication: {MedicationName}, Date: {DateIssued:yyyy-MM-dd})";
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("=== Patient Management System ===\n");

        // Create repositories
        var patientRepo = new Repository<Patient>();
        var prescriptionRepo = new Repository<Prescription>();

        // Add sample patients
        Console.WriteLine("Adding patients...");
        patientRepo.Add(new Patient(1, "John Doe", 35, "Male"));
        patientRepo.Add(new Patient(2, "Jane Smith", 28, "Female"));
        patientRepo.Add(new Patient(3, "Mike Johnson", 42, "Male"));
        patientRepo.Add(new Patient(4, "Sarah Wilson", 31, "Female"));
        patientRepo.Add(new Patient(5, "David Brown", 55, "Male"));

        // Add sample prescriptions
        Console.WriteLine("Adding prescriptions...");
        prescriptionRepo.Add(new Prescription(101, 1, "Amoxicillin", DateTime.Now.AddDays(-5)));
        prescriptionRepo.Add(new Prescription(102, 1, "Ibuprofen", DateTime.Now.AddDays(-3)));
        prescriptionRepo.Add(new Prescription(103, 2, "Paracetamol", DateTime.Now.AddDays(-2)));
        prescriptionRepo.Add(new Prescription(104, 3, "Aspirin", DateTime.Now.AddDays(-1)));
        prescriptionRepo.Add(new Prescription(105, 4, "Antibiotic", DateTime.Now));
        prescriptionRepo.Add(new Prescription(106, 5, "Blood Pressure Medication", DateTime.Now.AddDays(-7)));

        // Display all patients
        Console.WriteLine("\n=== All Patients ===");
        var allPatients = patientRepo.GetAll();
        foreach (var patient in allPatients)
        {
            Console.WriteLine(patient);
        }

        // Display all prescriptions
        Console.WriteLine("\n=== All Prescriptions ===");
        var allPrescriptions = prescriptionRepo.GetAll();
        foreach (var prescription in allPrescriptions)
        {
            Console.WriteLine(prescription);
        }

        // Find patient by ID
        Console.WriteLine("\n=== Finding Patient by ID ===");
        var foundPatient = patientRepo.GetById(p => p.Id == 2);
        if (foundPatient != null)
        {
            Console.WriteLine($"Found: {foundPatient}");
        }

        // Find prescriptions for a specific patient
        Console.WriteLine("\n=== Prescriptions for Patient ID 1 ===");
        var patientPrescriptions = prescriptionRepo.FindAll(p => p.PatientId == 1);
        foreach (var prescription in patientPrescriptions)
        {
            Console.WriteLine(prescription);
        }

        // Find patients by age range
        Console.WriteLine("\n=== Patients aged 30-40 ===");
        var ageRangePatients = patientRepo.FindAll(p => p.Age >= 30 && p.Age <= 40);
        foreach (var patient in ageRangePatients)
        {
            Console.WriteLine(patient);
        }

        // Find prescriptions by medication
        Console.WriteLine("\n=== Prescriptions containing 'Anti' ===");
        var antiPrescriptions = prescriptionRepo.FindAll(p => p.MedicationName.Contains("Anti"));
        foreach (var prescription in antiPrescriptions)
        {
            Console.WriteLine(prescription);
        }

        // Count statistics
        Console.WriteLine("\n=== Statistics ===");
        Console.WriteLine($"Total Patients: {patientRepo.Count()}");
        Console.WriteLine($"Total Prescriptions: {prescriptionRepo.Count()}");
        Console.WriteLine($"Male Patients: {patientRepo.FindAll(p => p.Gender == "Male").Count}");
        Console.WriteLine($"Female Patients: {patientRepo.FindAll(p => p.Gender == "Female").Count}");

        // Check if patient exists
        Console.WriteLine("\n=== Existence Checks ===");
        bool hasPatient = patientRepo.Exists(p => p.Name == "John Doe");
        Console.WriteLine($"Patient 'John Doe' exists: {hasPatient}");

        bool hasPrescription = prescriptionRepo.Exists(p => p.MedicationName == "Aspirin");
        Console.WriteLine($"Prescription for 'Aspirin' exists: {hasPrescription}");

        // Remove a prescription
        Console.WriteLine("\n=== Removing Prescription ===");
        bool removed = prescriptionRepo.Remove(p => p.Id == 102);
        Console.WriteLine($"Prescription 102 removed: {removed}");

        // Display prescriptions after removal
        Console.WriteLine("\n=== Prescriptions after removal ===");
        var remainingPrescriptions = prescriptionRepo.GetAll();
        foreach (var prescription in remainingPrescriptions)
        {
            Console.WriteLine(prescription);
        }

        Console.WriteLine("\n=== Patient Management System Demo Complete ===");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
