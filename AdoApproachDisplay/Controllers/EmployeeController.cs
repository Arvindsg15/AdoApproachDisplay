using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdoApproachDisplay.Models;

namespace AdoApproachDisplay.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        EmployeeContext db = new EmployeeContext();
        public ActionResult Index()
        {
            EmployeeContext db = new EmployeeContext();
            
            return View(db.GetEmployeeDetails());
        }

        [HttpGet]
        public ActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create (EmployeeModel emp)
            
        {
            
            int i = db.CreateEmployee(emp);
            if (i==1)
            {
                ViewBag.RowInserted = "Data Entered Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.RowInserted = "Data Not Inserted";
                return View();
            }
           
        }


        [HttpGet]
        public ActionResult C()
        {
            return View();
        }

        [HttpPost]
        public ActionResult C(EmployeeModel abc)

        {

            int i = db.CreateEmployee(abc);
            if (i == 1)
            {
                ViewBag.RowInserted = "Data Entered Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.RowInserted = "Data Not Inserted";
                return View();
            }

        }

        // Edit funtion

        [HttpGet]
        public ActionResult Edit(int EmpId)
        {

            EmployeeModel obj = db.GetEmployeeDetailsById(EmpId);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel emp)
        {
            int i = db.UpdateEmployee(emp);
            if (i == 1)
            {
                ViewBag.RowInserted = "Data Entered Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.RowInserted = "Data Not Inserted";
                return View();
            }

           
        }

        //[HttpGet]

        //public ActionResult Delete( Int32 EmpId)
        //{
        //    EmployeeModel obj = db.GetEmployeeDetailsById(EmpId);
        //    return View(obj);


        //}
        //[HttpPost]


        //public ActionResult Delete(EmployeeModel EmpId)
        //{

        //    int i = db.DeleteEmployee(EmpId);
        //    if(i>0)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View();
        //    }

        //}

        //[HttpPost]

           
        public ActionResult Delete (int EmpId)
        {

            EmployeeContext db = new EmployeeContext();

            int i = db.DeleteEmployee(EmpId);
            if (i == 1)
            {
                ViewBag.RowDeleted = "Row Deleted successfully";
                //return RedirectToAction("Index");
            }
            else
            {
                ViewBag.RowDeleted = "Failed";
                //return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Lovemusic()
        {
            return View();

        }
    }
}