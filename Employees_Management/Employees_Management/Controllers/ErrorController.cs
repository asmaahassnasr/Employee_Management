using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_Management.Controllers
{
    public class ErrorController : Controller 
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {

            var StatusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();


            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry!, The resource you requested not found";
                    ViewBag.Path = StatusCodeResult.OriginalPath;
                    ViewBag.QS = StatusCodeResult.OriginalQueryString;
                    break;
            }
            return View("NotFound");
        }
    }
}
