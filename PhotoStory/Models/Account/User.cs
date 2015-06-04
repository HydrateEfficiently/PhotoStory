using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.Models.Account {

	public class User {

		public int Id { get; set; }

		[Required]
		public string UserName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
	}
}
