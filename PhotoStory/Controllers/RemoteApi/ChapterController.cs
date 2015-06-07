using ChapterModel = PhotoStory.Models.Chapters.Chapter;
using ChapterEntity = PhotoStory.Data.Relational.Entities.Chapters.Chapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace PhotoStory.Controllers.Api {

	public class ChapterController : ApiController {

		[ResponseType(typeof(ChapterModel))]
		public async Task<IHttpActionResult> PostChapter(ChapterModel chapter) {
			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			}

			var chapterEntity = new ChapterEntity(chapter);
			//db.Users.Add(userEntity);
			//await db.SaveChangesAsync();

			return CreatedAtRoute("DefaultApi", new { id = chapterEntity.ID }, chapterEntity.ToModel());
		}

	}
}
