﻿using System.Data.Entity;

namespace PhotoStory.Models.Entity {

	public class PhotoStoryInitializer : DropCreateDatabaseIfModelChanges<PhotoStoryContext> {

		protected override void Seed(PhotoStoryContext context) {
			//new List<User> {
			//	new User() { UserName = "Michael", Email = "michaelfry2002@gmail.com" },
			//	new User() { UserName = "Liz", Email = "michaelfry2002@gmail.com" }
			//}.ForEach(u => context.Users.Add(u));
			//context.SaveChanges();

			//new List<Photo> {
			//	new Photo() { FileName = "test.jpg", Key = "0/test.jpg", UploadTime = DateTime.Now, UserID = 1 }
			//}.ForEach(p => context.Photos.Add(p));
			//context.SaveChanges();
		}

	}
}
