using PhotoStory.Models.Entity;
using PhotoStory.Models.Public.Accounts;
using System;
using System.Threading.Tasks;
using System.Web.Security;
using WebMatrix.WebData;
using UserEntity = PhotoStory.Models.Entity.Accounts.User;
using UserModel = PhotoStory.Models.Public.Accounts.User;

namespace PhotoStory.Controllers.LocalApi {

	public class AccountApi : BaseApi<UserModel, UserEntity> {

		protected override string WorkingDbSetName {
			get {
				return "Users";
			}
		}

		public AccountApi() { }

		public AccountApi(PhotoStoryContext context) : base(context) { }

		public override async Task<UserModel> Post(UserModel user) {
			return await base.Post(
				user,
				customEntityFactory: async () => {
					try {
						WebSecurity.CreateUserAndAccount(user.Email, user.Password);
						user.ID = WebSecurity.GetUserId(user.Email);
						user.DisplayName = user.Email;
						return await base.Put(user.ID, user).ContinueWith(t => {
							return user.ToEntity();
						});

					} catch (MembershipCreateUserException ex) {
						throw new Exception(MembershipCreateStatusString.Get(ex.StatusCode), ex);
					}
				});
		}
	}
}
