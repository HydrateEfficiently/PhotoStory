using PhotoModel = PhotoStory.Models.Photos.Photo;
using PhotoEntity = PhotoStory.Data.Relational.Entities.Photos.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PhotoStory.Models.Photos;

namespace PhotoStory.Controllers.Api {

	public class PhotoController : ApiController {

		[ResponseType(typeof(PhotoModel))]
		public async Task<IHttpActionResult> PostPhoto(PhotoModel photo) {
			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			}

			var photoEntity = new PhotoEntity(photo);
			//db.Users.Add(userEntity);
			//await db.SaveChangesAsync();

			return CreatedAtRoute("DefaultApi", new { id = photoEntity.ID }, photoEntity.ToModel());
		}

	}
}
