using PhotoStory.Models.Photos;
using PhotoStory.Util.SubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoStory.ViewModels.Photos {

	public class Photo_Saved : ViewModel<Photo> {

		[ModelMapping]
		public int UserID { get; set; }

		[ModelMapping]
		public int StoryID { get; set; }

		[ModelMapping]
		public int ChapterID { get; set; }

		[ModelMapping]
		public string FileName { get; set; }

		[ModelMapping]
		public DateTime UploadTime { get; set; }

		[ModelMapping(ModelMappingDirection: ModelMappingDirection.FromModel)]
		public string Url { get; set; }

		public Photo_Saved() { }

		public Photo_Saved(Photo model) : base(model) { }
	}
}