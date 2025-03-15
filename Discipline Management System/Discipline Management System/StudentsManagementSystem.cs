namespace Discipline_Management_System;

public static class StudentsManagementSystem
{
    public static void Main(int selection)
    {
        switch (selection)
        {
            case 1:
                int addId = Global.Students.Count + 1;
                Console.WriteLine("Введите фамилию:");
                string studentsSurnameAdding = Console.ReadLine();
                Console.WriteLine("Введите имя:");
                string studentsNameAdding = Console.ReadLine();
                Console.WriteLine("Введите отчество:");
                string studentsPatronymicAdding = Console.ReadLine();
                Console.WriteLine("Введите возраст:");
                bool isStudentsAge = int.TryParse(Console.ReadLine(), out int age);
                Console.WriteLine("Введите группу студента:");
                bool isStudentsGroup = int.TryParse(Console.ReadLine(), out int group);
                Console.WriteLine("Введите курс обучения студента:");
                bool isStudentsCourse = int.TryParse(Console.ReadLine(), out int course);
                Student studentsAdding = Student.AddStudent(addId, studentsSurnameAdding, studentsNameAdding, studentsPatronymicAdding, age, group, course);
                Global.Students.Add(studentsAdding);
                Console.WriteLine("Студент добавлен");
                break;
            case 2:
                foreach (var student in Global.Students)
                {
                    student.DisplayInfo();
                }
                Console.WriteLine("Введите ID студента, информацию о котором хотите изменить:");
                bool isStudentsIdChanging = int.TryParse(Console.ReadLine(), out int changeId);
                if (isStudentsIdChanging && changeId > 0 && changeId < Global.Lecturers.Count + 1)
                {
                    Console.WriteLine("Введите фамилию:");
                    string studentsSurnameChanging = Console.ReadLine();
                    Console.WriteLine("Введите имя:");
                    string studentsNameChanging = Console.ReadLine();
                    Console.WriteLine("Введите отчество:");
                    string studentsPatronymicChanging = Console.ReadLine();
                    Console.WriteLine("Введите возраст:");
                    bool isStudentsAgeChanging = int.TryParse(Console.ReadLine(), out int changeAge);
                    Console.WriteLine("Введите группу студента:");
                    bool isStudentsGroupChanging = int.TryParse(Console.ReadLine(), out int changeGroup);
                    Console.WriteLine("Введите курс обучения студента:");
                    bool isStudentsCourseChanging = int.TryParse(Console.ReadLine(), out int changeCourse);
                    Student.UpdateStudent(changeId - 1, studentsSurnameChanging, studentsNameChanging, studentsPatronymicChanging, changeAge, changeGroup, changeCourse);
                    Console.WriteLine($"Данные о студенте с ID = {changeId} изменены");
                }
                else
                {
                    Console.WriteLine("Введен несуществующий ID");
                }
                break;
            case 3:
                foreach (var student in Global.Students)
                {
                    student.DisplayInfo();
                }
                Console.WriteLine("Введите ID студента, которого хотите удалить:");
                bool isStudentsIdDeleting = int.TryParse(Console.ReadLine(), out int deleteId);
                if (isStudentsIdDeleting && deleteId > 0 && deleteId < Global.Students.Count + 1)
                {
                    Global.Students.RemoveAt(deleteId - 1);
                    for (int i = 0; i < Global.Students.Count; i++)
                    {
                        Global.Students[i].Id = i + 1;
                    };
                    Console.WriteLine($"Студент с ID = {deleteId} удален");
                }
                else
                {
                    Console.WriteLine("Введен несуществующий ID");
                }
                break;
            case 4:
                foreach (var student in Global.Students)
                {
                    student.DisplayInfo();
                }
                break;
        }
    }
}