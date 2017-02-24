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
			using (Connection conn = new Connection()) 
			{
				var model = new Connection().getCountry_all().ToList();
				return View(model);
			}
        }
		public ActionResult getCountry()
		{
			var conn = new Connection();
			var model = conn.getCountry_all();
			conn.Close();
			return Json(model.ToList(), JsonRequestBehavior.AllowGet);
		}
    }
}