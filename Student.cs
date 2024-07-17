public class Student : IPerson{

    //fields of Student class
    protected string studentName;
    protected int studentID;
    protected int age;
        
    // constructor
    public Student(string name, int ID, int age){
        studentName = name;
        studentID = ID;
        this.age = age;
    }

    // getters for the fields
    public string GetStudentName(){
        return studentName;
    }
    public int GetStudentID(){
        return studentID;
    }
    public int GetStudentAge(){
        return age;
    }

    // setters for the field
    public void SetStudentName(string studentName){
        this.studentName =  studentName;
    }
    public void SetStudentID(int ID){
         studentID = ID;
    }
    public void SetStudentAge(int age){
         this.age = age;
    }

    public Tuple<string, int, int> GetStudentInfo(){
        return new Tuple<string, int, int>(studentName, studentID, age);
    } 

    public virtual void DisplayInformation(){
        Console.WriteLine($"Student's name: {studentName}");
        Console.WriteLine($"Student' id: {studentID}");
        Console.WriteLine($"Student's age: {age}");
    }
}