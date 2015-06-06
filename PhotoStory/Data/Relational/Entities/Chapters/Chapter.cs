using PhotoStory.Models.Chapters;
using PhotoStory.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapterModel = PhotoStory.Models.Chapters.Chapter;

namespace PhotoStory.Data.Relational.Entities.Chapters {

	public class Chapter : Entity<ChapterModel> {

		[ModelMapping("ID")]
		public int ChapterID { get; set; }

		[ModelMapping]
		public int StoryID { get; set; }

		[ModelMapping]
		public string ChapterName { get; set; }

		[ModelMapping]
		public ChapterStatus ChapterStatus { get; set; }

		[ModelMapping]
		public DateTime StartTime { get; set; }

		[ModelMapping]
		public IEnumerable<PhotoStory.Data.Relational.Entities.Photos.Photo> Photos { get; set; } // Should I use entity or model?

		public Chapter() { }

		public Chapter(ChapterModel chapterModel) : base(chapterModel) { }

	}
}
