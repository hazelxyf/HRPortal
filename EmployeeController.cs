using HRPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace HRPortal.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
      
        NTUCDBEntities NTUCDatabase = new NTUCDBEntities();
        public ActionResult Index()
        {
            //var listofEmployees = from emp in GetEmployees()
            //                      orderby emp.EmployeeName
            //                      select emp;
            return View();
        }

        public ActionResult SearchEmployee(String searchIdentifer)
        {
            ViewBag.searchKey = searchIdentifer;
            return View();
        }

        public ActionResult DisplayAllEmployees()
        {
            var listofEmployees = from empRec in NTUCDatabase.Employees
                                  orderby empRec.employeename
                                  select empRec;
            return View(listofEmployees);
        }

        public ActionResult DisplayAllEmployeesFromWebAPI()
        {
            return View();
        }

        public ActionResult DisplayAllEmployeesFromWebAPIServerSide()
        {
           using (var client = new HttpClient())
            {
                String wsURI = "http://localhost:57168/api/EmloyeesCloudData/1001";
                //HTTP GET
                var responseTask = client.GetAsync(wsURI);
                //submit an async request. Dont block other code executions
                responseTask.Wait();

                //Get the response from the web Api if there's an error send a 400 error code
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode) 
                {

                    var readTask = result.Content.ReadAsAsync<Employee>();
                    readTask.Wait();

                   ViewBag.employeeRecord = readTask.Result;
                   
                 }
                
            }
            return View();
        }

        


        public ActionResult DisplaySpecificEmployees(int empId)
        {
            var listofEmployees = from empRec in NTUCDatabase.Employees
                                  where empRec.employeeid == empId
                                  orderby empRec.employeename
                                  select empRec;
            return View(listofEmployees);
        }


        //public List<Employee> GetEmployees()
        //{
        //    return new List<Employee>{
        //        new Employee{
        //           EmployeeId  = 1001,
        //            EmployeeName = "Eva Longoria",
        //            Nric = "G1234567W",
        //           Salary = 20000
        //        },

        //         new Employee{
        //             EmployeeId  = 1002,
        //            EmployeeName = "Michael Shepard",
        //            Nric = "G1234568W",
        //           Salary = 20000
        //        }
        //    };
        //   }
    }
}