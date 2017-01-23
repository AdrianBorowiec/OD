using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OD.Infrastructure
{
    public class CustomExeptions : Controller
    {
        public ActionResult CustomHttpRequestValidationException()
        {
            ModelState.AddModelError(string.Empty, "Oj oj, bardzo nieładne zachowanie koleżko! Oby to się więcej nie powtórzyło!");
            return RedirectToAction("SignIn", "Customer");
        }
    }
}