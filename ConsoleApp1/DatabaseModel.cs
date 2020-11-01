using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    //This is function that models how the Database should be designed
    class DatabaseModel : DbContext //Inherits from Microsofts EntityframeworkCore.DbContext to implement Database "things"
    {
        //Constructor that makes sure that the database file is created
        //and if it isn't will create the database
        public DatabaseModel() 
        {
            this.Database.EnsureCreated();
        }

        //Same as a table or list of students
        public DbSet<Student> Students { get; set; }

        //Overrides OnConfiguring method from DbContext and sets the Database file path
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=students.db"); //determines the file path as the current directory with the file "students.db"
        }
    }

    //Student class, information held about each student
    public class Student
    {
        public ulong id { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }

        public int grade { get; set; }
        public int tardies { get; set; }
        public int absences { get; set; }
    }
}
