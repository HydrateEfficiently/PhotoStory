﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoStory.Models.Entity {

	public class Entity<TModel> {

		[Key]
		public int ID { get; private set; }

		public Entity() { }

		public TModel ToModel() {
			CreateMapIfNotExists(GetType(), typeof(TModel));
			return Mapper.Map<TModel>(this);
		}

		private static void CreateMapIfNotExists(Type sourceType, Type destinationType) {
			if (Mapper.FindTypeMapFor(sourceType, destinationType) == null) {
				Mapper.CreateMap(sourceType, destinationType);
			}
		}
	}
}