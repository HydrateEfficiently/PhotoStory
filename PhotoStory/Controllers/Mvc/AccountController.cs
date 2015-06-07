using PhotoStory.Data.Relational;
using PhotoStory.Models.Account;
using PhotoStory.ViewModels.Account;
using System;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using AccountApi = PhotoStory.Controllers.Api.AccountController;

namespace PhotoStory.Controllers.Mvc {

	[Authorize]
	public class AccountController : BaseController {

<<<<<<< HEAD
		private PhotoStoryContext db = new PhotoStoryContext();
=======
		private AccountApi _accountApi = new AccountApi();
>>>>>>> origin/master

		public ActionResult Index() {
			return View();
		}

		[AllowAnonymous]
		public ActionResult Login(string returnUrl) {
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Login(User_Login model, string returnUrl) {
			if (Login(model)) {
				return RedirectToLocal(returnUrl);
			} else {
				ModelState.AddModelError("", "The user name or password provided is incorrect.");
				return View(model);
			}
		}

		[AllowAnonymous]
		public ActionResult Register() {
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult Register(User_Register user) {
			if (ModelState.IsValid) {
				User userModel = user.ToModel();
				try {
					WebSecurity.CreateUserAndAccount(userModel.UserName, userModel.Password);
				} catch (MembershipCreateUserException ex) {
					ModelState.AddModelError("", MembershipCreateStatusString.Get(ex.StatusCode));
				}

				if (ModelState.IsValid) {
					if (Login(new User_Login(userModel))) {
						return RedirectToAction("Index", "Home");
					} else {
						throw new Exception("TODO: Handle case where user registers successfully but can't login.")
					}					
				}
			}
			return View(user);
		}

		[HttpGet]
		[AllowAnonymous]
		public ActionResult Logout() {
			WebSecurity.Logout();
			return RedirectToAction("Index", "Home");
		}

		private ActionResult RedirectToLocal(string returnUrl) {
			if (Url.IsLocalUrl(returnUrl)) {
				return Redirect(returnUrl);
			} else {
				return RedirectToAction("Index", "Home");
			}
		}

<<<<<<< HEAD
=======
		private bool RegisterAndLogin(User user) {
			var cb = new ControllerBuilder();
			cb.SetControllerFactory(typeof(AccountApi));
			cb.GetControllerFactory().CreateController(Request.RequestContext, "PhotoStory.Controllers.Api.AccountController");

			var api = (AccountApi)ControllerBuilder.Current.GetControllerFactory().CreateController(Request.RequestContext, "PhotoStory.Controllers.Api.AccountController");
				//.CreateController(Request.Reques‌​tContext, controllerName);
			var registeredUser = ApiHelper.GetApiCallResult<User>(() => api.PostUser(user));
			if (ModelState.IsValid) {
				Login(user.UserName, user.Password);
				return true;
			}
			return false;
		}

>>>>>>> origin/master
		private bool Login(User_Login user) {
			if (ModelState.IsValid && WebSecurity.Login(user.UserName, user.Password)) {
				PopulateCurrentUser();
				return true;
			}
			return false;
		}
	}
}
