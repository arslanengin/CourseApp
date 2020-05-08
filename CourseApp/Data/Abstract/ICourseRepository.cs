using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public interface ICourseRepository
    {
        IQueryable<Course> Courses { get; }

        Course GetById(int id);

        IEnumerable<Course> GetCourses();
        IEnumerable<Course> GetCoursesByActive(bool isActive);

        IEnumerable<Course> GetCoursesByFilter(string name = null, decimal? price = null, string isActive = null);
        int CreateCourse(Course newCourse);
        void UpdateCourse(Course course, Course originalCourse=null);
        void DeleteCourse(int courseid);
    }
}
