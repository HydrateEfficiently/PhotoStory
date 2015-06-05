using PhotoStory.Models.Photos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.Data.Static {

	public class LocalRepository : Repository {

		private const string RootDirectory = "D:/PhotoStory/Photos";

		public bool Upload(Photo photo) {
			using (var image = photo.GetImage()) {
				string dir = GetDirectory(photo);
				image.Save(photo.FullKey);
			}
			return true;
		}

		private string GetDirectory(Photo photo) {
			string dir = Path.Combine(RootDirectory, photo.DirectoryKey);
			if (!Directory.Exists(dir)) {
				Directory.CreateDirectory(dir);
			}
			return dir;
		}
	}
}
