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
    
    public static void UpdateStudent(int id, string surname, string name, string patronymic, int age, int groupNumber, int course)
    {
        Global.Students[id].Surname = surname;
        Global.Students[id].Name = name;
        Global.Students[id].Patronymic = patronymic;
        Global.Students[id].Age = age;
        Global.Students[id].GroupNumber = groupNumber;
        Global.Students[id].Course = course;
    }
    
    public void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"ФИО: {Surname} {Name} {Patronymic}, возраст: {Age}");
        Console.WriteLine($"Курс обучения: {Course}");
        Console.WriteLine($"Изучаемые дисциплины: {string.Join(", ", Global.Courses[Course-1].Subjects)}");
        Console.WriteLine($"Группа студента: {GroupNumber}");
        Console.WriteLine(new string('-', 50));
    }
}