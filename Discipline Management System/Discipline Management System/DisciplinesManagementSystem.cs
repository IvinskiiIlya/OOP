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
                {
                    lecturer.DisplayInfo();
                }
                Console.WriteLine("Введите ID преподавателя:");
                bool isLecturersId = int.TryParse(Console.ReadLine(), out int id);
                Console.WriteLine("Введите курс, на котором будет преподаваться дисциплина:");
                bool isCourse = int.TryParse(Console.ReadLine(), out int course);
                var subjectsOfCourse = new List<string>();
                for (int i = 0; i < Global.Courses[course - 1].Subjects.Count; i++)
                {
                    subjectsOfCourse.Add(Global.Courses[course - 1].Subjects[i]);
                }
                subjectsOfCourse.Add(subject);
                Course.UpdateCourse(course-1, course, subjectsOfCourse);
                Discipline disciplineAdding = Discipline.AddDiscipline(addId, subject, description, new List<string>{Global.Lecturers[id-1].Surname});
                Global.Disciplines.Add(disciplineAdding);
                var subjects = new List<string>();
                for (int i = 0; i < Global.Lecturers[id - 1].Subjects.Count; i++)
                {
                    subjects.Add(Global.Lecturers[id - 1].Subjects[i]);
                }
                subjects.Add(subject);
                Lecturer.UpdateLecturer(id-1, Global.Lecturers[id-1].Surname, Global.Lecturers[id-1].Name, Global.Lecturers[id-1].Patronymic, Global.Lecturers[id-1].Age, Global.Lecturers[id-1].AcademicTitle, subjects);
                Console.WriteLine("Дисциплина добавлена");
                break;
            case 2:
                foreach (var discipline in Global.Disciplines)
                {
                    discipline.DisplayInfo();
                }
                Console.WriteLine("Введите ID дисциплины, информацию о которой хотите изменить:");
                bool isDisciplinesIdChanging = int.TryParse(Console.ReadLine(), out int changeId);
                if (isDisciplinesIdChanging && changeId > 0 && changeId < Global.Disciplines.Count + 1)
                {
                    Console.WriteLine("Введите название дисциплины:");
                    string disciplinesTitleChanging = Console.ReadLine();
                    Console.WriteLine("Введите описание дисциплины:");
                    string disciplinesDescriptionChanging = Console.ReadLine();
                    var fullNameChanging = new List<string> { Global.Lecturers[changeId-1].Surname, Global.Lecturers[changeId-1].Name, Global.Lecturers[changeId-1].Patronymic };
                    Discipline.UpdateDiscipline(changeId - 1, disciplinesTitleChanging, disciplinesDescriptionChanging, fullNameChanging);
                    var subjectChanging = new List<string> {disciplinesTitleChanging};
                    Lecturer.UpdateLecturer(changeId-1, Global.Lecturers[changeId-1].Surname, Global.Lecturers[changeId-1].Name, Global.Lecturers[changeId-1].Patronymic, Global.Lecturers[changeId-1].Age, Global.Lecturers[changeId-1].AcademicTitle, subjectChanging);
                    Console.WriteLine($"Данные о дисциплине с ID = {changeId} изменены");
                }
                else
                {
                    Console.WriteLine("Введен несуществующий ID");
                }
                break;
            case 3:
                break;
            case 4:
                foreach (var discipline in Global.Disciplines)
                {
                    discipline.DisplayInfo();
                }
                break;
            case 5:
                break;
            case 6:
                break;
        }
    }
}