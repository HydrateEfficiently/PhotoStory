using PhotoStory.Controllers.LocalApi;
using PhotoStory.Models.Account;
using PhotoStory.Models.Photos;
using PhotoStory.ViewModels.Photos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using MyTaskExtensions = PhotoStory.Util.Extensions.TaskExtensions;

namespace PhotoStory.Controllers.Mvc {

	public class PhotoController : BaseController {

		private PhotoApi _photoApi = new PhotoApi();

		public async Task<ActionResult> UploadPhoto(Photo_ToUpload photoToUpload) {
			if (Request.Files.Count == 0) {
				throw new Exception("Could not find file associated with the request.");
			} else if (Request.Files.Count > 1) {
				throw new Exception("Multiple files associated with the request were found");
			}

			var photoUploaded = new Photo_Uploaded(photoToUpload, Request.Files[0]);
			Photo photo = await MyTaskExtensions.WhenOne<Photo>(_photoApi.Post(photoUploaded.ToModel()));
			return Json(photo);
		}

	}
}
