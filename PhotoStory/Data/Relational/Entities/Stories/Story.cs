using PhotoStory.Data.Relational.Entities.Chapters;
using PhotoStory.Util.SubModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StoryModel = PhotoStory.Models.Stories.Story;

namespace PhotoStory.Data.Relational.Entities.Stories {

	public class Story : Entity<StoryModel> {

		[ModelMapping]
		public int UserID { get; set; }

		[ModelMapping]
		public int? DraftChapterID { get; set; }

		[ModelMapping]
		[ForeignKey("DraftChapterID")]
		public virtual Chapter DraftChapter { get; set; }
		
		[InverseProperty("Story")]
		public virtual ICollection<Chapter> Chapters { get; set; }

		public Story() { }

		public Story(StoryModel model) : base(model) { }
	}
}
