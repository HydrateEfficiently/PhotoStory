using System;

namespace PhotoStory.Models.Account {

	public enum UserLevel {

		Unknown = 0,

		Standard = 1,

		Administrator = 2
	}

	public class UserLevelString {

		public static string Get(UserLevel userLevel) {
			switch (userLevel) {
				case UserLevel.Standard:
					return "Standard user";
				case UserLevel.Administrator:
					return "Administrator";
				default:
					throw new Exception("Unrecognised UserLevel");
			}
		}
	}
}
