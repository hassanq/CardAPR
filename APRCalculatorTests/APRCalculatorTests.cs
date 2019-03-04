
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Finance.Tests.Unit
{
    [TestClass]
    public class APRCalculatorTests
    {
        [TestMethod]
        public void OneAdvanceWithOnePaymentForOneYearReturnsOnePercent()
        {
            var calculator = new CalculateCardAPR(100);
            calculator.AddPayment(101, 365);
            var apr = calculator.Calculate();

            Assert.AreEqual(1.0d, apr);
        }

        [TestMethod]
        public void OneAdvanceWithOnePaymentOfSameReturnsZero()
        {
            var calculator = new CalculateCardAPR(100);
            calculator.AddPayment(100, 1);
            var apr = calculator.Calculate();

            Assert.AreEqual(0.0d, apr);
        }

        [TestMethod]
        public void Advance100PoundsWithOne125PoundPaymentAfter31Days()
        {
            var calculator = new CalculateCardAPR(100);
            var apr = calculator.SinglePaymentCalculation(125, 31);

            Assert.AreEqual(1286.2d, apr);
        }

        [TestMethod]
        public void CfaBankOverdraftExample()
        {
            var calculator = new CalculateCardAPR(200);
            calculator.AddPayment(350, 365.25 / 12);
            var apr = calculator.Calculate();

            Assert.AreEqual(82400.5d, apr);
        }

        [TestMethod]
        public void CfaExampleOfAPersonalLoan()
        {
            var calculator = new CalculateCardAPR(10000);
            calculator.AddRegularPayment(222.44, 60, PaymentBase.Monthly);
            var apr = calculator.Calculate();

            Assert.AreEqual(12.7d, apr);
        }

        [TestMethod]
        public void CfaExampleOfAShortTermLoanLoan()
        {
            var calculator = new CalculateCardAPR(200);
            calculator.AddPayment(250, 365.25 / 12);
            var apr = calculator.Calculate();

            Assert.AreEqual(1355.2d, apr);
        }

        [TestMethod]
        public void SingleInstalmentExample1()
        {
            var calculator = new CalculateCardAPR(250);
            calculator.AddPayment(319.97, 28);
            var apr = calculator.Calculate();

            Assert.AreEqual(2400.3, apr);
        }

        [TestMethod]
        public void SingleInstalmentExample2()
        {
            var calculator = new CalculateCardAPR(350);
            calculator.AddPayment(447.97, 23);
            var apr = calculator.Calculate();

            Assert.AreEqual(4935.9, apr);
        }

        [TestMethod]
        public void SingleInstalmentExample3()
        {
            var calculator = new CalculateCardAPR(150);
            calculator.AddPayment(191.99, 36);
            var apr = calculator.Calculate();

            Assert.AreEqual(1123.2, apr);
        }

        [TestMethod]
        public void SingleInstalmentExample4()
        {
            var calculator = new CalculateCardAPR(100);
            calculator.AddPayment(127.99, 26);
            var apr = calculator.Calculate();

            Assert.AreEqual(3103.4, apr);
        }

        [TestMethod]
        public void SingleInstalmentExample5()
        {
            var calculator = new CalculateCardAPR(280);
            calculator.AddPayment(358.40, 25);
            var apr = calculator.Calculate();

            Assert.AreEqual(3584.2, apr);
        }

        [TestMethod]
        public void SingleInstalmentExample6()
        {
            var calculator = new CalculateCardAPR(400);
            calculator.AddPayment(511.96, 36);
            var apr = calculator.Calculate();

            Assert.AreEqual(1122.9, apr);
        }

        [TestMethod]
        public void SingleInstalmentExample7()
        {
            var calculator = new CalculateCardAPR(250);
            calculator.AddPayment(319.97, 27);
            var apr = calculator.Calculate();

            Assert.AreEqual(2716.8, apr);
        }

        [TestMethod]
        public void SingleInstalmentExample8()
        {
            var calculator = new CalculateCardAPR(150);
            calculator.AddPayment(191.99, 9);
            var apr = calculator.Calculate();

            Assert.AreEqual(2238723.9, apr);
        }

        [TestMethod]
        public void SingleInstalmentExample9()
        {
            var calculator = new CalculateCardAPR(200);
            calculator.AddPayment(255.98, 27);
            var apr = calculator.Calculate();

            Assert.AreEqual(2717.4, apr);
        }

        [TestMethod]
        public void SingleInstalmentExample10()
        {
            var calculator = new CalculateCardAPR(300);
            calculator.AddPayment(383.97, 16);
            var apr = calculator.Calculate();

            Assert.AreEqual(27865.8, apr);
        }

        [TestMethod]
        public void SingleInstalmentExample11()
        {
            var calculator = new CalculateCardAPR(364.54);
            calculator.AddPayment(450.00, 30);
            var apr = calculator.Calculate();

            Assert.AreEqual(1199, apr);
        }

        [TestMethod]
        public void SingleInstalmentExample12()
        {
            var calculator = new CalculateCardAPR(250);
            calculator.AddPayment(319.98, 16);
            var apr = calculator.Calculate();

            Assert.AreEqual(27875.8, apr);
        }      
    }
}
