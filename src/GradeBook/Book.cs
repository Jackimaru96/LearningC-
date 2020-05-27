using System.Collections.Generic;
using System;

namespace GradeBook
{
    public class Book
    {
        private List<double> grades; 
        // Public member always have uppercase name
        // public string Name;
        // To define Property, usually has a private field first
        private string name;
        private char letterGrade;

        // Defining Properties instead of Fields
        // It encapsulates state and stores data for an object; but different syntax and powerful features
        // private to protect the state, control access to the field

        // Access modifier
        public string Name {
            // read the Name property
            get {
                return name;
            }

            // set the Name property
            set {
                if(!String.IsNullOrEmpty(value)) {
                    name = value;
                }
            }
        }


        // Constructor
        public Book(string name) {
            grades = new List<double>();
            Name = name;
        }

        public void AddLetterGrade(char grade) {
            switch(grade) {
                case 'A': 
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(65);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default: 
                    AddGrade(50);
                    break;
            }
        }

        public void GetLetterGradeWithAvg(double average) {
            switch(average) {
                case var d when d >= 90.0:
                    this.letterGrade = 'A';
                    break;
                case var d when d >= 80.0:
                    this.letterGrade = 'B';
                    break;
                case var d when d >= 70.0:
                    this.letterGrade = 'C';
                    break;
                case var d when d >= 70.0:
                    this.letterGrade = 'C';
                    break;
                default:
                    this.letterGrade = 'F';
                    break;
            }
        }

        public void AddGrade(double grade) {
            if(grade <= 100 && grade >= 0) {
                this.grades.Add(grade);
            }
            else {
                // Exception thrown
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
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