using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public class EfCourseRepository : ICourseRepository
    {
        private CourseAppContext _context;
        public EfCourseRepository(CourseAppContext context)
        {
            _context = context;
        }

        public IQueryable<Course> Courses => throw new NotImplementedException();

        public int CreateCourse(Course newCourse)
        {
            
            _context.Add(newCourse);
            _context.SaveChanges();
            return newCourse.Id;
        }

        public void DeleteCourse(int courseid)
        {
            var entity = GetById(courseid);
            _context.Remove(entity);


            if (entity.Instructor != null)
            {
                _context.Remove(entity.Instructor);
            }

            _context.SaveChanges();
        }

        public Course GetById(int courseid)
        {
            //lazy loading return _context.Courses.Instructor.Contact.Adress


            return _context.Courses
                .Include(i=>i.Instructor)
                .ThenInclude(i=>i.Contact)
                .ThenInclude(İ=>İ.Adress)
                .FirstOrDefault(i=>i.Id==courseid);
        }

        public IEnumerable<Course> GetCourses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCoursesByActive(bool isActive)
        {
            return _context.Courses.Where(i => i.isActive == isActive).ToList();
        }

        public IEnumerable<Course> GetCoursesByFilter(string name = null, decimal? price = null, string isActive = null)
        {
            IQueryable<Course> query = _context.Courses;

            if (name != null)
            {
                query = query.Where(i => i.Name.ToLower().Contains(name.ToLower()));
            }

            if (price != null)
            {
                query = query.Where(i => i.Price >= price);
            }

            if (isActive == "on")
            {
                query = query.Where(i => i.isActive == true);
            }

            return query.Include(i => i.Instructor).ToList();
        }

        public void UpdateCourse(Course updatedCourse, Course originalCourse = null)
        {
            if (originalCourse == null)
            {
                originalCourse = _context.Courses.Find(updatedCourse.Id);
            }
            else
            {
                _context.Courses.Attach(originalCourse); // change tracking başlatılır
            }

            originalCourse.Name = updatedCourse.Name;
            originalCourse.Description = updatedCourse.Description;
            originalCourse.Price = updatedCourse.Price;
            originalCourse.isActive = updatedCourse.isActive;

            originalCourse.Instructor.Name = updatedCourse.Instructor.Name;   



            EntityEntry entry = _context.Entry(originalCourse);

            //Modified, unchanged, Added, Deleted ,Detached

            Console.WriteLine($"Entity State:{entry.State}");

            foreach (var property in new string[] { "Name", "Description", "Price", "isActive" })
            {
                Console.WriteLine($"{property} - old : {entry.OriginalValues[property]}  new : {entry.CurrentValues[property]}");
            }

            _context.SaveChanges();


        }
    }
}
