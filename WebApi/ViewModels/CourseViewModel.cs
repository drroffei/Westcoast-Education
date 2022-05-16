using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.ViewModels
{
    public class CourseViewModel
    {
        public int CourseNumber { get; set; }
        public string? CourseName { get; set; }
        public int Duration { get; set; }
    }
}