using PhotoStory.Util.SubModels;
using StoryModel = PhotoStory.Models.Stories.Story;

namespace PhotoStory.Data.Relational.Entities.Stories {

	public class Story : Entity<StoryModel> {

		[ModelMapping]
		public int UserID { get; set; }

		[ModelMapping]
		public int ChapterDraftID { get; set; }

		public Story() { }

		public Story(StoryModel model) : base(model) { }
	}
}
