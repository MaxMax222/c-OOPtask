public class CollegeStudent : Student, IPerson
{
    // fields of CollegeStudent class
    protected string fieldOfStudy;
    protected int avgScore;

    // constructor
    public CollegeStudent(string name,int ID, int age, string fieldOfStudy, int avgScore) : base(name, ID, age)
    {
        studentName = name;
        studentID = ID;
        this.age = age;
        this.avgScore = avgScore;
        this.fieldOfStudy = fieldOfStudy;
    }

    // setters
    public void SetFieldOfStudy(string fieldOfStudy){
        this.fieldOfStudy = fieldOfStudy;
    }
    public void SetAvgScore(int avgScore){
        this.avgScore = avgScore;
    }
    // getters
    
    public string GetFieldOfStudy(string fieldOfStudy){
        return fieldOfStudy;
    }
    public int GetAvgScore(int avgScore){
        return avgScore;
    }
    public override void DisplayInformation()
    {
        Console.WriteLine($"Student's name: {studentName}");
        Console.WriteLine($"Student' id: {studentID}");
        Console.WriteLine($"Student's age: {age}");
        Console.WriteLine($"Student's field of study: {fieldOfStudy}");
        Console.WriteLine($"Student's averege score: {avgScore}");
        
    }

}