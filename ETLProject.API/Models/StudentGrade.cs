using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETLProject.API.Models
{
    public class StudentGrade
    {
        public string StudentName { get; set; }
        public string Subject { get; set; }
        public double Grade { get; set; }
        public int Attendance { get; set; }
    }
}