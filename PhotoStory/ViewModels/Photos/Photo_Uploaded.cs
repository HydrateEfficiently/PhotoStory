using PhotoStory.Models.Photos;
using PhotoStory.Util.SubModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PhotoStory.ViewModels.Photos {

	public class Photo_Uploaded : ViewModel<Photo> {

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

		[ModelMapping(modelMappingType: ModelMappingType.ConstructorParameter)]
		public Stream InputStream { get; set; }

		public string Url { get; set; }

		public Photo_Uploaded() { }

		public Photo_Uploaded(Photo model) : base(model) {
			Url = model.Url; // Only map Url from model to viewmodel, not vice versa.
		}

		public Photo_Uploaded(Photo_ToUpload photoToUpload, HttpPostedFileBase file) {
			FileName = file.FileName;
			InputStream = file.InputStream;
			UploadTime = DateTime.Now;
		}
	}
}