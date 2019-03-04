using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance
{
   public interface ICard
    {
        double Calculate(double apr);
        void AddPayment(double amount, double daysAfterFirstAdvance, PaymentType paymentType = PaymentType.Payment);
        void AddRegularPayment(double amount, int numberOfInstalments, PaymentBase paymentbasis, double daysAfterFirstAdvancefirstInstalment = 0);
        double SinglePaymentCalculation(double payment, int daysAfterAdvance);
        
       
    }
}
