using PhotoStory.Models.Public.Chapters;
using System;

namespace PhotoStory.ViewModels.Chapters {

	public class Chapter_Draft : ViewModel<Chapter> {

		public int ID { get; set; }

		public int StoryID { get; set; }

		public int UserID { get; set; }

		public string ChapterName { get; set; }

		public DateTime? LastDraftSavedTime { get; set; }

		public string Blog { get; set; }

		public Chapter_Draft() { }

		public Chapter_Draft(Chapter model) : base(model) { }
	}
}
