using PhotoStory.Models.Chapters;
using PhotoStory.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.ViewModels.Chapters {

	public class Chapter_SaveDraft : ViewModel<Chapter> {

		[ModelMapping]
		public int ID { get; set; }

		[ModelMapping]
		public int StoryID { get; set; }

		[ModelMapping]
		public int UserID { get; set; }

		public Chapter_SaveDraft() { }

		public Chapter_SaveDraft(Chapter model) : base(model) { }

	}
}
