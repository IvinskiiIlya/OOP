namespace Discipline_Management_System;

public static class LecturersManagementSystem
{
    public static void Main(int selection)
    {
        switch (selection)
        {
            case 1:
                int addId = Global.Lecturers.Count + 1;
                Console.WriteLine("Введите фамилию:");
                string lecturersSurnameAdding = Console.ReadLine();
                Console.WriteLine("Введите имя:");
                string lecturersNameAdding = Console.ReadLine();
                Console.WriteLine("Введите отчество:");
                string lecturersPatronymicAdding = Console.ReadLine();
                Console.WriteLine("Введите возраст:");
                bool isLecturersAge = int.TryParse(Console.ReadLine(), out int age);
                Console.WriteLine("Введите ученое звание:");
                string lecturersAcademicTitleAdding = Console.ReadLine();
                Console.WriteLine("Введите преподаваемую дисциплину:");
                string disciplineAdding = Console.ReadLine();
                var subjectsAdding = new List<string> { disciplineAdding };
                Lecturer lecturersAdding = Lecturer.AddLecturer(addId, lecturersSurnameAdding, lecturersNameAdding, lecturersPatronymicAdding, age, lecturersAcademicTitleAdding, subjectsAdding);
                Global.Lecturers.Add(lecturersAdding);
                Console.WriteLine("Преподаватель добавлен");
                break;
            case 2:
                foreach (var lecturer in Global.Lecturers)
                {
                    lecturer.DisplayInfo();
                }
                Console.WriteLine("Введите ID преподавателя, информацию о котором хотите изменить:");
                bool isLecturersIdChanging = int.TryParse(Console.ReadLine(), out int changeId);
                if (isLecturersIdChanging && changeId > 0 && changeId < Global.Lecturers.Count + 1)
                {
                    Console.WriteLine("Введите фамилию:");
                    string lecturersSurnameChanging = Console.ReadLine();
                    Console.WriteLine("Введите имя:");
                    string lecturersNameChanging = Console.ReadLine();
                    Console.WriteLine("Введите отчество:");
                    string lecturersPatronymicChanging = Console.ReadLine();
                    Console.WriteLine("Введите возраст:");
                    bool isLecturersAgeChanging = int.TryParse(Console.ReadLine(), out int changeAge);
                    Console.WriteLine("Введите ученое звание:");
                    string lecturersAcademicTitleChanging = Console.ReadLine();
                    Console.WriteLine("Введите преподаваемую дисциплину:");
                    string disciplineChanging = Console.ReadLine();
                    for (int i = 0; i < Global.Disciplines.Count; i++)
                    {
                        if (disciplineChanging == Global.Disciplines[i].Title)
                        {
                            var fullName = new List<string> { lecturersSurnameChanging, lecturersNameChanging, lecturersPatronymicChanging };
                            Discipline.UpdateDiscipline(i, Global.Disciplines[i].Title, Global.Disciplines[i].Description, fullName);
                        }
                    }
                    var subjectsChanging = new List<string> { disciplineChanging };
                    Lecturer.UpdateLecturer(changeId - 1, lecturersSurnameChanging, lecturersNameChanging, lecturersPatronymicChanging, changeAge, lecturersAcademicTitleChanging, subjectsChanging);
                    Console.WriteLine($"Данные о преподавателе с ID = {changeId} изменены");
                }
                else
                {
                    Console.WriteLine("Введен несуществующий ID");
                }
                break;
            case 3:
                foreach (var lecturer in Global.Lecturers)
                {
                    lecturer.DisplayInfo();
                }
                Console.WriteLine("Введите ID преподавателя, которого хотите удалить:");
                bool isLecturersIdDeleting = int.TryParse(Console.ReadLine(), out int deleteId);
                if (isLecturersIdDeleting && deleteId > 0 && deleteId < Global.Lecturers.Count + 1)
                {
                    Global.Lecturers.RemoveAt(deleteId - 1);
                    for (int i = 0; i < Global.Lecturers.Count; i++)
                    {
                        Global.Lecturers[i].Id = i + 1;
                    };
                    var lecturerDeleting = new List<string> {null};
                    Discipline.UpdateDiscipline(deleteId-1, Global.Disciplines[deleteId-1].Title, Global.Disciplines[deleteId-1].Description, lecturerDeleting);
                    Console.WriteLine($"Преподаватель с ID = {deleteId} удален");
                }
                else
                {
                    Console.WriteLine("Введен несуществующий ID");
                }
                break;
            case 4:
                foreach (var lecturer in Global.Lecturers)
                {
                    lecturer.DisplayInfo();
                }
                break;
        }
    }
}