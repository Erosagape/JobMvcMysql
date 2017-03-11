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
			var model = data.get().ToList();
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
			var model = data.get();
			return Json(model.ToList(), JsonRequestBehavior.AllowGet);
		}
		public ActionResult setCountry(Country data)
		{
			string msg = data.save();
			return Content(msg);
		}
		public ActionResult deleteCountry(int oid)
		{
			var data = new Country();
			return Content(data.delete(oid));
		}
		public ActionResult Currency()
		{
			ViewBag.Title = "Currency Management";
			return View();
		}
		public ActionResult getCurrency()
		{
			var data = new Currency();
			var model = data.get();
			return Json(model.ToList(), JsonRequestBehavior.AllowGet);
		}
		public ActionResult setCurrency(Currency data)
		{
			string msg = data.save();
			return Content(msg);
		}
		public ActionResult deleteCurrency(string oid)
		{
			var data = new Currency();
			return Content(data.delete(oid));
		}
		public ActionResult InterPort()
		{
			ViewBag.Title = "InterPort Management";
			return View();
		}
		public ActionResult getInterPort()
		{
			var data = new InterPort();
			var model = data.get();
			if (Request.QueryString["country"] != null)
			{
				model = model.Where(e => e.CountryCode.Equals(Request.QueryString["country"])).ToList();
			}
			return Json(model.ToList(), JsonRequestBehavior.AllowGet);
		}
		public ActionResult setInterPort(InterPort data)
		{
			string msg = data.save();
			return Content(msg);
		}
		public ActionResult deleteInterPort(string oid)
		{
			var data = new InterPort();
			return Content(data.delete(oid));
		}
	}
}