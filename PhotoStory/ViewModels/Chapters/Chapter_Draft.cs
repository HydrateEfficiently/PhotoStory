using PhotoStory.Models.Chapters;
using PhotoStory.Util.SubModels;
using System;

namespace PhotoStory.ViewModels.Chapters {

	public class Chapter_Draft : ViewModel<Chapter> {

		[ModelMapping]
		public int ID { get; set; }

		[ModelMapping]
		public int StoryID { get; set; }

		[ModelMapping]
		public int UserID { get; set; }

		[ModelMapping]
		public string ChapterName { get; set; }

		[ModelMapping]
		public DateTime? LastDraftSavedTime { get; set; }

		[ModelMapping]
		public string Blog { get; set; }

		public Chapter_Draft() { }

		public Chapter_Draft(Chapter model) : base(model) { }

	}
}
