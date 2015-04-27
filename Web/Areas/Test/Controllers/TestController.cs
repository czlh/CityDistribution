using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Test.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        // GET: Test/Test
        public ActionResult List()
        {
            return View();
        }
    }
}