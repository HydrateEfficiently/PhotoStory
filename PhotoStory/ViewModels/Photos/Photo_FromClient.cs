using PhotoStory.Models.Public.Photos;

namespace PhotoStory.ViewModels.Photos {

	public class Photo_FromClient : ViewModel<Photo> {

		public int UserID { get; set; }

		public int StoryID { get; set; }

		public int ChapterID { get; set; }

		public Photo_FromClient() { }

		public Photo_FromClient(Photo model) : base(model) { }
	}
}
