using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoStory.Models.Public.Accounts {

	public class User : Model {

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