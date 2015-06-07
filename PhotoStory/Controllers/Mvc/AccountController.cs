using PhotoStory.Controllers.LocalApi;
using PhotoStory.Models.Account;
using PhotoStory.ViewModels.Account;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace PhotoStory.Controllers.Mvc {

	[Authorize]
	public class AccountController : BaseController {

		private AccountApi _accountApi = new AccountApi();

		public ActionResult Index() {
			return View();
		}

		[AllowAnonymous]
		public ActionResult Login(string returnUrl) {
			ViewBag.ReturnUrl = returnUrl;
			return View("~/Views/Accounts/User_Login.cshtml");
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
			return View("~/Views/Accounts/User_Register.cshtml");
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Register(User_Register user) {
			if (ModelState.IsValid) {
				User initialUserModel = user.ToModel();
				return await _accountApi.Post(user.ToModel()).ContinueWith(task => {
					Login(new User_Login(task.Result));
					return RedirectToAction("Index", "Home");
				});
			}
			return await new Task<ActionResult>(() => {
				return View(user);
			});

			//	Task task = apiClient.Post(initUserModel);
			//	task.Wait();

			//	User userModel = null;

			//	if (userModel != null && ModelState.IsValid) {
			//		if (Login(new User_Login(userModel))) {
			//			return RedirectToAction("Index", "Home");
			//		} else {
			//			throw new Exception("TODO: Handle case where user registers successfully but can't login.");
			//		}					
			//	}
			//}
			//return View(user);
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

		private bool Login(User_Login user) {
			if (ModelState.IsValid && WebSecurity.Login(user.Email, user.Password)) {
				PopulateCurrentUser();
				return true;
			}
			return false;
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				_accountApi.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
