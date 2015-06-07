using PhotoStory.Models.Account;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PhotoStory.Models.Photos {

	public class Photo : Model {

		private Stream _stream;

		public int UserID { get; set; }

		public int StoryID { get; set; }

		public DateTime UploadTime { get; set; }

		public string DirectoryKey { get; set; }

		public string FileName { get; set; }

		public User User { get; set; }

		public string Extension {
			get {
				return FileName.Substring(FileName.LastIndexOf('.') + 1);
			}
		}

		public string ContentType {
			get {
				return string.Format("image/{0}", Extension);
			}
		}

		public string FullKey {
			get {
				return string.Format("{0}/{1}_{2}", DirectoryKey, ID, FileName);
			}
		}

		public Photo(PhotoUpload photoUpload) {
			_stream = photoUpload.InputStream;
			FileName = photoUpload.FileName;
			StoryID = photoUpload.StoryID;
			UserID = photoUpload.UserID;
		}

		public Photo(string path) {
			_stream = File.Open(path, FileMode.Open);
			FileName = Path.GetFileName(path).ToLower();
		}

		public Photo() { }

		public async Task<Stream> GetStreamAsync() {
			var ms = new MemoryStream();
			_stream.Position = 0;
			await _stream.CopyToAsync(ms);
			ms.Position = 0;
			return ms;
		}

		public Image GetImage() {
			_stream.Position = 0;
			return Image.FromStream(_stream);
		}

		public void Dispose() {
			_stream.Dispose();
		}
	}
}
