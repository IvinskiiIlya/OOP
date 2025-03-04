namespace Discipline_Management_System;

public class Lecturer : Person
{
    
    public int Identifier { get; set; }
    public string AcademicTitle { get; set; }
    
    private List<Lecturer> Lecturers = new List<Lecturer>();
    
    public void AddLecturer(Lecturer lecturer)
    {
        Lecturers.Add(lecturer);
    }
    
    public void DisplayLecturers()
    {
        Lecturers.ForEach(delegate(Lecturer lecturer)
        {
            Console.WriteLine(lecturer);
        });
    }
}