using PhotoStory.Models.Photos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.Models.Chapters {

	public class Chapter : Model {

		public int StoryID { get; set; }

		public int UserID { get; set; }

		public string ChapterName { get; set; }

		public ChapterStatus ChapterStatus { get; set; }

		public DateTime? StartTime { get; set; }

		public DateTime? LastDraftSavedTime { get; set; }

		public IEnumerable<int> PhotoIDs { get; set; }

		public Chapter() {
			ChapterStatus = ChapterStatus.NotStarted;
		}

		public void Start() {
			ChapterStatus = ChapterStatus.Started;
			StartTime = DateTime.UtcNow;
		}

		public void SaveDraft() {
			ChapterStatus = ChapterStatus.DraftSaved;
			LastDraftSavedTime = DateTime.UtcNow;
		}
	}
}
