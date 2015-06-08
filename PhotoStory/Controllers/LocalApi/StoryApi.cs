using PhotoStory.Data.Relational;
using PhotoStory.Models.Chapters;
using System.Data.Entity;
using System.Threading.Tasks;
using StoryEntity = PhotoStory.Data.Relational.Entities.Stories.Story;
using StoryModel = PhotoStory.Models.Stories.Story;

namespace PhotoStory.Controllers.LocalApi {

	public class StoryApi : BaseApi<StoryModel, StoryEntity> {

		private AccountApi _accountApi;
		private ChapterApi _chapterApi;

		protected override string WorkingDbSetName {
			get {
				return "Stories";
			}
		}

		public StoryApi() {
			InitialiseApis();
		}

		public StoryApi(PhotoStoryContext context) : base(context) {
			InitialiseApis();
		}

		private void InitialiseApis() {
			_accountApi = new AccountApi(Context);
			_chapterApi = new ChapterApi(Context);
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
			model.ChapterDraft = model.ChapterDraftID < 1 ?
				new Chapter() :
				model.ChapterDraft = await _chapterApi.Get(model.ChapterDraftID);
			return model;
		}
	}
}
