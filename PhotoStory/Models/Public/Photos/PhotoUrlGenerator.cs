using PhotoStory.Data.Static;
using System;
using System.Collections.Generic;

namespace PhotoStory.Models.Public.Photos {

	public class PhotoUrlGenerator {

		public static string GenerateUrl(Photo photo) {
			return string.Format("{0}/{1}", RepositorySettings.RootUrl, GenerateKey(photo));
		}

		public static string GenerateKey(Photo photo) {
			return string.Format("{0}/{1}_{2}", GenerateDirectoryKey(photo), photo.ID, photo.FileName);
		}

		public static string GenerateDirectoryKey(Photo photo) {
			ValidatePhoto(photo);
			return string.Join("/", new List<object>() {
				photo.UserID,
				photo.StoryID,
				photo.ChapterID,
				photo.ID
			}.ConvertAll(x => x.ToString()));
		}

		private static void ValidatePhoto(Photo photo) {
			CheckId(photo.UserID);
			CheckId(photo.StoryID);
			CheckId(photo.ChapterID);
			CheckId(photo.ID);
			if (string.IsNullOrEmpty(photo.FileName)) {
				throw new Exception("Photo must have a valid file name");
			}
		}

		private static void CheckId(int id) {
			if (id < 1) {
				throw new Exception("UserID, StoryID, ChapterID and ID of Photo must be valid to generate key");
			}
		}
	}
}