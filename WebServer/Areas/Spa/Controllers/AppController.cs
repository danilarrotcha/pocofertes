using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebServer.Areas.Spa.Controllers
{
    public class AppController : Controller
    {
        //
        // GET: /Spa/Offers/
        public ActionResult Index()
        {
            return View();
        }
	}
}