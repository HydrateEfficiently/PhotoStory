using PhotoStory.Models.Public.Accounts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PhotoStory.Models.Public.Photos {

	public class Photo : Model<PhotoStory.Models.Entity.Photos.Photo> {

		private Stream _stream;

		public int UserID { get; set; }

		public int StoryID { get; set; }

		public int ChapterID { get; set; }

		public string FileName { get; set; }

		public DateTime UploadTime { get; set; }

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

		public string DirectoryKey {
			get {
				return PhotoUrlGenerator.GenerateDirectoryKey(this);
			}
		}

		public string Key {
			get {
				return PhotoUrlGenerator.GenerateKey(this);
			}
		}

		public string Url {
			get {
				return PhotoUrlGenerator.GenerateUrl(this);
			}
		}

		public Photo(Stream stream) { // TODO: Mapping stream!
			_stream = stream;
		}

		public Photo() { }

		// TODO: Needs work - Locking the stream, asynchronous, disposing the stream
		public async Task<Stream> GetStreamAsync() {
			var ms = new MemoryStream();
			_stream.Position = 0;
			await _stream.CopyToAsync(ms);
			ms.Position = 0;
			return ms;
		}

		// TODO: Needs work - Locking the stream, asynchronous, disposing the stream
		public Image GetImage() {
			_stream.Position = 0;
			return Image.FromStream(_stream);
		}
	}
}
