using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public static class SeedDatabase
    {
        public static void Seed(DbContext context)
        {
            // context.Database.Migrate();// Bekleyen migrationları veritabanına ekler

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context is CourseAppContext)
                {
                    //CourseAppContext
                    CourseAppContext _context = context as CourseAppContext;
                    if (_context.Instructors.Count() == 0)
                    {
                        _context.Instructors.AddRange(Instructors);
                    }

                    if (_context.Courses.Count() == 0)
                    {
                        _context.Courses.AddRange(Courses);
                    }




                }

                if (context is UserContext)
                {
                    UserContext _context = context as UserContext;
                    if (_context.Users.Count() == 0)
                    {
                        _context.Users.AddRange(Users);
                    }
                }
                context.SaveChanges();
            }
        }

        private static Course[] Courses
        {

            get
            {
                Course[] courses = new Course[]
                {
                    new Course() { Name = "HTML", Price = 10, Description = "About Html",isActive=true, Instructor=Instructors[0] },
                    new Course() { Name = "React", Price = 10, Description = "About React", isActive = true,Instructor=Instructors[1] },
                    new Course() { Name = ".NET MVC", Price = 10, Description = "About MVC", isActive = true, Instructor=Instructors[2] },
                    new Course() { Name = "JAVA SPRING", Price = 10, Description = "About JAVA", isActive = true,Instructor=Instructors[3]},
                    new Course() { Name = "C# BASIC", Price = 10, Description = "About C#", isActive=true,Instructor=Instructors[0] },
                    new Course() { Name = "CSS", Price = 10, Description = "About CSS", isActive = true,Instructor=Instructors[3] },
                    new Course() { Name = "ANGULAR", Price = 10, Description = "About ANGULAR", isActive = true,Instructor=Instructors[1]},
                    new Course() { Name = "NODEJS", Price = 10, Description = "About NODEJS", isActive = false,Instructor=Instructors[1]},
                    new Course() { Name = "HTML", Price = 10, Description = "About Html", isActive=true,Instructor=Instructors[2] }
                };
                return courses;
            }
        }
        private static Instructor[] Instructors =
        {
            new Instructor(){Name="Ahmet",Contact=new Contact(){ Email="ahmet@gmail.com", Phone="1231212", Adress = new Adress(){ City =" Muğla",Country=" Türkiye", Text="Atatürk Caddesi"} } },
            new Instructor(){Name="Engin",Contact=new Contact(){ Email="engin@gmail.com", Phone="1231212", Adress = new Adress(){ City =" İstanbul",Country=" Türkiye", Text="cum Caddesi"} }},
            new Instructor(){Name="Ertug",Contact=new Contact(){ Email="ertug@gmail.com", Phone="1231212", Adress = new Adress(){ City =" Muğla",Country=" Türkiye", Text="Atatürk Caddesi"} }},
            new Instructor(){Name="Furkan",Contact=new Contact(){ Email="furkan@gmail.com", Phone="1231212", Adress = new Adress(){ City =" Muğla",Country=" Türkiye", Text="Atatürk Caddesi"} }}
        };

        private static User[] Users =
       {
          new User(){ Username="Engin Arslan", Email="enginarslan48@gmail.com",Password="123456" ,City="Muğla"},
          new User(){ Username="Furkan Bayraktar", Email="furkan48@gmail.com",Password="123456" ,City="İstanbul"},
          new User(){ Username="Bartu Arslan", Email="enginarslan48@gmail.com",Password="123456" ,City="Muğla"},
          new User(){ Username="Muharrem Demirtaş", Email="muharrem@gmail.com",Password="123456" ,City="Tuzla"},



        };

    }
}
