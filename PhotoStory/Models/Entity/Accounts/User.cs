using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserModel = PhotoStory.Models.Public.Accounts.User;

namespace PhotoStory.Models.Entity.Accounts {

	public class User : Entity<UserModel> {

		public string DisplayName { get; set; }

		public string Email { get; set; }

		public User() { }

		public User(UserModel userModel) : base(userModel) { }

	}
}