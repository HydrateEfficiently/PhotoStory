using PhotoStory.Controllers.LocalApi;
using PhotoStory.Models.Public.Chapters;
using PhotoStory.Models.Public.Stories;
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
using MyTaskExtensions = PhotoStory.Util.Extensions.TaskExtensions;

namespace PhotoStory.Controllers.Mvc {

	public class ChapterController : BaseController {

		private ChapterApi _chapterApi = new ChapterApi();
		private StoryApi _storyApi = new StoryApi();

		public async Task<ActionResult> CreateNew(Chapter_New chapter) {
			Chapter chapterModel = await MyTaskExtensions.WhenOne(_chapterApi.Post(chapter.ToModel()));
			return Json(new Chapter_New(chapterModel));
		}

		public async Task<ActionResult> SaveDraft(Chapter_Draft chapter) {
			//Chapter initChapterModel = chapter.ToModel();
			//initChapterModel.SaveDraft();
			//Chapter savedChapterModel = await MyTaskExtensions.WhenOne(_chapterApi.Post(initChapterModel));
			//await _storyApi.AddDraftChapter(initChapterModel.StoryID, savedChapterModel);
			//return Json(new Chapter_Draft(savedChapterModel));

			Chapter chapterModel = chapter.ToModel();
			chapterModel.SaveDraft();
			Chapter savedChapterDraft = await _storyApi.PutDraftChapter(chapterModel.StoryID, chapterModel);
			return Json(savedChapterDraft);
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				_chapterApi.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
