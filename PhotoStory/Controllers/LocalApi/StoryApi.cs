using PhotoStory.Data.Relational;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
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

		protected override async Task<StoryModel> PopulateForeignKeys(StoryModel model) {
			// TODO: "yield return" version for populating multiple models.
			model.User = await _accountApi.Get(model.UserID);
			return model;
		}

		public virtual async Task<StoryModel> GetByUser(int userId) {
			StoryEntity entity = await WorkingDbSet.FirstOrDefaultAsync(x => x.UserID == userId);
			if (entity == null) {
				return await Post(new StoryModel() {
					UserID = userId
				});
			} else {
				return await PopulateForeignKeys(entity.ToModel());
			}
		}
	}
}
