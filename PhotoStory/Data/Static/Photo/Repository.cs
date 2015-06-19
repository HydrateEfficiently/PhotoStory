using System.Threading.Tasks;
using PhotoModel = PhotoStory.Models.Public.Photos.Photo;

namespace PhotoStory.Data.Static {

	public interface Repository {

		Task UploadAsync(PhotoModel photo);

		Task<bool> DeleteAsync(PhotoModel photo);
	}
}
