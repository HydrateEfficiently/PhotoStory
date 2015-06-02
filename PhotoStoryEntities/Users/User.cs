﻿using PhotoStoryEntities.Photos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStoryEntities.Users {

	public class User {

		public int ID { get; set; }

		public string Username { get; set; }

		public virtual IEnumerable<Photo> Photos { get; set; } 
	}
}
