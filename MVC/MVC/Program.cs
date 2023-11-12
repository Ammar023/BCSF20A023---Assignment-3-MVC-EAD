// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Diagnostics;





using (var context = new MyContext())

{

    // Here I Edit the fields of Table of DataBase by Write the Code
    // Here I update the Last Name of Students Table Of Id 16
    int stdID = 16;
    
    var st = context.Students!.Find(stdID);

    if (st != null)
    {
        
        // Update the desired field of Students Table
        st.LastName = "Ba";

        
        Console.WriteLine("After the Update");
        // Save the changes to the database
        context.SaveChanges();
    }

    




    // The following code show that I add some fields like Roll NO , Email in the Students Table
    
        var student1 = new Student()
        {
            FirstMidName = " Ammar Ali ",
            LastName = "Wasif",
            RollNo = 23,
            Email = "BCSF20A023",
            EnrollmentDate = DateTime.Parse(DateTime.Today.ToString())

        };
        context.Students!.Add(student1);


        context.SaveChanges();




    // We can Add the Teacher which Teaches Multiple courses  in the Following

    /*


       Console.WriteLine("Create the New Teacher which Teaches multiple courses ");
       var teacher1 = new Teacher
       {
           FirstName = "fAREED",
           LastName = "Ali",
           Courses = new List<Course>
        {
            new Course { Title = "Introduction to Programming", Credits = 3 },

            new Course { Title = "Database Design", Credits = 4 }

            // Add more courses as needed
        }

       };


   */




    var students = context.Students!.ToList();

        Console.WriteLine("Retrieve all Students from the database:");

        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.ID}, Name: {student.FirstMidName} {student.LastName}, RollNo: {student.RollNo},Email:{student.Email}, Enrollment Date: {student.EnrollmentDate}");

            // Print additional details based on your model
            foreach (var enrollment in student.Enrollments!)
            {
                Console.WriteLine($"   Course: {enrollment.Course!.Title}, Grade: {enrollment.Grade}");
            }
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
       

}












public enum Grade
{
    A, B, C, D, F
}
public class Enrollment
{
    public int EnrollmentID { get; set; }
    public int CourseID { get; set; }
    public int StudentID { get; set; }
    public Grade? Grade { get; set; }

    public virtual Course ?Course { get; set; }
    public virtual Student ?Student { get; set; }
}

public class Student
{
    [Key]
    public int ID { get; set; }
    public string ?LastName { get; set; }
    public string ?FirstMidName { get; set; }
    public int RollNo { get; set; }

    public string ?Email { get; set; }
    public DateTime EnrollmentDate { get; set; }

    public virtual ICollection<Enrollment> ?Enrollments { get; set; }
}
public class Teacher
{

    [Key]
    public int Tid { get; set;}
    public string ?FirstName { get; set;}
    public string ?LastName { get; set; }
    public virtual ICollection<Course> ?Courses { get; set; }
}   
public class Course
{
    public int CourseID { get; set; }
    public int Tid { get; set; }

    public string ?Title { get; set; }
    public int Credits { get; set; }
    public virtual Teacher ?Teacher { get; set; }

    public virtual ICollection<Enrollment> ?Enrollments { get; set; }
}

public class MyContext : DbContext
{
    
    public virtual DbSet<Course> ?Courses { get; set; }
    public virtual DbSet<Enrollment> ?Enrollments { get; set; }
    public virtual DbSet<Student> ?Students { get; set; }
    public virtual DbSet<Teacher> ?Teachers { get; set; }


    //  For  Grant the editing roles  like Update,Alter  i already give the permission by writing query 

    //   I use the following coomand

    //   like for all tables

    //   GRANT UPDATE,ALTER, DELETE ON Students TO DatabaseEditorRole;



    


}


