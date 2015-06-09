using PhotoStory.Data.Relational;
using PhotoStory.Models.Chapters;
using System;
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

		public virtual async Task UpdateChapterDraft(Chapter chapter) {
			Chapter savedDraftChapter = await _chapterApi.Get(chapter.ID);
			if (savedDraftChapter == null) {
				throw new Exception(string.Format("Chapter of ID {0} not found.", chapter.ID));
			}

			if (savedDraftChapter.StoryID != chapter.StoryID || savedDraftChapter.UserID != chapter.UserID) {
				throw new Exception("Inconsistent story and user information in chapter.");
			}

			StoryEntity story = await WorkingDbSet.FindAsync(chapter.StoryID);
			if (story == null) {
				throw new Exception(string.Format("Story of ID {0} not found.", chapter.StoryID));
			}

			if (story.UserID != chapter.UserID) {
				throw new Exception(string.Format("UserID on story, {0}, did not match UserID on chapter, {1}", story.UserID, chapter.UserID));
			}

			story.ChapterDraftID = chapter.ID;
			Context.SaveChanges();
		}

		private async Task<StoryModel> PopulateForeignKeys(StoryModel model) {
			// TODO: "yield return" version for populating multiple models.
			model.User = await _accountApi.Get(model.UserID);
			model.ChapterDraft = model.ChapterDraftID < 1 ?
				new Chapter() { StoryID = model.ID, UserID = model.UserID } :
				model.ChapterDraft = await _chapterApi.Get(model.ChapterDraftID);
			return model;
		}
	}
}
