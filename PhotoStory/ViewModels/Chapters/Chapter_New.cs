using PhotoStory.Models.Chapters;
using PhotoStory.Util.SubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.ViewModels.Chapters {

	public class Chapter_New : ViewModel<Chapter> {

		[ModelMapping]
		public int ID { get; set; }

		[ModelMapping]
		public int StoryID { get; set; }

		[ModelMapping]
		public int UserID { get; set; }

		public Chapter_New() { }

		public Chapter_New(Chapter model) : base(model) { }
	}
}
