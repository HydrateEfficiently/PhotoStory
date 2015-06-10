using System;
using System.Collections.Generic;

namespace PhotoStory.Models.Photos {

	public class PhotoKeyGenerator {

		public static string GenerateKey(Photo photo) {
			ValidatePhoto(photo);
			string directoryKey = string.Join("/", new List<object>() {
				photo.UserID,
				photo.StoryID,
				photo.ChapterID,
				photo.ID
			}.ConvertAll(x => x.ToString()));
			return string.Format("{0}/{1}_{2}", directoryKey, photo.ID, photo.FileName);
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