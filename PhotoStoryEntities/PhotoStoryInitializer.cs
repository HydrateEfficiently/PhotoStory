using PhotoStoryEntities.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStoryEntities {
	public class PhotoStoryInitializer : DropCreateDatabaseIfModelChanges<PhotoStoryContext> {

		protected override void Seed(PhotoStoryContext context) {
			new List<User> {
				new User() {
					Username = "Michael"
				}
			}.ForEach(u => context.Users.Add(u));
			context.SaveChanges();
		}

	}
}
