namespace Discipline_Management_System;

public static class Global
{
    public static List<Course> Courses { get; } = new List<Course>();
    public static List<Discipline> Disciplines { get; } = new List<Discipline>();
    public static List<Lecturer> Lecturers { get; } = new List<Lecturer>();
    public static List<Student> Students { get; } = new List<Student>();
}

public class Program
{
    public static void Main()
    {
        Random random = new Random();
        
        string[] subjects = { "Иностранный язык", "История", "Математика", "Менеджмент", "Программирование", "Психология", "Сети ЭВМ", "Схемотехника", "Физика", "Философия", "Экономика", "Электротехника" };
        string[] descriptions = { "Let's summary and suck some dick", "Год явки Христа в военкомат?", "Царицаааааа, царииииицааааа", "Повеливаю идти нахуй", "Межпозвоночные грыжи с геморроем", "Хто я?", "Сеть лучше удочки", "Если бы знали, что это такое", "Баллистической по Украине", "Насрали на ковер, но зачем?", "Депай в каз", "Пробой очка"};
        string[] surnames = { "Александров", "Артемов", "Антонов", "Васильев", "Дмитриев", "Иванов", "Максимов", "Павлов", "Петров", "Семенов", "Сергеев", "Федоров" };
        string[] names = { "Александр", "Артем", "Антон", "Василий", "Дмитрий", "Иван", "Максим", "Павел", "Петр", "Семен", "Сергей", "Федор" };
        string[] patronymics = { "Александрович", "Артемович", "Антонович", "Васильевич", "Дмитриевич", "Иванович", "Максимович", "Павлович", "Петрович", "Семенович", "Сергеевич", "Федорович" };
        string[] titles = { "Ассистент", "Доцент", "Профессор", "Старший преподаватель", "Заведующий кафедрой" };

        Dictionary<string, string> subjectDescriptionMap = new Dictionary<string, string>();
        for (int i = 0; i < subjects.Length; i++)
        {
            subjectDescriptionMap[subjects[i]] = descriptions[i];
        }
        
        int numOfObjects = 12; 
        for (int i = 0; i < numOfObjects; i++)
        {
            string lecturerSurname = surnames[random.Next(surnames.Length)];
            string lecturerName = names[random.Next(names.Length)];
            string lecturerPatronymic = patronymics[random.Next(patronymics.Length)];
            Discipline discipline = Discipline.AddDiscipline(i + 1, subjects[i], descriptions[i], new List<string> { lecturerSurname, lecturerName, lecturerPatronymic });
            Global.Disciplines.Add(discipline);
            Lecturer lecturer = Lecturer.AddLecturer(i + 1, lecturerSurname, lecturerName, lecturerPatronymic, random.Next(25, 61), titles[random.Next(titles.Length)], new List<string> { subjects[i] });
            Global.Lecturers.Add(lecturer);
            Student student = Student.AddStudent(i + 1, surnames[random.Next(surnames.Length)], names[random.Next(names.Length)], patronymics[random.Next(patronymics.Length)], random.Next(18, 25), random.Next(1, 5), random.Next(1, 4));
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
            Console.WriteLine("1 - дисциплины\n2 - курсы\n3 - преподаватели\n4 - студенты");
            bool isNumber = int.TryParse(Console.ReadLine(), out int selection);
            Console.Clear();
            if (isNumber)
            {
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("1 - добавить новую дисциплину\n2 - изменить данные о дисциплине\n3 - удалить дисциплину\n4 - показать преподаваемые дисциплины\n5 - прикрепить дисциплину к преподавателю\n6 - прикрепить дисциплину к курсу");
                        bool isDisciplineNumber = int.TryParse(Console.ReadLine(), out int disciplineSelection);
                        Console.Clear();
                        if (isDisciplineNumber)
                        {
                            DisciplinesManagementSystem.Main(disciplineSelection);
                        }
                        break;
                    case 2:
                        foreach (var course in Global.Courses)
                        {
                            course.DisplayInfo();
                        }
                        break;
                    case 3:
                        Console.WriteLine("1 - добавить нового преподавателя\n2 - изменить данные о преподавателе\n3 - удалить преподавателя\n4 - показать информацию о преподавателях");
                        bool isLecturerNumber = int.TryParse(Console.ReadLine(), out int lecturerSelection);
                        Console.Clear();
                        if (isLecturerNumber)
                        {
                            LecturersManagementSystem.Main(lecturerSelection);
                        }
                        break;
                    case 4:
                        Console.WriteLine("1 - добавить нового студента\n2 - изменить данные о студенте\n3 - удалить студента\n4 - показать информацию о студентах");
                        bool isStudentNumber = int.TryParse(Console.ReadLine(), out int studentSelection);
                        Console.Clear();
                        if (isStudentNumber)
                        {
                            StudentsManagementSystem.Main(studentSelection);
                        }
                        break;
                }
            }
        }
    }
}