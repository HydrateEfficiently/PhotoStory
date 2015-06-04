using PhotoStory.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.Models.Stories {

	public class Story {

		public User User { get; private set; }

		public Story(User user) {
			User = user;
		}

	}
}
