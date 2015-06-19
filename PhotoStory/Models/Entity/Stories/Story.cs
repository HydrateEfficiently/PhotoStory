using PhotoStory.Models.Entity.Accounts;
using PhotoStory.Models.Entity.Chapters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StoryModel = PhotoStory.Models.Public.Stories.Story;

namespace PhotoStory.Models.Entity.Stories {

	public class Story : Entity<StoryModel> {

		[Required]
		public int UserID { get; set; }

		public int? DraftChapterID { get; set; }

		[ForeignKey("UserID")]
		public virtual User User { get; set; }

		[ForeignKey("DraftChapterID")]
		public virtual Chapter DraftChapter { get; set; }
		
		[InverseProperty("Story")]
		public virtual ICollection<Chapter> Chapters { get; set; }

		public Story() { }
	}
}
