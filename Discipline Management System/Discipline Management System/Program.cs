using Discipline_Management_System;

public static class Global
{
    public static List<Discipline> Disciplines { get; } = new List<Discipline>();
    public static List<Lecturer> Lecturers { get; } = new List<Lecturer>();
    public static List<Student> Students { get; } = new List<Student>();
    public static List<Course> Courses { get; } = new List<Course>();
}

public class Program
{
    public static void Main()
    {
        Random random = new Random();
        
        string[] subjects = { "Математика", "Физика", "Экономика", "Философия", "Схемотехника", "Электротехника", "Менеджмент", "Программирование", "Психология", "История", "Сети ЭВМ", "Иностранный язык" };
        string[] descriptions = { "Царица наук", "Баллистикой по Украине", "Депай в каз", "Зачем это все?", "Шото как то", "Пробой очка", "Повеливаю идти нахуй", "Межпозвоночная грыжа с геморроем", "Я дурак?", "Год явки Христа в военкомат?", "Удочка лучше сети", "Lets summary and suck some dick"};
        string[] surnames = { "Иванов", "Петров", "Сидоров", "Кузнецов", "Семенов", "Артемов", "Федоров", "Максимов", "Александров", "Сергеев", "Антонов", "Павлов"};
        string[] names = { "Максим", "Дмитрий", "Артем", "Алексей", "Иван", "Федор", "Илья", "Петр", "Сергей", "Семен", "Павел", "Антон" };
        string[] patronymics = { "Алексеевич", "Максимович", "Павлович", "Федорович", "Антонович", "Артемович", "Семенович", "Андреевич", "Сергеевич", "Ильич", "Дмитриевич", "Сидорович" };
        string[] titles = { "Доцент", "Профессор", "Ассистент", "Старший преподаватель", "Заведующий кафедрой" };

        int numOfObjects = 12; 
        for (int i = 0; i < numOfObjects; i++)
        {
            int id = i + 1;
            int age = random.Next(25, 61);
            int studentAge = random.Next(18, 25); 
            int group = random.Next(1, 5); 
            int course = random.Next(1, 4); 
            string title = titles[random.Next(titles.Length)];
            var subject = new List<string> { subjects[i] };
            var fullName = new List<string> { surnames[i], names[i], patronymics[i] };
            Discipline discipline = Discipline.AddDiscipline(id, subjects[i], descriptions[i], fullName);
            Global.Disciplines.Add(discipline);
            Lecturer lecturer = Lecturer.AddLecturer(id, surnames[i], names[i], patronymics[i], age, title, subject);
            Global.Lecturers.Add(lecturer);
            Student student = Student.AddStudent(id, surnames[numOfObjects-i-1], names[numOfObjects-i-1], patronymics[numOfObjects-i-1], studentAge, group, course);
            Global.Students.Add(student);
        }
        
        Course firstCourse = Course.AddCourse(1, 1, new List<string>{subjects[0], subjects[1], subjects[2]});
        Global.Courses.Add(firstCourse);
        Course secondCourse = Course.AddCourse(2, 2, new List<string>{subjects[3], subjects[4], subjects[5]});
        Global.Courses.Add(secondCourse);
        Course thirdCourse = Course.AddCourse(3, 3, new List<string>{subjects[6], subjects[7], subjects[8]});
        Global.Courses.Add(thirdCourse);
        Course fourthCourse = Course.AddCourse(4, 4, new List<string>{subjects[9], subjects[10], subjects[11]});
        Global.Courses.Add(fourthCourse);
        
        while (true)
        {
            Console.WriteLine("1 - студенты\n2 - преподаватели\n3 - дисциплины\n4 - курсы");
            bool isNumber = int.TryParse(Console.ReadLine(), out int selection);
            Console.Clear();
            if (isNumber == true)
            {
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("1 - добавить нового студента\n2 - изменить данные о студенте\n3 - удалить студента\n4 - показать информацию о студентах");
                        bool isStudentNumber = int.TryParse(Console.ReadLine(), out int studentSelection);
                        Console.Clear();
                        if (isStudentNumber == true)
                        {
                            switch (studentSelection)
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
                                    if (isStudentsIdChanging == true && changeId > 0 && changeId < Global.Lecturers.Count + 1)
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
                                    if (isStudentsIdDeleting == true && deleteId > 0 && deleteId < Global.Students.Count + 1)
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
                        break;
                    case 2:
                        Console.WriteLine("1 - добавить нового преподавателя\n2 - изменить данные о преподавателе\n3 - удалить преподавателя\n4 - показать информацию о преподавателях");
                        bool isLecturerNumber = int.TryParse(Console.ReadLine(), out int lecturerSelection);
                        Console.Clear();
                        if (isLecturerNumber == true)
                        {
                            switch (lecturerSelection)
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
                                    Console.WriteLine("Введите первую преподаваемую дисциплину:");
                                    string firstDiscipline = Console.ReadLine();
                                    Console.WriteLine("Введите вторую дисциплину:");
                                    string secondDiscipline = Console.ReadLine();
                                    var subjectsAdding = new List<string> { firstDiscipline, secondDiscipline };
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
                                    if (isLecturersIdChanging == true && changeId > 0 && changeId < Global.Lecturers.Count + 1)
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
                                        Console.WriteLine("Введите первую преподаваемую дисциплину:");
                                        string changeFirstDiscipline = Console.ReadLine();
                                        Console.WriteLine("Введите вторую дисциплину:");
                                        string changeSecondDiscipline = Console.ReadLine();
                                        var subjectsChanging = new List<string> { changeFirstDiscipline, changeSecondDiscipline };
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
                                    if (isLecturersIdDeleting == true && deleteId > 0 && deleteId < Global.Lecturers.Count + 1)
                                    {
                                        Global.Lecturers.RemoveAt(deleteId - 1);
                                        for (int i = 0; i < Global.Lecturers.Count; i++)
                                        {
                                            Global.Lecturers[i].Id = i + 1;
                                        };
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
                        break;
                    case 3:
                        Console.WriteLine("1 - добавить новую дисциплину\n2 - изменить данные о дисциплине\n3 - удалить дисциплину\n4 - прикрепить дисциплину к преподавателю\n5 - прикрепить дисциплину к курсу\n6 - показать преподаваемые дисциплины");
                        bool isDisciplineNumber = int.TryParse(Console.ReadLine(), out int disciplineSelection);
                        Console.Clear();
                        if (isDisciplineNumber == true)
                        {
                            switch (disciplineSelection)
                            {
                                case 1:
                                    int addId = Global.Disciplines.Count + 1;
                                    Console.WriteLine("Введите название дисциплины:");
                                    string subject = Console.ReadLine();
                                    Console.WriteLine("Введите описание дисциплины:");
                                    string description = Console.ReadLine();
                                    Console.WriteLine("Введите ID преподавателя:");
                                    bool isLecturersId = int.TryParse(Console.ReadLine(), out int id);
                                    string surname = Global.Lecturers[id-1].Surname;
                                    string name = Global.Lecturers[id-1].Name;
                                    string patronymic = Global.Lecturers[id-1].Patronymic;
                                    var fullName = new List<string> { surname, name, patronymic };
                                    Discipline disciplineAdding = Discipline.AddDiscipline(addId, subject, description, fullName);
                                    Global.Disciplines.Add(disciplineAdding);
                                    Console.WriteLine("Дисциплина добавлена");
                                    break;
                                case 2:
                                    foreach (var discipline in Global.Disciplines)
                                    {
                                        discipline.DisplayInfo();
                                    }
                                    Console.WriteLine("Введите ID дисциплины, информацию о которой хотите изменить:");
                                    bool isDisciplinesIdChanging = int.TryParse(Console.ReadLine(), out int changeId);
                                    if (isDisciplinesIdChanging == true && changeId > 0 && changeId < Global.Disciplines.Count + 1)
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
                                    break;
                                case 5:
                                    break;
                                case 6:
                                    foreach (var discipline in Global.Disciplines)
                                    {
                                        discipline.DisplayInfo();
                                    }
                                    break;
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("1 - прикрепить\n2 - показать курсы обучения");
                        bool isCourseNumber = int.TryParse(Console.ReadLine(), out int courseSelection);
                        Console.Clear();
                        if (isCourseNumber == true)
                        {
                            switch (courseSelection)
                            {
                                case 1:
                                    break;
                                case 2:
                                    foreach (var course in Global.Courses)
                                    {
                                        course.DisplayInfo();
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
        }
    }
}