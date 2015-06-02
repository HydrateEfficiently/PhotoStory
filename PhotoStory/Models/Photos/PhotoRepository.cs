using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.Models.Photos {

	public interface PhotoRepository {

		bool Upload(Photo photo);
		Task<bool> UploadAsync(Photo photo);

	}
}
