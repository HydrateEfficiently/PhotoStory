using PhotoStory.Models.Public.Accounts;
using PhotoStory.Models.Public.Chapters;
using PhotoStory.Models.Public.Stories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.ViewModels.Stories {

	public class Story_Index : ViewModel<Story> {

		public int ID { get; set; }

		public User User { get; set; }

		public Chapter DraftChapter { get; set; }

		public Story_Index(Story story) : base(story) { }
	}
}
