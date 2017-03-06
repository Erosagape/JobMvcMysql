using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobMvcMysql.Controllers
{
    public class CustomsFileController : Controller
    {
        public ActionResult Index()
        {
			ViewBag.Title = "Country";
			var data = new Country();
			var model = data.getCountry_all().ToList();
			return View(model);
        }
		public ActionResult Country()
		{
			ViewBag.Title = "Country Management";
			return View();			
		}
		public ActionResult getCountry()
		{
			var data = new Country();
			var model = data.getCountry_all();
			return Json(model.ToList(), JsonRequestBehavior.AllowGet);
		}
		public ActionResult setCountry(Country data) 
		{
			string msg =data.saveCountry();
			return Content(msg);
		}
    }
}