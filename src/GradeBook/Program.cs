using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("FirstBook");
            book.GradeAdded += OnGradeAdded;
            // If Book class expose the GradeAdded member as a delegate, can make direct assignment such as
            // GradeAdded = null;
            // But cannot directly assign to an event field


            var done = false;
            do {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q") {
                    done = true;
                    break;
                }
                try {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                } catch (ArgumentException ex) {
                    // Make sure to catch the specific exception instead of general Exception
                    Console.WriteLine(ex.Message);
                    // re-throw the exception and force it to be caught/program to crash
                    // throw;
                } catch (FormatException ex) {
                    Console.WriteLine(ex.Message);
                } finally {
                    Console.WriteLine("");
                }
                
                
            } while(!done);
            

            // book.AddGrade(89.1);
            // book.AddGrade(90.1);
            // book.AddGrade(100.0);
            book.printGrade();
            Console.WriteLine($"For the book named {book.Name}");
            book.showStatistics();
            // Console.WriteLine($"Highest grade is {book.getHighestGrade():N2}");
            // Console.WriteLine($"Lowest grade is {book.getLowestGrade():N2}");
            // Console.WriteLine($"Average grade is {book.getAverage():N2}");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
