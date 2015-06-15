﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotoModel = PhotoStory.Models.Photos.Photo;
using PhotoEntity = PhotoStory.Data.Relational.Entities.Photos.Photo;
using PhotoStory.Data.Relational;
using System.Threading.Tasks;
using PhotoStory.Data.Static;
using PhotoStory.Util.Extensions;

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
				//.ContinueWithOrRollback(
				//	async t => {
				//		await ChapterApi.AddPhoto(model.ChapterID, model);
				//	},
				//	async t => {
				//		await Repository.DeleteAsync(model);
				//	});
			return model;
		}

	}

}