using System.ComponentModel.DataAnnotations;

namespace PhotoStory.ViewModels.Account {

	public class User_Login {

		[Required]
		public string UserName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		public string Password { get; set; }
	}
}