using PhotoStory.Data.Relational;
using System.Data.Entity;
using System.Threading.Tasks;
using StoryEntity = PhotoStory.Data.Relational.Entities.Stories.Story;
using StoryModel = PhotoStory.Models.Stories.Story;

namespace PhotoStory.Controllers.LocalApi {

	public class StoryApi : BaseApi<StoryModel, StoryEntity> {

		private AccountApi _accountApi;

		protected override string WorkingDbSetName {
			get {
				return "Stories";
			}
		}

		public StoryApi() {
			_accountApi = new AccountApi(Context);
		}

		public StoryApi(PhotoStoryContext context) : base(context) {
			_accountApi = new AccountApi(Context);
		}

		public virtual async Task<StoryModel> GetByUser(int userId) {
			StoryEntity entity = await WorkingDbSet.FirstOrDefaultAsync(x => x.UserID == userId);
			StoryModel model = null;
			if (entity == null) {
				model = await Post(new StoryModel() {
					UserID = userId
				});
			} else {
				model = entity.ToModel();
			}
			return await PopulateForeignKeys(model);
		}

		private async Task<StoryModel> PopulateForeignKeys(StoryModel model) {
			// TODO: "yield return" version for populating multiple models.
			model.User = await _accountApi.Get(model.UserID);
			return model;
		}
	}
}
