using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            // Always asks if the parameters passed in is legal or not
            // Arrange Section: Put together test data nad arrange object and values to be used
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // Act Section: Do some computation/invoke a method/do something to produce result
            var result = book.GetStatistics();

            // Assert section: Assert something that was computed inside Act
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1); 
        }
    }
}
