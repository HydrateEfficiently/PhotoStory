using PhotoStory.Models.Public.Chapters;

namespace PhotoStory.ViewModels.Chapters {

	public class Chapter_New : ViewModel<Chapter> {

		public int ID { get; set; }

		public int StoryID { get; set; }

		public int UserID { get; set; }

		public Chapter_New() { }

		public Chapter_New(Chapter model) : base(model) { }
	}
}
