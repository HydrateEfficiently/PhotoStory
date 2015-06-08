using PhotoStory.Controllers.LocalApi;
using PhotoStory.Models.Chapters;
using PhotoStory.ViewModels.Chapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using Extensions = PhotoStory.Util.Extensions;

namespace PhotoStory.Controllers.Mvc {

	public class ChapterController : BaseController {

		private ChapterApi _chapterApi = new ChapterApi();

		public async Task<ActionResult> CreateNew(Chapter_New chapter) {
			Chapter chapterModel = await Extensions.TaskExtensions.WhenOne(_chapterApi.Post(chapter.ToModel()));
			return Json(new Chapter_New(chapterModel));
		}

		public async Task<ActionResult> SaveDraft(Chapter_SaveDraft chapter) {
			Chapter initChapterModel = chapter.ToModel();
			initChapterModel.SaveDraft();
			await Task.WhenAll(_chapterApi.Put(initChapterModel.ID, initChapterModel));
			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				_chapterApi.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
