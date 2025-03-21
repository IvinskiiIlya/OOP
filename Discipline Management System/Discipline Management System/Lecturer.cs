namespace Discipline_Management_System;

public class Lecturer : Person
{
    public string AcademicTitle { get; set; }
    public List<string> Subjects { get; set; }
    public List<int> SubjectsId { get; set; }
    
    public Lecturer(int id, string surname, string name, string patronymic, int age) 
        : base(id, surname, name, patronymic, age)
    {
        Subjects = new List<string>();
        SubjectsId = new List<int>();
    }
    
    public static Lecturer AddLecturer(int id, string surname, string name, string patronymic, int age, string academicTitle, List<string> subjects, List<int> diciplineId)
    {
        var lecturer = new Lecturer(id, surname, name, patronymic, age)
        {
            AcademicTitle = academicTitle,
            Subjects = subjects,
            SubjectsId = diciplineId
        };
        return lecturer;
    }

    public static void UpdateLecturer(int id, string surname, string name, string patronymic, int age, string academicTitle, List<string> subjects, List<int> SubjectsId)
    {
        Global.Lecturers[id].Surname = surname;
        Global.Lecturers[id].Name = name;
        Global.Lecturers[id].Patronymic = patronymic;
        Global.Lecturers[id].Age = age;
        Global.Lecturers[id].AcademicTitle = academicTitle;
        Global.Lecturers[id].Subjects = subjects;
        Global.Lecturers[id].SubjectsId = SubjectsId;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"ФИО: {Surname} {Name} {Patronymic}, возраст: {Age}");
        Console.WriteLine($"Ученое звание: {AcademicTitle}");
        Console.WriteLine($"ID дисциплин: {string.Join(", ", SubjectsId)}");
        Console.WriteLine($"Преподаваемые дисциплины: {string.Join(", ", Subjects)}");
        Console.WriteLine(new string('-', 50));
    }
}