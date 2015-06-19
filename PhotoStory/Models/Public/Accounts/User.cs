using System.ComponentModel.DataAnnotations;
using UserEntity = PhotoStory.Models.Entity.Accounts.User;

namespace PhotoStory.Models.Public.Accounts {

	public class User : Model<UserEntity> {

		public string DisplayName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		public string ProfileImageUrl { get; set; }

		public User() {
			ProfileImageUrl = "~/Content/default-profile.jpg";
		}

	}
}