using CRUDWithDB.Models;
using HelperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayerLibrary;
using System.Globalization;

namespace CRUDWithDB.Controllers
{
    public class NW_EmployeeController : Controller
    {
        Employee_Helper helper = null;
        public NW_EmployeeController()
        {
            helper = new Employee_Helper();
        }
        // GET: NW_Employee
        public ActionResult Index()
        {
            var emplist = helper.ShowEmployeeList();
            List<EmpModel> modelsList = new List<EmpModel>();
            foreach (var item in emplist)
            {
                modelsList.Add(new EmpModel { EmployeeID = item.EmployeeID, FirstName = item.FirstName, LastName = item.LastName, BirthDate = item.BirthDate });
            }

            return View(modelsList);
        }

        // GET: NW_Employee/Details/5
        public ActionResult Details(int id)
        {

            var data=helper.SearchEmployee(id);
            EmpModel emp = new EmpModel();
            emp.EmployeeID = id;
            emp.FirstName = data.FirstName;
            emp.LastName = data.LastName;
            emp.BirthDate = data.BirthDate;
            emp.Title = data.Title;
            return View(emp);
        }

        // GET: NW_Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NW_Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                Employee_BAL bal = new Employee_BAL();
          bal.EmployeeID = Convert.ToInt32(Request["EmployeeID"]);
                bal.FirstName = Request["FirstName"].ToString();
                bal.LastName = Request["LastName"].ToString();
                bal.BirthDate = Convert.ToDateTime(Request["BirthDate"]);
                bal.Title = Request["Title"].ToString();

               bool ans= helper.AddEmployee(bal);
                if (ans)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
                
            }
            catch(Exception ex)
            {
                ViewBag.exMsg = ex.Message;
                return View();
            }
        }

        // GET: NW_Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var emp=helper.SearchEmployee(id);
            EmpModel model = new EmpModel();
                model.EmployeeID = id;
            model.FirstName = emp.FirstName;
            model.LastName = emp.LastName;

            //only date
            model.BirthDate = emp.BirthDate;
           
            //date and time
                /*model.BirthDate=emp.BirthDate.ToUniversalTime();*/



            model.Title = emp.Title;

            return View(model);
        }

        // POST: NW_Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var emp = helper.SearchEmployee(id);
                emp.EmployeeID = Convert.ToInt32(Request["EmployeeID"]);
                emp.FirstName = Request["FirstName"].ToString();
                emp.LastName= Request["LastName"].ToString();
            emp.BirthDate = Convert.ToDateTime(Request["BirthDate"]);
                emp.Title = Request["Title"].ToString();
                bool ans=helper.EditEmployee(emp);


                if (ans)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: NW_Employee/Delete/5
        public ActionResult Delete(int id)
        {
            var emp = helper.SearchEmployee(id);
            EmpModel model = new EmpModel();
            model.EmployeeID = id;
            model.FirstName = emp.FirstName;
            model.LastName = emp.LastName;

            //only date
            model.BirthDate = emp.BirthDate;

            //date and time
            /*model.BirthDate=emp.BirthDate.ToUniversalTime();*/
            model.Title = emp.Title;

            return View(model);
        }

        // POST: NW_Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var dataFound=helper.SearchEmployee(id);
                if (dataFound!=null)
                {
                   bool ans= helper.RemvoeEmployee(id);
                    if (ans)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }
                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
