namespace Discipline_Management_System;

public class Course
{
    
    public int Identifier { get; set; }
    public int CourseNumber { get; set; }
    
    private List<Course> Courses = new List<Course>();
}