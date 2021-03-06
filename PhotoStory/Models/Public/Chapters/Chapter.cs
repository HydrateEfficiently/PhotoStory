﻿using PhotoStory.Models.Public.Photos;
using System;
using System.Collections.Generic;

namespace PhotoStory.Models.Public.Chapters {

	public class Chapter : Model<PhotoStory.Models.Entity.Chapters.Chapter> {

		public int StoryID { get; set; }

		public int UserID { get; set; }

		public string ChapterName { get; set; }

		public ChapterStatus ChapterStatus { get; set; }

		public DateTime? StartTime { get; set; }

		public DateTime? LastDraftSavedTime { get; set; }

		public IEnumerable<Photo> Photos { get; set; }

		public string Blog { get; set; }

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
