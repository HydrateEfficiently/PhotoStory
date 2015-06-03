using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserEntity = PhotoStory.Data.Relational.Entities.Users.User;

namespace PhotoStory.Models.Users {

	public class User {

		public int Id { get; set; }

		public string UserName { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }
	}
}
