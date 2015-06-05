using PhotoStory.Models.Photos;
using PhotoStory.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.ViewModels.Photos {

	public class Photo_Uploaded : ViewModel<Photo> {

		[ModelMapping]
		public string FileName { get; set; }

		[ModelMapping]
		public string FullKey { get; set; }

		public string Url { get; set; }

		public Photo_Uploaded() { }

		public Photo_Uploaded(Photo model) : base(model) { }

	}
}
