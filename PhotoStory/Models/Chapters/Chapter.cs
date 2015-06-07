using PhotoStory.Models.Photos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.Models.Chapters {

	public class Chapter {

		public int ID { get; set; }

		public int StoryID { get; set; }

		public int UserID { get; set; }

		public string ChapterName { get; set; }

		public ChapterStatus ChapterStatus { get; set; }

		public DateTime StartTime { get; set; }

		public IEnumerable<Photo> Photos { get; set; }

		public Chapter() {
			ChapterStatus = ChapterStatus.Started;
			StartTime = DateTime.Now;
		}

	}
}
