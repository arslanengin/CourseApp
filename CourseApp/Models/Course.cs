﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool isActive { get; set; }

        //Navigation Property
        public int InstructorId { get; set; }
        public  Instructor Instructor { get; set; }
    }
}
