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

			if (id != user.Id) {
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
			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			}

			var userEntity = new UserEntity(user);
			db.Users.Add(userEntity);
			await db.SaveChangesAsync();

			return CreatedAtRoute("DefaultApi", new { id = userEntity.UserID }, user);
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
	}
}