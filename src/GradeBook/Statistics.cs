namespace GradeBook
{
    public class Statistics
    {
        public double Average;
        public double High;
        public double Low;

        public Statistics(double average, double high, double low) {
            this.Average = average;
            this.High = high;
            this.Low = low;
        }

        public Statistics() {
            
        }
    }
}