
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using PhotoStory.Data.Relational.Entities.Users;
using PhotoStory.Data.Relational.Entities.Photos;

namespace PhotoStory.Data.Relational {

	public class PhotoStoryInitializer : DropCreateDatabaseIfModelChanges<PhotoStoryContext> {

		protected override void Seed(PhotoStoryContext context) {
			new List<User> {
				new User() { UserName = "Michael", FirstName = "Michael", LastName = "Fry" },
				new User() { UserName = "Liz", FirstName = "Liz", LastName = "Gilchrist" }
			}.ForEach(u => context.Users.Add(u));
			context.SaveChanges();

			new List<Photo> {
				new Photo() { FileName = "test.jpg", Key = "0/test.jpg", UploadTime = DateTime.Now, UserID = 1 }
			}.ForEach(p => context.Photos.Add(p));
			context.SaveChanges();
		}

	}
}
