using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ETLProject.API.Models;

namespace ETLProject.API.Services
{
    public class EtlService
    {
        public List<StudentGrade> ExtractAndTransform(string filePath)
        {
            var grades = new List<StudentGrade>();

            using var reader = new StreamReader(filePath);
            reader.ReadLine(); // skip header

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line is null) continue;

                var parts = line.Split(',');

                grades.Add(new StudentGrade
                {
                    StudentName = parts[0],
                    Subject = parts[1],
                    Grade = double.Parse(parts[2], CultureInfo.InvariantCulture),
                    Attendance = int.Parse(parts[3])
                });
            }

            return grades;
        }

        public IEnumerable<object> GetAverageByStudent(List<StudentGrade> grades)
        {
            return grades
                .GroupBy(g => g.StudentName)
                .Select(g => new
                {
                    Student = g.Key,
                    AverageGrade = g.Average(x => x.Grade),
                    AverageAttendance = g.Average(x => x.Attendance)
                });
        }

        public void ExportTransformedData(IEnumerable<object> data, string outputPath)
        {
            using var writer = new StreamWriter(outputPath);
            writer.WriteLine("Student,AverageGrade,AverageAttendance");

            foreach (var item in data)
            {
                var student = item.GetType().GetProperty("Student")?.GetValue(item);
                var avgGrade = item.GetType().GetProperty("AverageGrade")?.GetValue(item);
                var avgAttendance = item.GetType().GetProperty("AverageAttendance")?.GetValue(item);

                writer.WriteLine($"{student},{avgGrade},{avgAttendance}");
            }
        }
    }
}