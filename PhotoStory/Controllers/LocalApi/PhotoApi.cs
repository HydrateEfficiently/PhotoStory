using PhotoStory.Data.Static;
using PhotoStory.Models.Entity;
using PhotoStory.Util.Extensions;
using System.Threading.Tasks;
using PhotoEntity = PhotoStory.Models.Entity.Photos.Photo;
using PhotoModel = PhotoStory.Models.Public.Photos.Photo;

namespace PhotoStory.Controllers.LocalApi {

	public class PhotoApi : BaseApi<PhotoModel, PhotoEntity> {

		protected override string WorkingDbSetName {
			get {
				return "Photos";
			}
		}

		public PhotoApi() {	}

		public PhotoApi(PhotoStoryContext context) : base(context) { }

		public override async Task<PhotoModel> Post(PhotoModel model) {
			await base.Post(model)
				.ContinueWithOrRollback(
					async t => {
						model.ID = t.Result.ID;
						await Repository.UploadAsync(model);
					},
					async t => {
						await Delete(model.ID);
					});
			return model;
		}

	}

}