namespace Discipline_Management_System;

public class Discipline
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Lecturer { get; set; }

    public Discipline(int id, string title, string description, string lecturer)
    {
        Id = id;
        Title = title;
        Description = description;
        Lecturer = lecturer;
    }

    public static Discipline AddDiscipline(int id, string title, string description, string lecturer)
    {
        return new Discipline(id, title, description, lecturer);
    }

    public static void UpdateDiscipline(int id, string title, string description, string lecturer)
    {
        Global.Disciplines[id].Title = title;
        Global.Disciplines[id].Description = description;
        Global.Disciplines[id].Lecturer = lecturer;
    }
    
    public void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Название: {Title}");
        Console.WriteLine($"Описание: {Description}");
        Console.WriteLine($"Преподаватель: {Lecturer}");
        Console.WriteLine(new string('-', 50));
    }
}