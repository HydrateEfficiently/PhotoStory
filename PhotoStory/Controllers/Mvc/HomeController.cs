using PhotoStory.Controllers.LocalApi;
using PhotoStory.Models.Public.Chapters;
using PhotoStory.Models.Public.Photos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PhotoStory.Controllers.Mvc {

	[Authorize]
	public class HomeController : BaseController {

		[HttpGet]
		[AllowAnonymous]
		public ActionResult Index() {
			return View();
		}

		public async Task<ActionResult> Test() {
			var photoApi = new PhotoApi();
			Photo photo = await photoApi.Post(new Photo(System.IO.File.Open(@"C:\Users\Michael\Pictures\Camera Roll\WIN_20150511_160620.JPG", FileMode.Open)) {
				StoryID = 1,
				UserID = 1,
				ChapterID = 4,
				FileName = "test.jpg",
				UploadTime = DateTime.Now
			});

			var chapterApi = new ChapterApi();
			Chapter chapter = await chapterApi.Get(4);

			return Json(chapter);
		}
	}
}
