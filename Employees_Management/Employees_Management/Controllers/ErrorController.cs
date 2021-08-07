using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Authorization;
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

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var ExeptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExeptionPath = ExeptionDetails.Path;
            ViewBag.ExeptionMessage = ExeptionDetails.Error.Message;
            ViewBag.ExpetionStackTrace = ExeptionDetails.Error.StackTrace;
            return View("Error");
        }
    }
}
