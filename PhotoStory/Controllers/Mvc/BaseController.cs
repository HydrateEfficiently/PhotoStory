using PhotoStory.Data.Relational;
using PhotoStory.Models.Public.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace PhotoStory.Controllers.Mvc {

	public abstract class BaseController : Controller {

		private PhotoStoryContext _context;
		private User _currentUser;

		protected PhotoStoryContext CurrentContext {
			get {
				return _context;
			}
		}

		protected User CurrentUser {
			get {
				return _currentUser;
			}
		}

		protected BaseController() {
			_context = new PhotoStoryContext();
			PopulateCurrentUser();
		}

		protected void PopulateCurrentUser() {
			_currentUser = WebSecurity.HasUserId ? _context.Users.Find(WebSecurity.CurrentUserId).ToModel() : null;
			ViewData["User"] = _currentUser;
		}
	}
}
