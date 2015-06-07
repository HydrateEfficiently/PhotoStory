using PhotoStory.Data.Relational;
using UserModel = PhotoStory.Models.Account.User;
using UserEntity = PhotoStory.Data.Relational.Entities.Account.User;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Collections.Generic;
using WebMatrix.WebData;
using System.Web.Security;

namespace PhotoStory.Controllers.Api {

	public class AccountController : ApiController {

		private PhotoStoryContext db = new PhotoStoryContext();

		// GET: api/User
		public IEnumerable<UserModel> GetUsers() {
			return db.Users.ToList().ConvertAll(u => u.ToModel());
		}

		// GET: api/User/5
		[ResponseType(typeof(UserModel))]
		public async Task<IHttpActionResult> GetUser(int id) {
			UserEntity user = await db.Users.FindAsync(id);
			if (user == null) {
				return NotFound();
			}
			return Ok(user.ToModel());
		}

		// PUT: api/User/5
		[ResponseType(typeof(void))]
		public async Task<IHttpActionResult> PutUser(int id, UserModel user) {
			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			}

			if (id != user.ID) {
				return BadRequest();
			}

			db.Entry(user).State = EntityState.Modified;

			try {
				await db.SaveChangesAsync();
			} catch (DbUpdateConcurrencyException) {
				if (!UserExists(id)) {
					return NotFound();
				} else {
					throw;
				}
			}

			return StatusCode(HttpStatusCode.NoContent);
		}

		// POST: api/User
		[ResponseType(typeof(UserModel))]
		public async Task<IHttpActionResult> PostUser(UserModel user) {
			if (ModelState.IsValid) {
				try {
					WebSecurity.CreateUserAndAccount(user.UserName, user.Password);
				} catch (MembershipCreateUserException ex) {
					ModelState.AddModelError("", ErrorCodeToString(ex.StatusCode));
				}
			}

			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			}

			var updatedUser = ApiHelper.GetApiCallResult<UserModel>(() => PutUser(user.ID, user));

			return CreatedAtRoute("DefaultApi", new { id = updatedUser.ID }, updatedUser);
		}

		// DELETE: api/User/5
		[ResponseType(typeof(UserModel))]
		public async Task<IHttpActionResult> DeleteUser(int id) {
			UserEntity userEntity = await db.Users.FindAsync(id);
			if (userEntity == null) {
				return NotFound();
			}

			db.Users.Remove(userEntity);
			await db.SaveChangesAsync();

			return Ok(userEntity.ToModel());
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				db.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool UserExists(int id)	{
			return db.Users.Count(e => e.UserID == id) > 0;
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