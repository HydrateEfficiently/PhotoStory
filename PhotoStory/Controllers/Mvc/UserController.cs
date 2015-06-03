using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using UserApi = PhotoStory.Controllers.Api.UserController;

namespace PhotoStory.Controllers.Mvc {

	public class UserController : Controller {

		private UserApi userApi = new UserApi();

		public ActionResult Index() {
			return View("~/Views/Users/Users.cshtml", userApi.GetUsers());
		}
	}
}
