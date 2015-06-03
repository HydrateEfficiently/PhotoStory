using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStoryProgram {

	class Program {

		static void Main(string[] args) {
			var entity = new PhotoStory.Data.Relational.Entities.Users.User(new PhotoStory.Models.Users.User() {
				Id = 5,
				UserName = "michael.fry",
				FirstName = "Michael",
				LastName = "Fry"
			});

			var model = entity.ToModel();
		}
	}
}
