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

		// TODO: Delete entity if save fails
		public override async Task<PhotoModel> Post(PhotoModel model) {
			model.ID = (await base.Post(model)).ID;
			await RepositorySettings.Instance.UploadAsync(model).ContinueWith(async t => {
				if (t.Exception != null) {
					await Delete(model.ID);
					throw t.Exception;
				}
			});
			return model;
		}

	}

}