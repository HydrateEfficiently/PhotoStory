﻿using PhotoStory.Models.Public.Accounts;
using PhotoStory.Models.Public.Chapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoryEntity = PhotoStory.Models.Entity.Stories.Story;

namespace PhotoStory.Models.Public.Stories {

	public class Story : Model<StoryEntity> {

		public int UserID { get; set; }

		public User User { get; set; }

		public int? DraftChapterID { get; set; }

		public Chapter DraftChapter { get; set; }

		public IEnumerable<Chapter> Chapters { get; set; }

		public Story() { }

	}
}
