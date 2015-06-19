using PhotoStory.Controllers.LocalApi;
using PhotoStory.Models.Public.Stories;
using PhotoStory.ViewModels.Stories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Extensions = PhotoStory.Util.Extensions;

namespace PhotoStory.Controllers.Mvc {

	public class StoryController : BaseController {

		private StoryApi _storyApi = new StoryApi();

		public async Task<ActionResult> Index() {
			Story story = await Extensions.TaskExtensions.WhenOne(_storyApi.GetByUser(CurrentUser.ID));
			return View(new Story_Index(story));
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				_storyApi.Dispose();
			}
			base.Dispose(disposing);
		}

	}
}
