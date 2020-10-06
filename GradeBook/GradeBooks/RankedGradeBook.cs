using GradeBook.Enums;
using System;
namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted)
            : base(name, isWeighted)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var studentsCount = this.Students.Count;
            
            if(studentsCount < 5)
            {
                throw new InvalidOperationException();
            }

            var oneFifthStudents = Math.Truncate(studentsCount * 20M / 100M);

            var moreThanAvarage = 0;

            foreach(var student in this.Students)
            {
                if(student.AverageGrade > averageGrade)
                {
                    moreThanAvarage++;
                }
            }

            var placeInClass = moreThanAvarage == 0 ? 0 : moreThanAvarage / oneFifthStudents;

            if (placeInClass == 0)
                return 'A';
            else if (placeInClass == 1)
                return 'B';
            else if (placeInClass == 2)
                return 'C';
            else if (placeInClass == 3)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if(this.Students.Count >= 5)
            {
                base.CalculateStatistics();
            }
            else
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (this.Students.Count >= 5)
            {
                base.CalculateStudentStatistics(name);
            }
            else
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
            }
        }
    }
}
