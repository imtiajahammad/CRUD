using CRUD.DataLayer;
using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeGateway employeeGateway;
        public EmployeeController()
        {
            this.employeeGateway = new EmployeeGateway();
        }
        [HttpGet]
        public ActionResult Index()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            employees = employeeGateway.GetEmployee();
            return View(employees);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel = employeeGateway.GetEmployee(id);
            return View(employeeModel);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeModel employee)
        {
            employeeGateway.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel employeeModel)
        {
            employeeGateway.CreateEmployee(employeeModel);
            return RedirectToAction("Index");
        }
        /*[HttpGet]
        public ActionResult Delete(int id)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel = employeeGateway.GetEmployee(id);
            return View(employeeModel);
        }*/

        //[HttpDelete]
        public ActionResult Delete(int id)
        {
            employeeGateway.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel = employeeGateway.GetEmployee(id);
            return View(employeeModel);
        }
    }
}