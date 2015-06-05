using PhotoStory.Models.Stories;
using PhotoStory.ViewModels.Stories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PhotoStory.Controllers.Mvc {

	public class StoryController : BaseController {

		public ActionResult Index() {
			return View(new Story_Index(CurrentUser));
		}

	}
}
