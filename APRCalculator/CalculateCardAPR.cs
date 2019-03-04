
using System;
using System.Collections.Generic;
using System.Linq;
 
namespace Finance
{
    public class CalculateCardAPR : ICard
    {
        private readonly List<Payment> _advances;
        private readonly List<Payment> _payments;

        public CalculateCardAPR(double firstAdvance)
            : this(firstAdvance, new List<Payment>(), new List<Payment>())
        {
        }
 
        internal CalculateCardAPR(double firstAdvance, List<Payment> advances, List<Payment> payments)
        {
            _advances = advances;
            _payments = payments;
            _advances.Add(new Payment() { Amount = firstAdvance, DaysAfterFirstAdvance = 0 });
        }
 
        public double SinglePaymentCalculation(double payment, int daysAfterAdvance)
        {
            return Math.Round((Math.Pow(_advances[0].Amount / payment, (-365.25 / daysAfterAdvance)) - 1) * 100, 1, MidpointRounding.AwayFromZero);
        }
 
        public double Calculate(double guess = 0)
        {
            double rateToTry = guess / 100;
            double difference = 1;
            double amountToAdd = 0.0001d;
 
            while (difference != 0)
            {
                double advances = _advances.Sum(a => a.Calculate(rateToTry));
                double payments = _payments.Sum(p => p.Calculate(rateToTry));

                difference =(payments - advances);
 
                if (difference <= 0.0000001 && difference >= -0.0000001)
                {
                    break;
                }
 
                if (difference > 0)
                {
                    amountToAdd = amountToAdd * 2;
                    rateToTry = rateToTry + amountToAdd;
                }
 
                else
                {
                    amountToAdd = amountToAdd / 2;
                    rateToTry = rateToTry - amountToAdd;
                }
            }
 
            return Math.Round(rateToTry * 100, 1, MidpointRounding.AwayFromZero);
        }
 
        public void AddPayment(double amount, double daysAfterFirstAdvance, PaymentType paymentType = PaymentType.Payment)
        {
            var instalment = new Payment()
            {
                Amount = amount, DaysAfterFirstAdvance = daysAfterFirstAdvance
            };

            switch (paymentType)
            {
                case PaymentType.Payment:
                {
                    _payments.Add(instalment);
                }
                break;
                case PaymentType.Advance:
                {
                    _advances.Add(instalment);
                }
                break;
            }
        }
 
        private static double GetDaysBewteenInstalments(PaymentBase paymentbasis)
        {
            switch (paymentbasis)
            {
                case PaymentBase.Daily:
                {
                    return 1;
                }
                case PaymentBase.Weekly:
                {
                    return 7;
                }
               
                case PaymentBase.Monthly:
                {
                    return 365.25/12;
                }
                case PaymentBase.Quarterly:
                {
                    return 365.25/4;
                }
                case PaymentBase.Annually:
                {
                    return 365.25;
                }
            }

            return 1;
        }
 
        public void AddRegularPayment(double amount, int numberOfInstalments, PaymentBase paymentbasis, double daysAfterFirstAdvancefirstInstalment = 0)
        {
            double daysBetweenInstalments = GetDaysBewteenInstalments(paymentbasis);

            if (daysAfterFirstAdvancefirstInstalment == 0)
            {
                daysAfterFirstAdvancefirstInstalment = daysBetweenInstalments;
            }

            for (int i = 0; i < numberOfInstalments; i++)
            {
                _payments.Add(new Payment() { Amount = amount, DaysAfterFirstAdvance = daysAfterFirstAdvancefirstInstalment + (daysBetweenInstalments * i) });
            }
        }

       
    }
}