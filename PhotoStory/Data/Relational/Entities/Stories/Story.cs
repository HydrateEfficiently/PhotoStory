using PhotoStory.Data.Relational.Entities.Account;
using PhotoStory.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoryModel = PhotoStory.Models.Stories.Story;

namespace PhotoStory.Data.Relational.Entities.Stories {

	public class Story : Entity<StoryModel> {

		[ModelMapping]
		public int UserID { get; set; }

		public Story() { }

		public Story(StoryModel model) : base(model) { }
	}
}
