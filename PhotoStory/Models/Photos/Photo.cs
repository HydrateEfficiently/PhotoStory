using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.Models.Photos {

	public class Photo : IDisposable {

		private Stream _stream;

		public string FileName {
			get;
			private set;
		}

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

		public Photo(string path) {
			_stream = File.Open(path, FileMode.Open);
			FileName = Path.GetFileName(path).ToLower();
		}

		public async Task<Stream> GetStream() {
			var ms = new MemoryStream();
			_stream.Position = 0;
			await _stream.CopyToAsync(ms);
			return ms;
		}

		public void Dispose() {
			_stream.Dispose();
		}
	}
}
