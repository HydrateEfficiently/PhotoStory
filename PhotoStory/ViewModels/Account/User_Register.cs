using PhotoStory.Models.Public.Accounts;
using System.ComponentModel.DataAnnotations;

namespace PhotoStory.ViewModels.Account {

	public class User_Register : ViewModel<User> {

		[Required]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		public string Password { get; set; }

		public User_Register() { }

		public User_Register(User model) : base(model) { }
	}
}
