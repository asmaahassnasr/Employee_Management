using Employees_Management.Models;
using Employees_Management.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Employees_Management.Controllers
{
    public class HomeController : Controller
    {
       private  IEmployeeRepository _employeeRepository;
        private IHostingEnvironment hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment _hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            hostingEnvironment = _hostingEnvironment;
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
        public IActionResult Create(CreateEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                string UniqFileName = null;

                if(model.Photos != null && model.Photos.Count > 0)
                {
                    foreach (IFormFile photo  in model.Photos)
                    {
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                        UniqFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        string filePath = Path.Combine(uploadsFolder, UniqFileName);
                        photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    }
                }
                Employee newEmp = new Employee
                {
                    Name=model.Name,
                    Emial=model.Emial,
                    Department=model.Department,
                     PhotoPath=UniqFileName
                };
                _employeeRepository.Add(newEmp);
                return RedirectToAction("details", new { id = newEmp.Id });
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EditEmployeeViewModel editEmployeeViewModel = new EditEmployeeViewModel
            {
                Id=employee.Id,
                Emial=employee.Emial,
                Department=employee.Department,
                Name=employee.Name,
                ExistingPhotoPath=employee.PhotoPath
            };
            return View(editEmployeeViewModel);
        }
    }
}
