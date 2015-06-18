using PhotoStory.Models.Account;
using PhotoStory.Models.Chapters;
using PhotoStory.Models.Stories;
using PhotoStory.Util.SubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.ViewModels.Stories {

	public class Story_Index : ViewModel<Story> {

		[ModelMapping]
		public int ID { get; set; }

		[ModelMapping]
		public User User { get; set; }

		[ModelMapping]
		public Chapter DraftChapter { get; set; }

		public Story_Index(Story story) : base(story) { }
	}
}
