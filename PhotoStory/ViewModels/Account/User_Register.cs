using PhotoStory.Models.Account;
using PhotoStory.Util;
using System.ComponentModel.DataAnnotations;

namespace PhotoStory.ViewModels.Account {

	public class User_Register : ViewModel<User> {

		[Required]
		[ModelMapping]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[ModelMapping]
		public string Password { get; set; }

		public User_Register() { }

		public User_Register(User model) : base(model) { }
	}
}
