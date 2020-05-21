using System.Collections.Generic;
using System;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades; 
        // Public member always have uppercase name
        public string Name;

        public Book(string name) {
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(double grade) {
            this.grades.Add(grade);
        }

        public void printGrade() {
            grades.ForEach(grade => {
                Console.WriteLine($"Current grade is {grade}");
            });
        }

        /**
         * Show statistics: Highest grade, Lowest grade and Average grade
         */
        public void showStatistics() {
            var stats = this.GetStatistics();
            Console.WriteLine($"Highest grade is {stats.High:N2}");
            Console.WriteLine($"Lowest grade is {stats.Low:N2}");
            Console.WriteLine($"Average grade is {stats.Average:N2}");
        }

        public Statistics GetStatistics() {
            
            var low = double.MaxValue;
            var high = double.MinValue;
            var avg = 0.0;
            foreach(var grade in grades) {
                low = Math.Min(grade, low);
                high = Math.Max(grade, high);
                avg += grade;
            }
            avg /= grades.Count;
            
            var stats = new Statistics(avg, high, low);
            return stats;
        }

        public double getHighestGrade() {
            var highGrade = double.MinValue;
            foreach(var grade in grades){
               highGrade = Math.Max(grade, highGrade);
            }
            return highGrade;
        }

        public double getLowestGrade() {
            var lowGrade = double.MaxValue;
            foreach(var grade in grades) {
                lowGrade = Math.Min(grade, lowGrade);
            }
            return lowGrade;
        }

        public double getAverage() {
            var totalGrade = 0.0;
            foreach(var grade in grades) {
                totalGrade += grade;
            }
            var averageGrade = totalGrade/grades.Count;
            return totalGrade;
        }

    }
}