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
                    
                    var lecturersIdUpdating = new List<int>();
                    for (int i = 0; i < Global.Disciplines[changeId - 1].LecturerId.Count; i++)
                        lecturersIdUpdating.Add(Global.Disciplines[changeId - 1].LecturerId[i]);
                    
                    Discipline.UpdateDiscipline(changeId - 1, disciplinesTitleChanging, disciplinesDescriptionChanging, lecturerUpdating, lecturersIdUpdating);
                    
                    var disciplines = new List<string>();
                    var disciplinesId = new List<int>();
                    for (int i = 0; i < Global.Lecturers[changeId - 1].Subjects.Count; i++)
                    {
                        if (Global.Disciplines[changeId - 1].Id == Global.Lecturers[changeId - 1].SubjectsId[i])
                        {
                            disciplines.Add(disciplinesTitleChanging);
                            disciplinesId.Add(Global.Lecturers[changeId-1].SubjectsId[i]);
                        }
                        else
                        {
                            disciplines.Add(Global.Lecturers[changeId-1].Subjects[i]);
                            disciplinesId.Add(Global.Lecturers[changeId-1].SubjectsId[i]);
                        }
                    }
                    
                    for (int i = 0; i < Global.Disciplines[changeId-1].LecturerId.Count; i++) 
                        Lecturer.UpdateLecturer(lecturersIdUpdating[i]-1, Global.Lecturers[lecturersIdUpdating[i]-1].Surname, Global.Lecturers[lecturersIdUpdating[i]-1].Name, Global.Lecturers[lecturersIdUpdating[i]-1].Patronymic, Global.Lecturers[lecturersIdUpdating[i]-1].Age, Global.Lecturers[lecturersIdUpdating[i]-1].AcademicTitle, disciplines, disciplinesId);
                    Console.WriteLine($"Данные о дисциплине с ID = {changeId} изменены");
                }
                else
                    Console.WriteLine("Введен несуществующий ID");
                break;
            case 3:
                
                foreach (var discipline in Global.Disciplines)
                    discipline.DisplayInfo();
                Console.WriteLine("Введите ID дисциплины, котороую хотите удалить:");
                bool isDisciplinesIdDeleting = int.TryParse(Console.ReadLine(), out int deleteId);
                
                if (isDisciplinesIdDeleting && deleteId > 0 && deleteId < Global.Disciplines.Count + 1)
                {
                    var disciplinesLecturerId = new List<int>();
                    for (int i = 0; i < Global.Disciplines[deleteId - 1].LecturerId.Count; i++)
                        disciplinesLecturerId.Add(Global.Disciplines[deleteId - 1].LecturerId[i]);
                    
                    var disciplineDeleting = new List<string>();
                    var disciplineIdDeleting = new List<int>();
                    for (int i = 0; i < Global.Lecturers[deleteId - 1].SubjectsId.Count; i++)
                    {
                        if (deleteId != Global.Lecturers[deleteId - 1].SubjectsId[i])
                        {
                            disciplineDeleting.Add(Global.Lecturers[deleteId-1].Subjects[i]);
                            disciplineIdDeleting.Add(Global.Lecturers[deleteId-1].SubjectsId[i]);
                        }
                    }
                        
                    for (int i = 0; i < Global.Disciplines[deleteId - 1].LecturerId.Count; i++) 
                        Lecturer.UpdateLecturer(disciplinesLecturerId[i]-1, Global.Lecturers[disciplinesLecturerId[i]-1].Surname, Global.Lecturers[disciplinesLecturerId[i]-1].Name, Global.Lecturers[disciplinesLecturerId[i]-1].Patronymic, Global.Lecturers[disciplinesLecturerId[i]-1].Age, Global.Lecturers[disciplinesLecturerId[i]-1].AcademicTitle, disciplineDeleting, disciplineIdDeleting);
                    
                    Global.Disciplines.RemoveAt(deleteId - 1);
                    for (int i = 0; i < Global.Disciplines.Count; i++)
                        Global.Disciplines[i].Id = i + 1;
                    Console.WriteLine($"Преподаватель с ID = {deleteId} удален");
                }
                else
                    Console.WriteLine("Введен несуществующий ID");
                break;
            case 4:
                foreach (var discipline in Global.Disciplines)
                    discipline.DisplayInfo();
                break;
            case 5:
                
                foreach (var discipline in Global.Disciplines)
                    discipline.DisplayInfo();
                Console.WriteLine("Введите ID дисциплины, которую нужно прикрепить:");
                bool isDisciplineId = int.TryParse(Console.ReadLine(), out int disciplineId);
                
                if (isDisciplineId && disciplineId > 0 && disciplineId < Global.Disciplines.Count + 1)
                {
                    foreach (var lecturer in Global.Lecturers)
                        lecturer.DisplayInfo();
                    Console.WriteLine("Введите ID преподавателя, к которому нужно прикрепить дисциплину:");
                    bool isLecturerId = int.TryParse(Console.ReadLine(), out int lecturerId);

                    if (isLecturerId && lecturerId > 0 && lecturerId < Global.Lecturers.Count + 1)
                    {
                        var disciplineAttaching = new List<string>();
                        var disciplineIdAttaching = new List<int>();
                        for (int i = 0; i < Global.Disciplines[disciplineId - 1].LecturerId.Count; i++)
                        {
                            disciplineAttaching.Add(Global.Disciplines[disciplineId-1].Lecturer[i]);
                            disciplineIdAttaching.Add(Global.Disciplines[disciplineId-1].LecturerId[i]);
                        }
                        disciplineAttaching.Add(Global.Lecturers[lecturerId-1].Surname);
                        disciplineIdAttaching.Add(Global.Lecturers[lecturerId-1].Id);

                        Discipline.UpdateDiscipline(disciplineId-1, Global.Disciplines[disciplineId-1].Title, Global.Disciplines[disciplineId-1].Description, disciplineAttaching, disciplineIdAttaching);

                        var lecturerAttachUpdate = new List<string>(); 
                        var lecturerAttachUpdateId = new List<int>();
                        for (int i = 0; i < Global.Lecturers[lecturerId - 1].SubjectsId.Count; i++)
                        {
                            lecturerAttachUpdate.Add(Global.Lecturers[lecturerId-1].Subjects[i]);
                            lecturerAttachUpdateId.Add(Global.Lecturers[lecturerId-1].SubjectsId[i]);
                        }
                        lecturerAttachUpdate.Add(Global.Disciplines[disciplineId-1].Title);
                        lecturerAttachUpdateId.Add(disciplineId);
                        
                        Lecturer.UpdateLecturer(lecturerId-1, Global.Lecturers[lecturerId-1].Surname, Global.Lecturers[lecturerId-1].Name, Global.Lecturers[lecturerId-1].Patronymic, Global.Lecturers[lecturerId-1].Age, Global.Lecturers[lecturerId-1].AcademicTitle, lecturerAttachUpdate, lecturerAttachUpdateId);
                        Console.WriteLine($"Дисциплина с ID = {disciplineId} прикреплена к преподавателю с ID = {lecturerId}");
                    }
                    else
                        Console.WriteLine("Введен несуществующий ID");
                }
                else
                    Console.WriteLine("Введен несуществующий ID");
                break;
            case 6:
                
                foreach (var discipline in Global.Disciplines)
                    discipline.DisplayInfo();
                Console.WriteLine("Введите ID дисциплины, которую нужно прикрепить:");
                bool isDisciplineToCourseId = int.TryParse(Console.ReadLine(), out int disciplineToCourseId);
                
                if (isDisciplineToCourseId && disciplineToCourseId > 0 && disciplineToCourseId < Global.Disciplines.Count + 1)
                {
                    Console.WriteLine("Введите номер курса, к которому нужно прикрепить:");
                    bool isCourseNum = int.TryParse(Console.ReadLine(), out int courseNum);

                    if (isCourseNum && courseNum >= 1 && courseNum <= 4)
                    {
                        var subjectsOfCourseAttaching = new List<string>();
                        for (int i = 0; i < Global.Courses[courseNum - 1].Subjects.Count; i++) 
                            subjectsOfCourseAttaching.Add(Global.Courses[courseNum - 1].Subjects[i]);
                        subjectsOfCourseAttaching.Add(Global.Disciplines[disciplineToCourseId-1].Title);
                        
                        Course.UpdateCourse(courseNum - 1, courseNum, subjectsOfCourseAttaching);
                        Console.WriteLine($"Дисциплина с ID = {disciplineToCourseId} прикреплена к {courseNum} курсу");
                    }
                    else
                        Console.WriteLine("Введен несуществующий номер курса");
                }
                else
                    Console.WriteLine("Введен несуществующий ID");
                break;
        }
    }
}