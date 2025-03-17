namespace Discipline_Management_System;

public static class DisciplinesManagementSystem
{
    public static void Main(int selection)
    {
        switch (selection)
        {
            case 1:
                
                int addId = Global.Disciplines.Count + 1;
                Console.WriteLine("Введите название дисциплины:");
                string subject = Console.ReadLine();
                Console.WriteLine("Введите описание дисциплины:");
                string description = Console.ReadLine();
                foreach (var lecturer in Global.Lecturers)
                    lecturer.DisplayInfo();
                Console.WriteLine("Введите ID преподавателя:");
                bool isLecturersId = int.TryParse(Console.ReadLine(), out int id);
                Console.WriteLine("Введите курс, на котором будет преподаваться дисциплина:");
                bool isCourse = int.TryParse(Console.ReadLine(), out int course);
                
                var subjectsOfCourse = new List<string>();
                for (int i = 0; i < Global.Courses[course - 1].Subjects.Count; i++) 
                    subjectsOfCourse.Add(Global.Courses[course - 1].Subjects[i]);
                subjectsOfCourse.Add(subject);
                Course.UpdateCourse(course-1, course, subjectsOfCourse);

                var lecturersId = new List<int>();
                for (int i = 0; i < Global.Disciplines[id - 1].LecturerId.Count; i++)
                {
                    if (id == Global.Disciplines[id-1].LecturerId[i]) 
                        lecturersId.Add(Global.Disciplines[id - 1].LecturerId[i]);
                    else
                    {
                        lecturersId.Add(Global.Disciplines[id - 1].LecturerId[i]);
                        lecturersId.Add(id);
                    }
                }
                Discipline disciplineAdding = Discipline.AddDiscipline(addId, subject, description, new List<string>{Global.Lecturers[id-1].Surname},lecturersId);
                Global.Disciplines.Add(disciplineAdding);
                
                var subjects = new List<string>();
                for (int i = 0; i < Global.Lecturers[id - 1].Subjects.Count; i++)
                    subjects.Add(Global.Lecturers[id - 1].Subjects[i]);
                subjects.Add(subject);
                
                var ids = new List<int>();
                for (int i = 0; i < Global.Lecturers[id - 1].SubjectsId.Count; i++)
                    ids.Add(Global.Lecturers[id - 1].SubjectsId[i]);
                ids.Add(addId);
                
                Lecturer.UpdateLecturer(id-1, Global.Lecturers[id-1].Surname, Global.Lecturers[id-1].Name, Global.Lecturers[id-1].Patronymic, Global.Lecturers[id-1].Age, Global.Lecturers[id-1].AcademicTitle, subjects, ids);
                Console.WriteLine("Дисциплина добавлена");
                break;
            case 2:
                
                foreach (var discipline in Global.Disciplines)
                    discipline.DisplayInfo();
                Console.WriteLine("Введите ID дисциплины, информацию о которой хотите изменить:");
                bool isDisciplinesIdChanging = int.TryParse(Console.ReadLine(), out int changeId);
                
                if (isDisciplinesIdChanging && changeId > 0 && changeId < Global.Disciplines.Count + 1)
                {
                    Console.WriteLine("Введите название дисциплины:");
                    string disciplinesTitleChanging = Console.ReadLine();
                    Console.WriteLine("Введите описание дисциплины:");
                    string disciplinesDescriptionChanging = Console.ReadLine();

                    var lecturerUpdating = new List<string>();
                    for (int i = 0; i < Global.Disciplines[changeId-1].Lecturer.Count; i++)
                        lecturerUpdating.Add(Global.Disciplines[changeId-1].Lecturer[i]);
                    lecturerUpdating.Add(Global.Lecturers[changeId-1].Surname);
                    
                    var lecturersIdUpdating = new List<int>();
                    for (int i = 0; i < Global.Disciplines[changeId - 1].LecturerId.Count; i++)
                        lecturersIdUpdating.Add(Global.Disciplines[changeId - 1].LecturerId[i]);
                    lecturersIdUpdating.Add(changeId);
                    
                    Discipline.UpdateDiscipline(changeId - 1, disciplinesTitleChanging, disciplinesDescriptionChanging, lecturerUpdating, lecturersIdUpdating);
                    
                    var subjectChanging = new List<string>();
                    for (int i = 0; i < Global.Lecturers[changeId-1].Subjects.Count; i++)
                        subjectChanging.Add(Global.Lecturers[changeId-1].Subjects[i]);
                    subjectChanging.Add(disciplinesTitleChanging);
                    
                    var idsUpdating = new List<int>();
                    for (int i = 0; i < Global.Lecturers[changeId-1].SubjectsId.Count; i++)
                        idsUpdating.Add(Global.Lecturers[changeId-1].SubjectsId[i]);
                    idsUpdating.Add(changeId);
                    Lecturer.UpdateLecturer(changeId-1, Global.Lecturers[changeId-1].Surname, Global.Lecturers[changeId-1].Name, Global.Lecturers[changeId-1].Patronymic, Global.Lecturers[changeId-1].Age, Global.Lecturers[changeId-1].AcademicTitle, subjectChanging, idsUpdating);
                    Console.WriteLine($"Данные о дисциплине с ID = {changeId} изменены");
                }
                else
                    Console.WriteLine("Введен несуществующий ID");
                break;
            case 3:
                break;
            case 4:
                foreach (var discipline in Global.Disciplines)
                    discipline.DisplayInfo();
                break;
            case 5:
                break;
            case 6:
                break;
        }
    }
}