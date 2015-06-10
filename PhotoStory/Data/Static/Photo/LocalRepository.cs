using PhotoStory.Models.Photos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoModel = PhotoStory.Models.Photos.Photo;

namespace PhotoStory.Data.Static {

	public class LocalRepository : Repository {

		private const string RootDirectory = "D:/PhotoStory/Photos";

		public async Task UploadAsync(PhotoModel photo) {
			await Task.WhenAll(new Task(() => {
				using (var image = photo.GetImage()) {
					string dir = GetDirectory(photo);
					image.Save(photo.Key);
				}
			}));
		}

		private string GetDirectory(PhotoModel photo) {
			string dir = Path.Combine(RootDirectory, photo.DirectoryKey);
			if (!Directory.Exists(dir)) {
				Directory.CreateDirectory(dir);
			}
			return dir;
		}
	}
}
