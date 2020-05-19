using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
        //     double x = 3.1;
        //     double y = 4.6;
        //     // Implicit typing
        //     var z = x + y;
        //     // Method 1: String concatenation
        //     Console.WriteLine("The result is " + z);

        //     // Method 2: String interpolation
        //     //Console.WriteLine($"Hello {args[0]}!");

        //     // Similar to C, need to declare the size of the array
        //     double[] numbers = new[] {12.7, 10.3, 6.11, 4.1};

        //     var result = 0.0;
        //    foreach(double number in numbers) {
        //        result += number;
        //    }
        //     Console.WriteLine("Result from adding in array: " + result);

        //     /**
        //      * Using a List to enumerate through data
        //      */
        //     List<double> grades = new List<double>(); 
        //     grades.Add(15.1);
        //     grades.Add(1.1);

        //     var gradeResult = 0.0;
        //     foreach(var grade in grades) {
        //         gradeResult += grade;
        //     }

        //     var avgResult = gradeResult/grades.Count;

        //     Console.WriteLine($"Average result is {avgResult:N2}");
            Book book = new Book("FirstBook");
            book.AddGrade(89.1);
            book.AddGrade(90.1);
            book.AddGrade(100.0);
            book.printGrade();
            book.showStatistics();
            // Console.WriteLine($"Highest grade is {book.getHighestGrade():N2}");
            // Console.WriteLine($"Lowest grade is {book.getLowestGrade():N2}");
            // Console.WriteLine($"Average grade is {book.getAverage():N2}");
        }
    }
}
