using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebServer.Areas.Offers.Controllers
{
    public class AppController : Controller
    {
        //
        // GET: /Spa/Offers/
        public ActionResult Main()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
	}
}