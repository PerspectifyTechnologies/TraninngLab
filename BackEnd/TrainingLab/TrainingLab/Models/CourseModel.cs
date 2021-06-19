using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingLab.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public List<string> Chapters { get; set; }
    }
}
