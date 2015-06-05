﻿using PhotoStory.Data.Relational.Entities.Account;
using PhotoStory.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoModel = PhotoStory.Models.Photos.Photo;

namespace PhotoStory.Data.Relational.Entities.Photos {

	public class Photo : Entity<PhotoModel> {

		[ModelMapping("ID")]
		public int PhotoID { get; set; }

		[ModelMapping]
		public DateTime UploadTime { get; set; }

		[ModelMapping]
		public string FullKey { get; set; }

		[ModelMapping]
		public string FileName { get; set; }

		[ModelMapping]
		public int UserID { get; set; }

		public virtual User User { get; set; }

		public Photo() { }

		public Photo(PhotoModel model) : base(model) { }
	}
}
