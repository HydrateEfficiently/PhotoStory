using PhotoStory.Controllers.LocalApi;
using PhotoStory.Models.Chapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoStoryProgram {

	class Program {

		static void Main(string[] args) {

			Task task = new Task(async () => {
				var photoApi = new PhotoApi();
				await photoApi.Post(new PhotoStory.Models.Photos.Photo() {
					StoryID = 1,
					UserID = 1,
					ChapterID = 1,
					FileName = "test.jpg",
					UploadTime = DateTime.Now
				});

				var chapterApi = new ChapterApi();
				Chapter chapter = await chapterApi.Get(1);

				Console.WriteLine(chapter.ID);
			});

			task.Start();
			task.Wait();
		}
	}

}
