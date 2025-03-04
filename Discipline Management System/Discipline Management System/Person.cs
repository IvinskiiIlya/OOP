namespace Discipline_Management_System;

public class Person
{

    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public int Identifier { get; set; }
    private int age;
    
    public int Age
    {
        get
        {
            return age;
        }
        set
        {
            if (value < 1 || value > 120)
                Console.WriteLine("Возраст должен быть в диапазоне от 1 до 120");
            else
                age = value;
        }
    }
}