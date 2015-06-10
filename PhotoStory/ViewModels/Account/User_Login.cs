using PhotoStory.Models.Account;
using PhotoStory.Util.SubModels;
using System.ComponentModel.DataAnnotations;

namespace PhotoStory.ViewModels.Account {

	public class User_Login : ViewModel<User> {

		[Required]
		[ModelMapping]
		public string UserName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[ModelMapping]
		public string Password { get; set; }

		public User_Login() { }

		public User_Login(User model) : base(model) { }

		public User_Login(User_Register userRegister) {
			UserName = userRegister.Email;
			Password = userRegister.Password;
		}
	}
}