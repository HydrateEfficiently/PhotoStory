using PhotoStory.Controllers.LocalApi;
using PhotoStory.Models.Chapters;
using PhotoStory.Models.Stories;
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
		private StoryApi _storyApi = new StoryApi();

		public async Task<ActionResult> CreateNew(Chapter_New chapter) {
			Chapter chapterModel = await Extensions.TaskExtensions.WhenOne(_chapterApi.Post(chapter.ToModel()));
			return Json(new Chapter_New(chapterModel));
		}

		public async Task<ActionResult> SaveDraft(Chapter_Draft chapter) {
			Chapter initChapterModel = chapter.ToModel();
			initChapterModel.SaveDraft();
			Chapter savedChapterModel = await Extensions.TaskExtensions.WhenOne(_chapterApi.Post(initChapterModel));
			await _storyApi.UpdateChapterDraft(savedChapterModel);
			return Json(new Chapter_Draft(savedChapterModel));
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				_chapterApi.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
