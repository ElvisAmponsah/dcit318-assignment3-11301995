using System;

// ---------------------------
// Student Class
// ---------------------------
public class Student
{
    public int Id { get; }
    public string FullName { get; }
    public int Score { get; }

    public Student(int id, string fullName, int score)
    {
        Id = id;
        FullName = fullName;
        Score = score;
    }

    public string GetGrade()
    {
        if (Score >= 80 && Score <= 100) return "A";
        if (Score >= 70 && Score <= 79) return "B";
        if (Score >= 60 && Score <= 69) return "C";
        if (Score >= 50 && Score <= 59) return "D";
        return "F";
    }

    public override string ToString()
    {
        return $"{FullName} (ID: {Id}): Score = {Score}, Grade = {GetGrade()}";
    }
}
