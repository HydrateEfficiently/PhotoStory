using PhotoStory.Data.Relational;
using PhotoStory.Models.Account;
using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Security;
using WebMatrix.WebData;
using UserEntity = PhotoStory.Data.Relational.Entities.Account.User;
using UserModel = PhotoStory.Models.Account.User;

namespace PhotoStory.Controllers.LocalApi {

	public class AccountApi : BaseApi<UserModel, UserEntity> {

		protected override DbSet<UserEntity> GetDbSetForEntity(PhotoStoryContext context) {
			return context.Users;
		}

		public override async Task<UserModel> Post(UserModel user) {
			return await base.Post(
				user,
				customEntityFactory: async () => {
					try {
						WebSecurity.CreateUserAndAccount(user.Email, user.Password);
						user.ID = WebSecurity.GetUserId(user.Email);
						user.UserName = user.Email;
						return await base.Put(user.ID, user).ContinueWith(t => {
							return new UserEntity(user);
						});

					} catch (MembershipCreateUserException ex) {
						throw new Exception(MembershipCreateStatusString.Get(ex.StatusCode), ex);
					}
				});
		}
	}
}
