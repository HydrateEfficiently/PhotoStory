using PhotoStory.Models.Entity;
using PhotoStory.Models.Public.Photos;
using System;
using System.Threading.Tasks;
using ChapterEntity = PhotoStory.Models.Entity.Chapters.Chapter;
using ChapterModel = PhotoStory.Models.Public.Chapters.Chapter;

namespace PhotoStory.Controllers.LocalApi {

	public class ChapterApi : BaseApi<ChapterModel, ChapterEntity> {

		private PhotoApi _photoApi;

		protected override string WorkingDbSetName {
			get {
				return "Chapters";
			}
		}

		public ChapterApi() { }

		public ChapterApi(PhotoStoryContext context) : base(context) {
			//_photoApi = new PhotoApi(context);
		}

		public virtual async Task AddPhoto(int chapterId, Photo photo) {
			//Photo savedPhoto = await _photoApi.Get(photo.ID);
			//if (savedPhoto == null) {
			//	throw new Exception(string.Format("Photo of ID {0} not found.", photo.ID));
			//}

			//if (savedPhoto.ChapterID != chapterId ||
			//	savedPhoto.ChapterID != photo.ChapterID) {
			//	throw new Exception("Inconsistent chapter ID.");
			//}

			//ChapterEntity chapter = await WorkingDbSet.FindAsync(chapterId);
			//if (chapter == null) {
			//	throw new Exception(string.Format("Chapter of ID {0} not found.", chapterId));
			//}

			//if (photo.StoryID != chapter.StoryID) {
			//	throw new Exception(string.Format("StoryID on chapter, {0}, did not match StoryID on photo, {1}",
			//		chapter.StoryID,
			//		photo.StoryID));
			//}

			//Context.SaveChanges();
		}

	}
}
