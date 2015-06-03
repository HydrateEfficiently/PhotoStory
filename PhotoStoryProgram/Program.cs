using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStoryProgram {

	class Program {

		static void Main(string[] args) {
			var entity = new PhotoStory.Data.Relational.Entities.Account.User(new PhotoStory.Models.Account.User() {
				Id = 5,
				UserName = "michael.fry"
			});

			var model = entity.ToModel();
		}
	}
}
