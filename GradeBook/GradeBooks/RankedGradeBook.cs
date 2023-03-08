using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name) {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("InvalidOperationException");
            }

            int ileto20 = Students.Count / 5;
            List<double> Oceny = new List<double>();

            foreach (var student in Students.OrderByDescending(student => student.AverageGrade))
            {
                Oceny.Add(student.AverageGrade);
            }

            if(averageGrade > (Oceny[ileto20]))
            {
                return 'A';
            }
            else if (averageGrade > (Oceny[ileto20*2]))
            {
                return 'B';
            }
            else if (averageGrade > (Oceny[ileto20*3]))
            {
                return 'C';
            }
            else if (averageGrade > (Oceny[ileto20*4]))
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
               base.CalculateStatistics();
            }
        }
    }
}
