bool done = false;
int choice; 
Dictionary<string, Student> database = new Dictionary<string, Student>();

while (!done)
{
    Console.WriteLine("Enter option you would like to perform: [1 - Add a new student, 2 - Alter student's info, 3 - Display student's info]");
    Console.Write("-> ");
    choice = GetValidInt();

    switch (choice)
    {
        case 1:
            CreateStudent(database);
            break;

        case 2:
            if (database.Count > 0)
                AlterStudent(database);
            else
                Console.WriteLine("There are no students in the database.");
            break;

        case 3:
            if (database.Count > 0)
                DisplayStudentInfo(database);
            else
                Console.WriteLine("There are no students in the database.");
            break;

        default:
            Console.WriteLine("Non-existing choice, try again.");
            break;
    }

    Console.WriteLine("\nAre you done? [1 - Yes, 2 - No]");
    Console.Write("-> ");
    choice = GetValidInt();
    done = choice == 1;
}

static void DisplayStudentInfo(Dictionary<string, Student> database)
{
    string name = GetName(database);
    database[name].DisplayInformation();
}

static void AlterStudent(Dictionary<string, Student> database)
{
    string name = GetName(database);
    int choice;

    do
    {
        Console.Write($"Enter what info you want to alter about {name} [1 - Name, 2 - ID, 3 - Age");
        if (database[name] is CollegeStudent)
        {
            Console.WriteLine(", 4 - Field of Study, 5 - Average Score]");
        }
        else
        {
            Console.WriteLine("]");
        }
        Console.Write("-> ");
        choice = GetValidInt();

        switch (choice)
        {
            case 1:
                string newName = GetUniqueName(database);
                var student = database[name];
                database.Remove(name);
                student.SetStudentName(newName);
                database.Add(newName, student);
                break;

            case 2:
                Console.WriteLine($"Enter new ID for {name}");
                Console.Write("-> ");
                int newId = GetValidInt();
                database[name].SetStudentID(newId);
                break;

            case 3:
                Console.WriteLine($"Enter new age for {name}");
                Console.Write("-> ");
                int newAge = GetValidInt();
                database[name].SetStudentAge(newAge);
                break;

            case 4:
                if (database[name] is CollegeStudent collegeStudent)
                {
                    Console.WriteLine($"Enter the new field of study for {name}");
                    Console.Write("-> ");
                    string newField = Console.ReadLine();
                    collegeStudent.SetFieldOfStudy(newField);
                }
                else
                {
                    Console.WriteLine("Student is not in college.");
                }
                break;

            case 5:
                if (database[name] is CollegeStudent collegeStudent2)
                {
                    Console.WriteLine($"Enter the new average score for {name}");
                    Console.Write("-> ");
                    int newScore = GetValidInt();
                    collegeStudent2.SetAvgScore(newScore);
                }
                else
                {
                    Console.WriteLine("Student is not in college.");
                }
                break;

            default:
                Console.WriteLine("Invalid option, try again.");
                break;
        }

        Console.WriteLine($"Would you like to alter any other information about {name}? [1 - Yes, 2 - No]");
        Console.Write("-> ");
        choice = GetValidInt();
    } while (choice == 1);
}

static void CreateStudent(Dictionary<string, Student> database)
{
    int choice, id, age, avg;
    string name, studyField;
    Student student;

    name = GetUniqueName(database);
    Console.WriteLine($"Enter the age of the student");
    Console.Write("-> ");
    age = GetValidInt();
    Console.WriteLine($"Enter the ID of the student");
    Console.Write("-> ");
    id = GetValidInt();

    Console.WriteLine($"Is the student in college? [1 - Yes, 2 - No]");
    choice = GetValidInt();

    switch (choice)
    {
        case 1:
            Console.WriteLine($"Enter the student's field of study");
            Console.Write("-> ");
            studyField = Console.ReadLine();
            Console.WriteLine($"Enter the average score of the student");
            Console.Write("-> ");
            avg = GetValidInt();
            student = new CollegeStudent(name, id, age, studyField, avg);
            break;

        case 2:
            student = new Student(name, id, age);
            break;

        default:
            Console.WriteLine("Invalid choice, try again.");
            CreateStudent(database); // Retry
            return;
    }

    database.Add(name, student);
}

static string GetName(Dictionary<string, Student> database)
{
    string name;
    do
    {
        Console.WriteLine("Enter the name of the student");
        Console.Write("-> ");
        name = Console.ReadLine();
        if (!database.ContainsKey(name))
        {
            Console.WriteLine("Student does not exist, try again.");
        }
    } while (!database.ContainsKey(name));

    return name;
}

static string GetUniqueName(Dictionary<string, Student> database)
{
    string name;
    do
    {
        Console.WriteLine("Enter the name of the student");
        Console.Write("-> ");
        name = Console.ReadLine();
        if (database.ContainsKey(name))
        {
            Console.WriteLine("Student already added, try again.");
        }
    } while (database.ContainsKey(name));

    return name;
}

static int GetValidInt()
{
    int choice;
    while (!int.TryParse(Console.ReadLine(), out choice))
    {
        Console.WriteLine("Invalid input, please enter a valid integer.");
        Console.Write("-> ");
    }

    return choice;
}
