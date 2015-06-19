using PhotoStory.Models.Public.Photos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PhotoStory.ViewModels.Photos {

	public class Photo_ToSave : ViewModel<Photo> {

		public int UserID { get; set; }

		public int StoryID { get; set; }

		public int ChapterID { get; set; }

		public string FileName { get; set; }

		public DateTime UploadTime { get; set; }

		public Stream InputStream { get; set; }

		public string Url { get; set; }

		public Photo_ToSave() { }

		public Photo_ToSave(Photo model) : base(model) { }

		public Photo_ToSave(Photo_FromClient photoFromClient, HttpPostedFileBase file) {
			UserID = photoFromClient.UserID;
			StoryID = photoFromClient.StoryID;
			ChapterID = photoFromClient.ChapterID;
			FileName = file.FileName;
			InputStream = file.InputStream;
			UploadTime = DateTime.Now;
		}
	}
}