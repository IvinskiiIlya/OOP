namespace Discipline_Management_System;

public class Person
{
    public int Id { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public int Age { get; set; }
    
    public Person(int id, string surname, string name, string patronymic, int age)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        Age = age;
    }
}