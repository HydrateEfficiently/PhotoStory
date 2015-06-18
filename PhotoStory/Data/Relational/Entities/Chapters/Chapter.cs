using PhotoStory.Data.Relational.Entities.Photos;
using PhotoStory.Data.Relational.Entities.Stories;
using PhotoStory.Models.Chapters;
using PhotoStory.Util.SubModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapterModel = PhotoStory.Models.Chapters.Chapter;

namespace PhotoStory.Data.Relational.Entities.Chapters {

	public class Chapter : Entity<ChapterModel> {

		[ModelMapping]
		[Required]
		public int StoryID { get; set; }

		[ForeignKey("StoryID")]
		public virtual Story Story { get; set; }

		[ModelMapping]
		public int UserID { get; set; }

		[ModelMapping]
		public string ChapterName { get; set; }

		[ModelMapping]
		public ChapterStatus ChapterStatus { get; set; }

		[ModelMapping]
		public DateTime? StartTime { get; set; }

		[ModelMapping]
		public DateTime? LastDraftSavedTime { get; set; }

		[ModelMapping]
		public ICollection<Photo> Photos { get; set; }

		[ModelMapping]
		public string Blog { get; set; }

		public Chapter() { }

		public Chapter(ChapterModel chapterModel) : base(chapterModel) { }
	}
}
