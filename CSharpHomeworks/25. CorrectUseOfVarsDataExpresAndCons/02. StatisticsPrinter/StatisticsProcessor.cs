namespace Statistics
{
    using System;

    public class StatisticsProcessor
    {
        // fields
        private double[] statisticsData;

        // constructors
        public StatisticsProcessor(double[] statisticsData)
        {
            this.StatisticsData = statisticsData;
        }

        // properties
        public double[] StatisticsData
        {
            get
            {
                return this.statisticsData;
            }

            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("The statistics data can not be empty!");
                }

                this.statisticsData = value;
            }
        }

        // methods
        public void PrintMaxValue()
        {
            Console.WriteLine("The max number in the array is: {0}", this.FindMaxValue(this.statisticsData));
        }

        public void PrintMinValue()
        {
            Console.WriteLine("The min number in the array is: {0}", this.FindMinValue(this.statisticsData));
        }

        public void PrintAvgerageValue()
        {
            Console.WriteLine("The average value in the array is: {0}", this.FindAverage(this.statisticsData));
        }

        private double FindMaxValue(double[] numbers)
        {
            double maxValue = double.MinValue;
            int numbersCount = numbers.Length;

            for (int i = 0; i < numbersCount; i++)
            {
                if (numbers[i] > maxValue)
                {
                    maxValue = numbers[i];
                }
            }

            return maxValue;
        }

        private double FindMinValue(double[] numbers)
        {
            double minValue = double.MaxValue;
            int numbersCount = numbers.Length;

            for (int i = 0; i < numbersCount; i++)
            {
                if (numbers[i] < minValue)
                {
                    minValue = numbers[i];
                }
            }

            return minValue;
        }

        private double FindAverage(double[] numbers)
        {
            double numbersSum = 0;
            int numbersCount = numbers.Length;

            for (int i = 0; i < numbersCount; i++)
            {
                numbersSum = numbersSum + numbers[i];
            }

            double averageValue = numbersSum / numbersCount;

            return averageValue;
        }
    }
}
