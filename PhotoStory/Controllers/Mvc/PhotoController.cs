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
using PhotoApi = PhotoStory.Controllers.Api.PhotoController;

namespace PhotoStory.Controllers.Mvc {

	public class PhotoController : BaseController {

		private PhotoApi _api = new PhotoApi();

		public ActionResult Upload(PhotoUpload photoUpload) {
			photoUpload.AppendFile(Request.Files[0]);
			Task<IHttpActionResult> task = _api.PostPhoto(new Photo(photoUpload));
			task.Wait();
			var result = (CreatedAtRouteNegotiatedContentResult<Photo>)(task.Result);
			return Json(new Photo_Uploaded(result.Content));
		}

	}
}
