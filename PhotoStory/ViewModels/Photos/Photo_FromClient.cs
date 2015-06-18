using PhotoStory.Models.Photos;
using PhotoStory.Util.SubModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PhotoStory.ViewModels.Photos {

	public class Photo_FromClient : ViewModel<Photo> {

		[ModelMapping]
		public int UserID { get; set; }

		[ModelMapping]
		public int StoryID { get; set; }

		[ModelMapping]
		public int ChapterID { get; set; }

		public Photo_FromClient() { }

		public Photo_FromClient(Photo model) : base(model) { }
	}
}
