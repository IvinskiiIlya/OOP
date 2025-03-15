namespace Discipline_Management_System;

public class Course
{
    public int Id { get; set; }
    public int CourseNumber { get; set; }
    public List<string> Subjects { get; set; }

    public Course(int id, int courseNumber)
    {
        Id = id;
        CourseNumber = courseNumber;
        Subjects = new List<string>();
    }

    public static Course AddCourse(int id, int courseNumber, List<string> subjects)
    {
        var course = new Course(id, courseNumber)
        {
            Subjects = subjects
        };
        return course;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Номер курса: {CourseNumber}");
        Console.WriteLine("Дисциплины:");
        foreach (var subject in Subjects)
        {
            Console.WriteLine($" - {subject}");
        }
        Console.WriteLine(new string('-', 50));
    }
}