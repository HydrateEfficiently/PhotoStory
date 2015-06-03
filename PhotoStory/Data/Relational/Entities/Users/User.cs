using PhotoStory.Data.Relational.Entities.Photos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModel = PhotoStory.Models.Users.User;

namespace PhotoStory.Data.Relational.Entities.Users {

	public class User : Entity<UserModel> {

		[ModelMapping("Id")]
		public int UserID { get; set; }

		[ModelMapping]
		public string UserName { get; set; }

		[ModelMapping]
		public string FirstName { get; set; }

		[ModelMapping]
		public string LastName { get; set; }

		public virtual ICollection<Photo> Photos { get; set; }

		public User() { }

		public User(UserModel userModel) : base(userModel) { }
	}
}
