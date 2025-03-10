namespace Discipline_Management_System;

public class Lecturer : Person
{
    public string AcademicTitle { get; set; }
    public List<string> Subjects { get; set; }
    
    public Lecturer(int id, string surname, string name, string patronymic, int age) : base(id, surname, name, patronymic, age)
    {
        Subjects = new List<string>();
    }
    
    public static Lecturer AddLecturer(int id, string surname, string name, string patronymic, int age, string academicTitle, List<string> subjects)
    {
        var lecturer = new Lecturer(id, surname, name, patronymic, age)
        {
            AcademicTitle = academicTitle,
            Subjects = subjects
        };
        return lecturer;
    }

    public void UpdateLecturer(string surname, string name, string patronymic, string academicTitle, List<string> subjects)
    {
        Surname = surname;
        Name = name;
        Patronymic = patronymic;
        AcademicTitle = academicTitle;
        Subjects = subjects;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"ФИО: {Surname} {Name} {Patronymic}, возраст: {Age}");
        Console.WriteLine($"Ученое звание: {AcademicTitle}");
        Console.WriteLine($"Преподаваемые дисциплины: {string.Join(", ", Subjects)}");
        Console.WriteLine();
    }
}