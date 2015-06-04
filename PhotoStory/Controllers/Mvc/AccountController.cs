using PhotoStory.Models.Account;
using PhotoStory.ViewModels.Account;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace PhotoStory.Controllers.Mvc {

	[Authorize]
	public class AccountController : BaseController {

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
		public ActionResult Register(User model) {
			if (RegisterAndLogin(model)) {
				return RedirectToAction("Index", "Home");
			} else {
				return View(model);
			}
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

		private bool RegisterAndLogin(User user) {
			if (ModelState.IsValid) {
				try {
					WebSecurity.CreateUserAndAccount(user.UserName, user.Password);
				} catch (MembershipCreateUserException ex) {
					ModelState.AddModelError("", ErrorCodeToString(ex.StatusCode));
				}

				if (ModelState.IsValid) {
					Login(user.UserName, user.Password);
					return true;
				}
			}
			return false;
		}

		private bool Login(User_Login user) {
			return ModelState.IsValid && Login(user.UserName, user.Password);
		}

		private bool Login(string userName, string password) {
			if (WebSecurity.Login(userName, password, true)) {
				PopulateCurrentUser();
				return true;
			}
			return false;
		}

		private string ErrorCodeToString(MembershipCreateStatus createStatus) {
			// See http://go.microsoft.com/fwlink/?LinkID=177550 for
			// a full list of status codes.
			switch (createStatus) {
				case MembershipCreateStatus.DuplicateUserName:
					return "User name already exists. Please enter a different user name.";

				case MembershipCreateStatus.DuplicateEmail:
					return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

				case MembershipCreateStatus.InvalidPassword:
					return "The password provided is invalid. Please enter a valid password value.";

				case MembershipCreateStatus.InvalidEmail:
					return "The e-mail address provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidAnswer:
					return "The password retrieval answer provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidQuestion:
					return "The password retrieval question provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidUserName:
					return "The user name provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.ProviderError:
					return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

				case MembershipCreateStatus.UserRejected:
					return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

				default:
					return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
			}
		}
	}
}
