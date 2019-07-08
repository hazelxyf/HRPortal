using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HRPortal.Models;

namespace EmployeeLogicTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SalaryCalculationTest()
        {
            //Arrange
            Employee testEmployee = new Employee();
            decimal testBasicPay = 1000;
            decimal testDeduction = 500;
            double ExpectedSalary = 500;

            //Act
            double CalculatedSalary = testEmployee.calculateSalary(testBasicPay, testDeduction);

            //Assert
            Assert.AreEqual(ExpectedSalary, CalculatedSalary);
        }
    }
}
