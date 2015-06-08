﻿using PhotoStory.Models.Account;
using PhotoStory.Models.Stories;
using PhotoStory.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.ViewModels.Stories {

	public class Story_Index : ViewModel<Story> {

		[ModelMapping]
		public User User { get; set; }

		public Story_Index(Story story) : base(story) {
		}

	}
}
