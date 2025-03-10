namespace Discipline_Management_System;

public class Course
{
    public int Id { get; set; }
    public string CourseNumber { get; set; }
    public List<string> Subjects { get; set; }

    public Course(int id, string courseNumber)
    {
        Id = id;
        CourseNumber = courseNumber;
        Subjects = new List<string>();
    }

    public void AddSubject(string subject)
    {
        Subjects.Add(subject);
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Курс ID: {Id}");
        Console.WriteLine($"Номер курса: {CourseNumber}");
        Console.WriteLine("Дисциплины:");
        foreach (var subject in Subjects)
        {
            Console.WriteLine($" - {subject}");
        }
    }
}