namespace Discipline_Management_System;

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
            if (isNumber)
            {
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("1 - добавить нового студента\n2 - изменить данные о студенте\n3 - удалить студента\n4 - показать информацию о студентах");
                        bool isStudentNumber = int.TryParse(Console.ReadLine(), out int studentSelection);
                        Console.Clear();
                        if (isStudentNumber)
                        {
                            StudentsManagementSystem.Main(studentSelection);
                        }
                        break;
                    case 2:
                        Console.WriteLine("1 - добавить нового преподавателя\n2 - изменить данные о преподавателе\n3 - удалить преподавателя\n4 - показать информацию о преподавателях");
                        bool isLecturerNumber = int.TryParse(Console.ReadLine(), out int lecturerSelection);
                        Console.Clear();
                        if (isLecturerNumber)
                        {
                            LecturersManagementSystem.Main(lecturerSelection);
                        }
                        break;
                    case 3:
                        Console.WriteLine("1 - добавить новую дисциплину\n2 - изменить данные о дисциплине\n3 - удалить дисциплину\n4 - прикрепить дисциплину к преподавателю\n5 - прикрепить дисциплину к курсу\n6 - показать преподаваемые дисциплины");
                        bool isDisciplineNumber = int.TryParse(Console.ReadLine(), out int disciplineSelection);
                        Console.Clear();
                        if (isDisciplineNumber)
                        {
                            DisciplinesManagementSystem.Main(disciplineSelection);
                        }
                        break;
                    case 4:
                        foreach (var course in Global.Courses)
                        {
                            course.DisplayInfo();
                        }
                        break;
                }
            }
        }
    }
}