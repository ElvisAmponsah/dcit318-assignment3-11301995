using System;
using System.Collections.Generic;
using System.IO;

// ---------------------------
// Main Program
// ---------------------------
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Student Result Processing System ===\n");
        
        string inputFile = "students.txt"; // Input file path
        string outputFile = "student_report.txt"; // Output file path

        StudentResultProcessor processor = new StudentResultProcessor();

        try
        {
            Console.WriteLine($"Reading student data from '{inputFile}'...");
            List<Student> students = processor.ReadStudentsFromFile(inputFile);
            
            Console.WriteLine($"Found {students.Count} students in the file.");
            
            // Display all students
            Console.WriteLine("\n=== Student Results ===");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
            
            Console.WriteLine($"\nWriting report to '{outputFile}'...");
            processor.WriteReportToFile(students, outputFile);
            
            Console.WriteLine("✅ Report generated successfully!");
            Console.WriteLine($"📁 Output saved to: {outputFile}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"❌ Error: Input file '{inputFile}' not found.");
            Console.WriteLine("Please create a 'students.txt' file with the following format:");
            Console.WriteLine("1,John Doe,85");
            Console.WriteLine("2,Jane Smith,92");
            Console.WriteLine("3,Mike Johnson,78");
        }
        catch (InvalidScoreFormatException ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
        catch (MissingFieldException ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Unexpected error: {ex.Message}");
        }

        Console.WriteLine("\n=== Student Result Processing Complete ===");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
