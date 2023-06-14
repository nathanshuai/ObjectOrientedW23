string sName = "Bob";
string cName = "Math";
string iName = "Alex";

School.RegisterStudent(sName,80);
School.RegisterStudent("Other Person",90);
School.RegisterStudent("Name Namerson",100);

School.RegisterCourse(cName, 2);
School.RegisterCourse("Advanced Courses",30);

School.RegisterInstructor(iName, 5000);
School.RegisterInstructor("david", 6000);


Student studentToAdd = School.GetStudent(sName);
Course courseToAdd = School.GetCourse(cName);
Instructor instructorToAdd = School.GetInstructor(iName);

School.RegisterStudentForCourse(studentToAdd, courseToAdd);
School.SettingInstructorForACourse(instructorToAdd, courseToAdd);



static class School
{
    public static string Name { get; } = "MITT";
    private static HashSet<Course> _courses = new HashSet<Course>();
    private static HashSet<Student> _students = new HashSet<Student>();
    private static HashSet<Instructor> _instructors = new HashSet<Instructor>();

    public static void RegisterStudent(string newStudentName, int grades)
    {
        Student newStudent = new Student(newStudentName, grades);
        _students.Add(newStudent);
        Console.WriteLine($"Total of {_students.Count} students.");
    }

    public static void RegisterCourse(string courseTitle, int capacity)
    {
        Course newCourse = new Course(courseTitle, capacity);
        _courses.Add(newCourse);
        Console.WriteLine($"Total of {_courses.Count} courses.");
    }

    public static void RegisterInstructor(string instructorName, int salary)
    {
        Instructor instructor = new Instructor(instructorName, salary);
        _instructors.Add(instructor);
        Console.WriteLine($"Total of {_instructors.Count} instructors.");

    }
    public static void RegisterStudentForCourse(Student student, Course course)
    {
        student.SetCourse(course);
        course.AddStudentToCourse(student);
        Console.WriteLine($"student  '{student.fullName}' register the {course.Title} courses.");
    }

    public static void SettingInstructorForACourse(Instructor instructor, Course course)
    {
        instructor.techCourse(course);
        course.AddInstructorToCourse(instructor);
        Console.WriteLine($"Instructor  '{instructor.fullName}' '{instructor.Salary} salary'is setting on the {course.Title} courses.");
    }

    public static Student? GetStudent(string studentName)
    {
        Student foundStudent = _students.First(s => s.fullName == studentName);
        return foundStudent;
    }

    public static Course? GetCourse(string courseName)
    {
        Course foundCourse = _courses.First(c => c.Title == courseName);
        return foundCourse;
    }

    public static Instructor? GetInstructor(string instructorName)
    {
        Instructor foundInstructor = _instructors.FirstOrDefault(i => i.fullName == instructorName);
        return foundInstructor;
    }

}

abstract class person
{
    protected string _fullName;
    public string fullName { get { return _fullName; } }

    protected Course _course;

}
class Student :person
{

    private int _grade;
    public int grade { get { return _grade; } set { } }

    
    public void SetCourse(Course course)
    {
        _course = course;
    }

    public Student(string fullName, int grade)
    {
        if (!String.IsNullOrEmpty(fullName))
        {
            _fullName = fullName;
        }
        _grade = grade;
    }
}
// create method for registering an instructor, adding an instructor to a course
//each course may only have one instructor and create the instructor class(Name)

class Course
{
    private string _title;
    public string Title { get { return _title; } }

    private HashSet<Student> _students = new HashSet<Student>();
    private Instructor _instructor;
    private int _capacity;
    public void AddInstructorToCourse(Instructor instructor)
    {
        _instructor = instructor;
    }
    public void AddStudentToCourse(Student student)
    {
        if (_students.Count < _capacity)
        {
            _students.Add(student);
        }
        else
        {
            Console.WriteLine("Course capacity has been reached. Cannot add more students.");
        }
    }

    public void SetGradeForStudent(Student student, int grade)
    {
        student.grade= grade;
    }

    public double GetAverageGrade()
    {
        if (_students.Count == 0)
            return 0.0;

        double sum = 0;
        foreach (var student in _students)
        {
            foreach(var grade in _students)

            sum += student.grade;
            
        }

        return sum / (_students.Count);
    }

    public Course(string title, int capacity)
    {
        if (!String.IsNullOrEmpty(title))
        {
            _title = title;
        }
        _capacity = capacity;
    }
}
class Instructor : person
{ 
    private int _salary;
    public int Salary { get { return _salary; } }   

    public void techCourse(Course course)
    {
        _course = course;
    }

    public Instructor(string fullName, int salary)
    {
        if(!String.IsNullOrEmpty(fullName))
        {
            _fullName = fullName;
        }

        _salary = salary;
    }

}


// Students can Enroll in one course
// Courses can have many students in them
// These belong to a static School class
// School has an AddStudentToCourse(Student s, Course c) method defined on it

//Add Instructors to Courses -- each Course should have one Instructor, and an Instructor may only teach a single Course.
//Have methods for registering new instructors, and setting the instructor of a course.
//Instructors should possess a Salary member.
//Add Grades to Students as members. Create a method for getting the average grade of a course.	
//Refactor your program to have Instructors and Students inherit from an abstract class,
//which will possess only the members necessary to all child classes. 
//Each Course should have a Capacity. When adding students to a Course, it should be ensure that the capacity is not exceeded.
