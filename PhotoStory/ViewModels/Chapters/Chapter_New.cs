using PhotoStory.Models.Chapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.ViewModels.Chapters {

	public class Chapter_New : ViewModel<Chapter> {

		public Chapter_New() { }

		public Chapter_New(Chapter model) : base(model) { }
	}
}
