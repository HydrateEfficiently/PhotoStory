using PhotoStory.Models.Entity.Chapters;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using PhotoModel = PhotoStory.Models.Public.Photos.Photo;

namespace PhotoStory.Models.Entity.Photos {

	public class Photo : Entity<PhotoModel> {

		public int UserID { get; set; }

		public int StoryID { get; set; }

		[ForeignKey("Chapter")]
		public int ChapterID { get; set; }

		public string FileName { get; set; }

		public DateTime UploadTime { get; set; }

		public Chapter Chapter { get; set; }

		public Photo() { }
	}
}
