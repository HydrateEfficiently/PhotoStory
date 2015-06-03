using PhotoStory.Models.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.Data.Static {

	public interface Repository {

		bool Upload(Photo photo);
	}
}
