using PhotoStory.Models.Photos;
using PhotoStory.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PhotoStory.ViewModels.Photos {

	public class Photo_ToUpload : ViewModel<Photo> {

		[ModelMapping]
		public int UserID { get; set; }

		[ModelMapping]
		public int StoryID { get; set; }

		[ModelMapping]
		public int ChapterID { get; set; }

		public Photo_ToUpload() { }

		public Photo_ToUpload(Photo model) : base(model) { }
	}
}
