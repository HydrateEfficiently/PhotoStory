using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PhotoStory.Models.Public.Photos {

	public class PhotoUpload {

		public int UserID { get; set; }

		public int StoryID { get; set; }

		public DateTime UploadTime { get; private set; }

		public string FileName { get; private set; }

		public Stream InputStream { get; private set; }

		public PhotoUpload() {
			UploadTime = DateTime.UtcNow;
		}

		public void AppendFile(HttpPostedFileBase file) {
			FileName = file.FileName;
			InputStream = file.InputStream;
		}

	}
}
