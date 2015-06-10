using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotoModel = PhotoStory.Models.Photos.Photo;
using PhotoEntity = PhotoStory.Data.Relational.Entities.Photos.Photo;
using PhotoStory.Data.Relational;
using System.Threading.Tasks;
using PhotoStory.Data.Static;

namespace PhotoStory.Controllers.LocalApi {

	public class PhotoApi : BaseApi<PhotoModel, PhotoEntity> {

		protected override string WorkingDbSetName {
			get {
				return "Photos";
			}
		}

		public PhotoApi() { }

		public PhotoApi(PhotoStoryContext context) : base(context) { }

		public override async Task<PhotoModel> Post(PhotoModel model) {
			var result = await base.Post(model);
			await RepositorySettings.Instance.UploadAsync(result);
			return result;
		}

	}

}