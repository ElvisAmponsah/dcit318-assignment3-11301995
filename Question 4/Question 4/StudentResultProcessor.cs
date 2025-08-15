using System;
using System.Collections.Generic;
using System.IO;

// ---------------------------
// StudentResultProcessor Class
// ---------------------------
public class StudentResultProcessor
{
    public List<Student> ReadStudentsFromFile(string inputFilePath)
    {
        List<Student> students = new List<Student>();

        using (StreamReader reader = new StreamReader(inputFilePath))
        {
            string? line;
            int lineNumber = 0;

            while ((line = reader.ReadLine()) != null)
            {
                lineNumber++;
                string[] parts = line.Split(',');

                if (parts.Length != 3)
                    throw new MissingFieldException($"Line {lineNumber}: Expected 3 fields, found {parts.Length}.");

                if (!int.TryParse(parts[0].Trim(), out int id))
                    throw new InvalidScoreFormatException($"Line {lineNumber}: Invalid ID format.");

                string fullName = parts[1].Trim();

                if (!int.TryParse(parts[2].Trim(), out int score))
                    throw new InvalidScoreFormatException($"Line {lineNumber}: Score '{parts[2].Trim()}' is not a valid integer.");

                students.Add(new Student(id, fullName, score));
            }
        }

        return students;
    }

    public void WriteReportToFile(List<Student> students, string outputFilePath)
    {
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            foreach (var student in students)
            {
                writer.WriteLine(student.ToString());
            }
        }
    }
}
