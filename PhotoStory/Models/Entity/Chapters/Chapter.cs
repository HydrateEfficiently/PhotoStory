using PhotoStory.Models.Entity.Photos;
using PhotoStory.Models.Entity.Stories;
using PhotoStory.Models.Public.Chapters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChapterModel = PhotoStory.Models.Public.Chapters.Chapter;

namespace PhotoStory.Models.Entity.Chapters {

	public class Chapter : Entity<ChapterModel> {

		[Required]
		public int StoryID { get; set; }

		[ForeignKey("StoryID")]
		public virtual Story Story { get; set; }

		public int UserID { get; set; }

		public string ChapterName { get; set; }

		public ChapterStatus ChapterStatus { get; set; }

		public DateTime? StartTime { get; set; }

		public DateTime? LastDraftSavedTime { get; set; }

		public ICollection<Photo> Photos { get; set; }

		public string Blog { get; set; }

		public Chapter() { }

		public Chapter(ChapterModel chapterModel) : base(chapterModel) { }
	}
}
