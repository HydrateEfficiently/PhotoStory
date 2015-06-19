using PhotoStory.Models.Public.Photos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoStory.ViewModels.Photos {

	public class Photo_Saved : ViewModel<Photo> {

		public int UserID { get; set; }

		public int StoryID { get; set; }

		public int ChapterID { get; set; }

		public string FileName { get; set; }

		public DateTime UploadTime { get; set; }

		public string Url { get; set; }

		public Photo_Saved() { }

		public Photo_Saved(Photo model) : base(model) { }
	}
}