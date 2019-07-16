using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRPortal.Models
{
    public partial class Employee
    {
        [RegularExpression("^[SFTG]\\d{7}[A-Z]$")]
        public string nric { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Nullable<decimal> salary { get; set; }


        public Double calculateSalary(Decimal basicPay, Decimal deduction)
        {
            salary = basicPay - deduction;
            return Convert.ToDouble(salary);
         }
     }
}