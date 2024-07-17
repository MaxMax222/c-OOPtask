bool done = false;
int choise; 
Dictionary<string, Student> database = new Dictionary<string, Student>();

while (!done){
    repeatChoise:
    Console.WriteLine($"enter option you would like to perform: [1-adding a new student, 2-altering student's info, 3 - display student's info]");
    Console.Write($"->");
    choise = int.Parse(Console.ReadLine());

    switch (choise){
        case 1:
        CreateStudent(database);
        break;
        
        case 2:
        AlterStudent(database);
        break;

        case 3:
        DisplayStudentInfo(database);
        break;

        default:
        Console.WriteLine($"non existing choise, try again");
        goto repeatChoise;
    }

    Console.WriteLine($"\n are you done: [yes - 1, no - 2]");
    Console.Write($"->");
    choise = int.Parse(Console.ReadLine());

    done = choise == 1;
}

static string GetName(Dictionary<string, Student> database){
   string name;

    repeatName:
    Console.WriteLine($"enter the name of the student");
    Console.Write($"->");
    name = Console.ReadLine();
    if(!database.ContainsKey(name)){
        Console.WriteLine($"student does not exist, try again");
        goto repeatName;
    }

    return name;
}
static void DisplayStudentInfo(Dictionary<string, Student> database)
{
    string name = GetName(database);

    database[name].DisplayInformation();
}

static void AlterStudent(Dictionary<string, Student> database)
{
    string name = GetName(database);
    int choise;

    repeatAlter:
    Console.Write($"enter what info you want to alter about {name} [1 - name, 2 - id, 3 - age ");
    if (database[name] is CollegeStudent)
    {
        Console.WriteLine($",4 - field of study, 5 - averege score]");
    }
    else{
        Console.WriteLine($"]");
    }
    Console.Write($"->");
    choise = int.Parse(Console.ReadLine());

    switch (choise){

        case 1: // change name
            string newName = GetName(database);

            var deleted = database[name];
            database.Remove(name);

            deleted.SetStudentName(newName);
            database.Add(newName, deleted);
            break;

        case 2: // change student id
            int newId;
            Console.WriteLine($"enter new id for {name}");
            Console.Write($"->");
            newId = int.Parse(Console.ReadLine());
            database[name].SetStudentID(newId);
            break;

        case 3: // change student age
         int newAge;
            Console.WriteLine($"enter new age of {name}");
            Console.Write($"->");
            newAge = int.Parse(Console.ReadLine());
            database[name].SetStudentID(newAge);
            break;

        case 4: // change student field of study (if in college)
            if (database[name] is CollegeStudent collegeStudent1)
            {
                string newField;
                Console.WriteLine($"enter the new field of study for {name}");
                Console.Write("->");
                newField = Console.ReadLine();
                collegeStudent1.SetFieldOfStudy(newField);
                database[name] = collegeStudent1;
            }
            else{
                Console.WriteLine($"student is not in college");
            }
            break;

        case 5: // change student averege score (if in college)
                if (database[name] is CollegeStudent collegeStudent2)
            {
                int newScore;
                Console.WriteLine($"enter the new field of study for {name}");
                Console.Write("->");
                newScore = int.Parse(Console.ReadLine());
                collegeStudent2.SetAvgScore(newScore);
                database[name] = collegeStudent2;
            }
            else{
                Console.WriteLine($"student is not in college");
            }
            break;

            default:
            Console.WriteLine($"invalid option, try again");
            goto repeatAlter;
    }

    Console.WriteLine($"would you like to alter any other information about {name}? [1 - yes, 2 - no]");
    Console.Write($"->");
    choise = int.Parse(Console.ReadLine());
    if (choise == 1)
    {
        goto repeatAlter;
    }    
        
}

static void CreateStudent(Dictionary<string, Student> database){
    int choise = 0, id, age, avg;
    string name = "", studyField;
    Student student = null;

    repeatStudent:
        Console.WriteLine($"enter the name of the student");
        Console.Write($"->");
        name = Console.ReadLine();
        if(!database.ContainsKey(name))
            {
            Console.WriteLine($"enter the age of the student");
            Console.Write($"->");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine($"enter the id of the student");
            Console.Write($"->");
            id = int.Parse(Console.ReadLine());
            
            repeatCollege:
            Console.WriteLine($"is the student in college[1 - yes, 2 - no]");
            choise = int.Parse(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    Console.WriteLine($"enter student's field of study of the student");
                    Console.Write($"->");
                    studyField = Console.ReadLine();
                    Console.WriteLine($"enter the averege score of the student");
                    Console.Write($"->");
                    avg = int.Parse(Console.ReadLine());
                    student = new CollegeStudent(name: name, ID: id, age: age, fieldOfStudy:studyField, avgScore:avg);
                    break;

                case 2:
                    student = new Student(name: name, ID: id, age: age);
                    break;

                default:
                    Console.WriteLine($"invalid choise, try again");
                    goto repeatCollege;
            }
            database.Add(name, student);
        }
        else{
            Console.WriteLine($"student already added, try again");
            goto repeatStudent;
            
        }
}