
using System;

namespace Finance
{
    internal class Payment
    {
        public double Amount { get; set; }
        public double DaysAfterFirstAdvance { get; set; }

        internal double Calculate(double apr)
        {
            var divisor = Math.Pow(1 + apr, DaysToYears);
            var sum = Amount / divisor;

            return sum;
        }

        private double DaysToYears
        {
            get
            {
                return DaysAfterFirstAdvance / 365.25d;
            }
        }
    }
}