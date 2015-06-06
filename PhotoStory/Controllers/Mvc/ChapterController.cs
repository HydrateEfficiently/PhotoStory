using PhotoStory.Models.Chapters;
using PhotoStory.ViewModels.Chapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using ChapterApi = PhotoStory.Controllers.Api.ChapterController;

namespace PhotoStory.Controllers.Mvc {

	public class ChapterController : BaseController {

		private ChapterApi _chapterApi = new ChapterApi();

		public ActionResult CreateNewChapter(Chapter_New newChapter) {
			Task<IHttpActionResult> task = _chapterApi.PostChapter(newChapter.ToModel());
			task.Wait();
			var result = (CreatedAtRouteNegotiatedContentResult<Chapter>)(task.Result);
			return Json(new Chapter_New(result.Content));
		}
	}
}
