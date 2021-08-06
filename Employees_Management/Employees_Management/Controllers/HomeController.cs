using Employees_Management.Models;
using Employees_Management.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_Management.Controllers
{
    public class HomeController : Controller
    {
       private  IEmployeeRepository _employeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployees();
            return View(model);
        }
        //If we need to return json formate
        //public JsonResult Details()
        //{
        //    Employee model = _employeeRepository.GetEmployee(1);
        //    return Json(model);
        //}

        // Return view to display to the user 

        //[Route("Home/Details/{id?}")]
        public ViewResult Details(int? id)
        {

            //Employee model = _employeeRepository.GetEmployee(3);
            //using ViewData ["Key"]
            //ViewData["Employee"]= model;
            //ViewData["PageTitle"] = " Emplyee Details page ";

            //By Using ViewBag.Propert
            // ViewBag.Employee= model;
            //ViewBag.PageTitle = " Emplyee Details page ";

            // passing model to the view to be strongly typed view 
            //return View(model);

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id??1),
                PageTitle = "Employee Details Page "
            };
            return View(homeDetailsViewModel);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee model = _employeeRepository.Add(employee);
                return RedirectToAction("details", new { id = model.Id });
            }
            return View();
        }
    }
}
