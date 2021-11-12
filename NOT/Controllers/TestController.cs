using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NOT.Controllers
{

    [Authorize]
    public class TestController : Controller
    {

        // GET: Test  
        public ActionResult Identita()
        {
            ViewBag.Message = "We are using Identity";

            return View();
            //return Content("We are using Identity");
        }

        [AllowAnonymous]
        public ActionResult NonIdentita()
        {
            ViewBag.Message = "We are not using Identity";

            return View();
            //return Content("We are not using Identity");
        }
    }
}