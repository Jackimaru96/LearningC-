using System;
using Xunit;

namespace GradeBook.Tests {
    public class TypeTests {
        
        /** 
         * Reference Type
         */

        //====================================== Referencing Different Objects ======================================
        // Prove a Fact so use Fact to identify Unit Tests
        [Fact]
        // Testing whether instantiated Book is a same object or not (How GetBook behaves)
        public void GetBookReturnsDifferentObjects() {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            // Assert that book1 and book2 are not the same instance 
            Assert.NotSame(book1, book2);
        }

        //====================================== Referencing Same Objects ======================================
        [Fact]
        // Testing whether two variables can reference the same object
        public void TwoVarsCanReferenceSameObject() {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            // Assert.Same checks if the two objects are the same instance  
            Assert.Same(book1, book2);
            // Behind the scenes for Assert.Same
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        // Not a Unit Test, just a method used by Unit Test
        Book GetBook(string name) {
            return new Book(name);
        }

        //====================================== Pass By Value ======================================
         [Fact]
        // Testing whether instantiated Book is a same object or not
        // Passing parameter to a method, you are passing *parameter by value.*
        // book1 and book are pointers to the same memory location. book is a copy of book1
        // C# is passing parameter by value (only taking value in Book1 and pasting into parameter book)
        // If pass by reference, one can make changes to book1 variable from the other method
        public void CanSetNameFromReference() {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            // Does not change the value/reference of book1
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name) {
            book.Name = name;
        }

        [Fact]
        public void CSharpIsPassByValue() {
            var book1 = GetBook("Book 1");
            // Made a copy of the value that is inside variable book1
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name) {
            // book is referencing a different memory location compared to book1
            book = new Book(name);
            book.Name = name;
        }

        //====================================== Pass By Reference ======================================
         [Fact]
        public void CSharpCanPassByRef() {
            var book1 = GetBook("Book 1");
            // Made a copy of the value that is inside variable book1
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref Book book, string name) {
            // book is referencing a different memory location compared to book1
            book = new Book(name);
        }

        /**
         * Value Types: Integers, Floating Point Numbers, DateTime and Booleans etc.
         */
        [Fact]
         public void Test1() {
            var x = GetInt();
            SetInt(x);
            // Value of x is still 3; even trying to make it 42 using SetInt
            Assert.Equal(3, x);
            // Using ref keyword allows x to be changed in another method
            SetInt(ref x);
            Assert.Equal(42, x);
         }

        private void SetInt(ref int z) {
            z = 42;
        }
        
        private void SetInt(int z) {
            z = 42;
        }

        private int GetInt() {
            return 3;
        }

        //====================================== Strings are reference type ======================================
        // Strings are immutable
        [Fact] 
        public void StringsBehaveLikeValueTypes() {
            string name = "Jack";
            var upper = MakeUppercase(name);

            Assert.Equal("Jack", name);
            Assert.Equal("JACK", upper);
                
        } 
        
        private string MakeUppercase(string parameter) {
            return parameter.ToUpper();
        }


        /**
         * Delegates
         */
        // Example of Delegate
        public delegate string WriteLogDelegate(string logMessage);
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log;
            log = ReturnMessage;

            var result = log("Hello");
            // count = 1
            Assert.Equal("Hello", result);

            log += ReturnMessage;
            log += IncrementCount;
            
            // ReturnMessage will execute twice and IncrementCount once; count += 3; resulting count is 4
            result = log("Bye");
            Assert.Equal(4, count);
        }

       string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
    }
}
