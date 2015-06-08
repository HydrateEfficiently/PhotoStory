using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapterModel = PhotoStory.Models.Chapters.Chapter;
using ChapterEntity = PhotoStory.Data.Relational.Entities.Chapters.Chapter;
using PhotoStory.Data.Relational;

namespace PhotoStory.Controllers.LocalApi {

	public class ChapterApi : BaseApi<ChapterModel, ChapterEntity> {

		protected override string WorkingDbSetName {
			get {
				return "Chapters";
			}
		}

		public ChapterApi() { }

		public ChapterApi(PhotoStoryContext context) : base(context) { }
	}
}
