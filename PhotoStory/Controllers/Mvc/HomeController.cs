using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoStory.Controllers.Mvc {

	public class HomeController : Controller {

		public ActionResult Index() {
			return RedirectToAction("Login", "Account");
		}
	}
}
