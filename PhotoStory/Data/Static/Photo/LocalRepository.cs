﻿using System;
using System.IO;
using System.Threading.Tasks;
using PhotoModel = PhotoStory.Models.Public.Photos.Photo;

namespace PhotoStory.Data.Static {

	public class LocalRepository : Repository {

		private const string RootDirectory = "D:/PhotoStory/Photos";

		public async Task UploadAsync(PhotoModel photo) {
			var task = new Task(() => {
				using (var image = photo.GetImage()) {
					string dir = GetDirectory(photo);
					image.Save(photo.Url);
				}
			});
			task.Start();
			await Task.WhenAll(task);
		}

		private string GetDirectory(PhotoModel photo) {
			string dir = Path.Combine(RootDirectory, photo.DirectoryKey);
			if (!Directory.Exists(dir)) {
				Directory.CreateDirectory(dir);
			}
			return dir;
		}


		public Task<bool> DeleteAsync(PhotoModel photo) {
			throw new NotImplementedException();
		}
	}
}
