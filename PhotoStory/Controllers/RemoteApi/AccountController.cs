using PhotoStory.Controllers.LocalApi;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using UserEntity = PhotoStory.Data.Relational.Entities.Account.User;
using UserModel = PhotoStory.Models.Account.User;

namespace PhotoStory.Controllers.Api {

	public class AccountController : BaseApiController<UserModel, UserEntity> {

		protected override BaseApi<UserModel, UserEntity> GetApi() {
			return new AccountApi();
		}

		// GET: api/User
		public IEnumerable<UserModel> GetUsers() {
			return GetAll();
		}

		// GET: api/User/5
		[ResponseType(typeof(UserModel))]
		public async Task<IHttpActionResult> GetUser(int id) {
			return await Get(id);
		}

		// PUT: api/User/5
		[ResponseType(typeof(void))]
		public async Task<IHttpActionResult> PutUser(int id, UserModel user) {
			return await Put(id, user);
		}

		// POST: api/User
		[ResponseType(typeof(UserModel))]
		public async Task<IHttpActionResult> PostUser(UserModel user) {
			return await Post(user);
		}

		// DELETE: api/User/5
		[ResponseType(typeof(UserModel))]
		public async Task<IHttpActionResult> DeleteUser(int id) {
			return await Delete(id);
		}
		
	}
}