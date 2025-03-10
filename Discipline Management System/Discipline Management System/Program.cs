using Discipline_Management_System;

public static class Global
{
    public static List<Discipline> Disciplines { get; } = new List<Discipline>();
    public static List<Lecturer> Lecturers { get; } = new List<Lecturer>();
    public static List<Student> Students { get; } = new List<Student>();
}

public class Program
{
    public static void Main()
    {
        Random random = new Random();
        
        string[] subjects = { "Математика", "Физика", "Экономика", "Философия", "Схемотехника", "Электротехника", "Менеджмент", "Программирование", "Психология", "История" };
        string[] descriptions = { "Царица наук", "Баллистикой по Украине", "Депай в каз", "Зачем это все?", "Шото как то", "Пробой очка", "Повеливаю идти", "Межпозвоночная грыжа с геморроем", "Я дурак?", "Год явки Христа в военкомат?" };
        string[] surnames = { "Иванов", "Петров", "Сидоров", "Кузнецов", "Семенов", "Артемов", "Федоров", "Максимов", "Александров", "Сергеев"};
        string[] names = { "Максим", "Дмитрий", "Артем", "Алексей", "Иван", "Федор", "Илья", "Петр", "Сергей", "Семен" };
        string[] patronymics = { "Алексеевич", "Максимович", "Сидорович", "Федорович", "Дмитриевич", "Артемович", "Семенович", "Андреевич", "Сергеевич", "Ильич" };
        string[] titles = { "Доцент", "Профессор", "Ассистент", "Старший преподаватель", "Заведующий кафедрой" };

        int numOfObjects = 10; 
        for (int i = 0; i < numOfObjects; i++)
        {
            int id = i + 1;
            int age = random.Next(25, 61);
            int studentAge = random.Next(18, 25); 
            int group = random.Next(1, 5); 
            int course = random.Next(1, 4); 
            string title = titles[random.Next(titles.Length)];
            string secondSubject = subjects[random.Next(subjects.Length)];
            while (secondSubject == subjects[i])
            {
                secondSubject = subjects[random.Next(subjects.Length)];
            }
            var subject = new List<string> { subjects[i], secondSubject };
            Discipline discipline = Discipline.AddDiscipline(id, subjects[i], descriptions[i], surnames[i]);
            Global.Disciplines.Add(discipline);
            Lecturer lecturer = Lecturer.AddLecturer(id, surnames[i], names[i], patronymics[i], age, title, subject);
            Global.Lecturers.Add(lecturer);
            Student student = Student.AddStudent(id, surnames[numOfObjects-i-1], names[numOfObjects-i-1], patronymics[numOfObjects-i-1], studentAge, group, course);
            Global.Students.Add(student);
        }
        foreach (var discipline in Global.Disciplines)
        {
            discipline.DisplayInfo();
        }
        foreach (var lecturer in Global.Lecturers)
        {
            lecturer.DisplayInfo();
        }
        foreach (var student in Global.Students)
        {
            student.DisplayInfo();
        }
        
        while (true)
        {
            Console.WriteLine("1 - студенты\n2 - преподаватели\n3 - дисциплины");
            bool isNumber = int.TryParse(Console.ReadLine(), out int selection);
            if (isNumber == true)
            {
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("1 - добавить нового студента\n2 - изменить данные о студенте\n3 - удалить студента\n4 - показать информацию о студенте");
                        bool isStudentNumber = int.TryParse(Console.ReadLine(), out int studentSelection);
                        if (isStudentNumber == true)
                        {
                            switch (studentSelection)
                            {
                                case 1:
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    break;
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("1 - добавить нового преподавателя\n2 - изменить данные о преподавателе\n3 - удалить преподавателя\n4 - показать информацию о преподавателе");
                        bool isLecturerNumber = int.TryParse(Console.ReadLine(), out int lecturerSelection);
                        if (isLecturerNumber == true)
                        {
                            switch (lecturerSelection)
                            {
                                case 1:
                                    Console.WriteLine("Введите две преподаваемые дисциплины:");
                                    string firstDiscipline = Console.ReadLine();
                                    string secondDiscipline = Console.ReadLine();
                                    var subjectsAdding = new List<string> { firstDiscipline, secondDiscipline };
                                    Console.WriteLine("Введите id, фамилию, имя, отчество, возраст и ученое звание:");
                                    bool isLecturerID = int.TryParse(Console.ReadLine(), out int id);
                                    string lecturerSurnameAdding = Console.ReadLine();
                                    string lecturerNameAdding = Console.ReadLine();
                                    string lecturerPatronymicAdding = Console.ReadLine();
                                    bool isLecturerAge = int.TryParse(Console.ReadLine(), out int age);
                                    string lecturerAtAdding = Console.ReadLine();
                                    Lecturer lecturerAdding = Lecturer.AddLecturer(id, lecturerSurnameAdding, lecturerNameAdding, lecturerPatronymicAdding, age, lecturerAtAdding, subjectsAdding);
                                    Global.Lecturers.Add(lecturerAdding);
                                    break;
                                case 2:
                                    var newSubjects = new List<string> { "Алгебра", "Геометрия" };
                                    Lecturer lecturerUpdating = Lecturer.AddLecturer(1, "Иванов", "Иван", "Иванович", 35, "Доцент", newSubjects);
                                    lecturerUpdating.UpdateLecturer("Иванов", "Иван", "Иванович", "Профессор", newSubjects);
                                    lecturerUpdating.DisplayInfo();
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    break;
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("1 - добавить новую дисциплину\n2 - изменить данные о дисциплине\n3 - удалить дисциплину\n4 - прикрепить дисциалину к преподавателю\n5 - прикрепить дисциплину к курсу");
                        bool isDisciplineNumber = int.TryParse(Console.ReadLine(), out int disciplineSelection);
                        if (isDisciplineNumber == true)
                        {
                            switch (disciplineSelection)
                            {
                                case 1:
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    break;
                            }
                        }
                        break;
                }
            }
        }
    }
}