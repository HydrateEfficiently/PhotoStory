﻿using PhotoStory.Data.Relational.Entities.Photos;
using PhotoStory.Util;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserModel = PhotoStory.Models.Account.User;

namespace PhotoStory.Data.Relational.Entities.Account {

	public class User : Entity<UserModel> {

		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		[ModelMapping("ID")]
		public int UserID { get; set; }

		[ModelMapping]
		public string UserName { get; set; }

		[ModelMapping]
		public string Email { get; set; }

		public virtual ICollection<Photo> Photos { get; set; }

		public User() { }

		public User(UserModel userModel) : base(userModel) { }
	}
}
