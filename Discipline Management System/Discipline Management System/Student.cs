namespace Discipline_Management_System;

public class Student : Person
{
    public int GroupNumber { get; set; }
    public int Course { get; set; }
    
    public Student(int id, string surname, string name, string patronymic, int age, int groupNumber, int course) 
        : base(id, surname, name, patronymic, age)
    {
        Id = id;
        GroupNumber = groupNumber;
        Course = course;
    }
    
    public static Student AddStudent(int id, string surname, string name, string patronymic, int age, int groupNumber, int course)
    {
        var student = new Student(id, surname, name, patronymic, age, groupNumber, course)
        {
            GroupNumber = groupNumber,
            Course = course
        };
        return student;
    }
    
    public void UpdateStudent(string surname, string name, string patronymic, int groupNumber, int course)
    {
        Surname = surname;
        Name = name;
        Patronymic = patronymic;
        Age = Age;
        GroupNumber = groupNumber;
        Course = course;
    }
    
    public void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"ФИО: {Surname} {Name} {Patronymic}, возраст: {Age}");
        Console.WriteLine($"Курс обучения: {Course}");
        Console.WriteLine($"Группа студента: {GroupNumber}");
        Console.WriteLine(new string('-', 50));
    }
}