using PhotoStory.Models.Account;
using PhotoStory.Models.Chapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.Models.Stories {

	public class Story : Model {

		public int UserID { get; set; }

		public User User { get; set; }

		public int ChapterDraftID { get; set; }

		public Chapter ChapterDraft { get; set; }

		public IEnumerable<Chapter> Chapters { get; set; }

		public Story() { }

	}
}
