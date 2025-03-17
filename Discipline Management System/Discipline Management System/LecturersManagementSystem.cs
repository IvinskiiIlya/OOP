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
                foreach (var discipline in Global.Disciplines)
                    discipline.DisplayInfo();
                Console.WriteLine("Введите ID дисциплины:");
                bool isDisciplineId = int.TryParse(Console.ReadLine(), out int SubjectsId);
                
                if (isDisciplineId && SubjectsId > 0 && SubjectsId < Global.Disciplines.Count + 1)
                {
                    var lecturersOfDiscipline = new List<string>();
                    for (int j = 0; j < Global.Disciplines[SubjectsId-1].Lecturer.Count; j++)
                        lecturersOfDiscipline.Add(Global.Disciplines[SubjectsId-1].Lecturer[j]);
                    lecturersOfDiscipline.Add(lecturersSurnameAdding);

                    var lecturersIdUpdating = new List<int>();
                    for (int j = 0; j < Global.Disciplines[SubjectsId-1].LecturerId.Count; j++)
                        lecturersIdUpdating.Add(Global.Disciplines[SubjectsId-1].LecturerId[j]);
                    lecturersIdUpdating.Add(addId);
                    
                    Discipline.UpdateDiscipline(SubjectsId-1, Global.Disciplines[SubjectsId-1].Title, Global.Disciplines[SubjectsId-1].Description, lecturersOfDiscipline, lecturersIdUpdating);
                }
                
                Lecturer lecturersAdding = Lecturer.AddLecturer(addId, lecturersSurnameAdding, lecturersNameAdding, lecturersPatronymicAdding, age, lecturersAcademicTitleAdding, new List<string>{Global.Disciplines[SubjectsId-1].Title}, new List<int>{SubjectsId});
                Global.Lecturers.Add(lecturersAdding);
                Console.WriteLine("Преподаватель добавлен");
                break;
            case 2:
                
                foreach (var lecturer in Global.Lecturers)
                    lecturer.DisplayInfo();
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
                    
                    var subjects = new List<string>();
                    for (int i = 0; i < Global.Lecturers[changeId-1].Subjects.Count; i++)
                        subjects.Add(Global.Lecturers[changeId-1].Subjects[i]);
                    
                    var ids = new List<int>();
                    for (int i = 0; i < Global.Lecturers[changeId-1].SubjectsId.Count; i++)
                        ids.Add(Global.Lecturers[changeId-1].SubjectsId[i]);
                    
                    Lecturer.UpdateLecturer(changeId - 1, lecturersSurnameChanging, lecturersNameChanging, lecturersPatronymicChanging, changeAge, lecturersAcademicTitleChanging, subjects, ids);
                    
                    var lecturers = new List<string>();
                    var lecturersId = new List<int>();
                    for (int i = 0; i < Global.Disciplines[changeId - 1].Lecturer.Count; i++)
                    {
                        if (Global.Lecturers[changeId - 1].Id == Global.Disciplines[changeId - 1].LecturerId[i])
                        {
                            lecturers.Add(lecturersSurnameChanging);
                            lecturersId.Add(Global.Disciplines[changeId-1].LecturerId[i]);
                        }
                        else
                        {
                            lecturers.Add(Global.Disciplines[changeId-1].Lecturer[i]);
                            lecturersId.Add(Global.Disciplines[changeId-1].LecturerId[i]);
                        }
                    }
                  
                    for (int i = 0; i < Global.Lecturers[changeId-1].SubjectsId.Count; i++)
                        Discipline.UpdateDiscipline(ids[i]-1, Global.Disciplines[ids[i]-1].Title, Global.Disciplines[ids[i]-1].Description, lecturers, lecturersId);
                    Console.WriteLine($"Данные о преподавателе с ID = {changeId} изменены");
                }
                else
                    Console.WriteLine("Введен несуществующий ID");
                break;
            case 3:
                
                foreach (var lecturer in Global.Lecturers)
                    lecturer.DisplayInfo();
                Console.WriteLine("Введите ID преподавателя, которого хотите удалить:");
                bool isLecturersIdDeleting = int.TryParse(Console.ReadLine(), out int deleteId);
                
                if (isLecturersIdDeleting && deleteId > 0 && deleteId < Global.Lecturers.Count + 1)
                {
                    var lecturersDisciplineId = new List<int>();
                    for (int i = 0; i < Global.Lecturers[deleteId - 1].SubjectsId.Count; i++)
                        lecturersDisciplineId.Add(Global.Lecturers[deleteId - 1].SubjectsId[i]);
                    
                    var lecturerDeleting = new List<string>();
                    var lecturerIdDeleting = new List<int>();
                    for (int i = 0; i < Global.Disciplines[deleteId - 1].LecturerId.Count; i++)
                    {
                        if (deleteId != Global.Disciplines[deleteId - 1].LecturerId[i])
                        {
                            lecturerDeleting.Add(Global.Disciplines[deleteId-1].Lecturer[i]);
                            lecturerIdDeleting.Add(Global.Disciplines[deleteId-1].LecturerId[i]);
                        }
                    }
                        
                    for (int i = 0; i < Global.Lecturers[deleteId - 1].SubjectsId.Count; i++) 
                        Discipline.UpdateDiscipline(lecturersDisciplineId[i]-1, Global.Disciplines[lecturersDisciplineId[i]-1].Title, Global.Disciplines[lecturersDisciplineId[i]-1].Description, lecturerDeleting, lecturerIdDeleting);
                    
                    Global.Lecturers.RemoveAt(deleteId - 1);
                    for (int i = 0; i < Global.Lecturers.Count; i++)
                        Global.Lecturers[i].Id = i + 1;
                    Console.WriteLine($"Преподаватель с ID = {deleteId} удален");
                }
                else
                    Console.WriteLine("Введен несуществующий ID");
                break;
            case 4:
                foreach (var lecturer in Global.Lecturers)
                    lecturer.DisplayInfo();
                break;
        }
    }
}