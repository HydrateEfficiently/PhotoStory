using PhotoStory.Models.Photos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoModel = PhotoStory.Models.Photos.Photo;

namespace PhotoStory.Data.Static {

	public interface Repository {

		Task UploadAsync(PhotoModel photo);

		Task<bool> DeleteAsync(PhotoModel photo);
	}
}
