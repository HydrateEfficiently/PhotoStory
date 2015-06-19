using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoStory.Models.Public {

	public class Model<TEntityType> {

		public int ID { get; set; }

		public TEntityType ToEntity() {
			CreateMapIfNotExists(GetType(), typeof(TEntityType));
			return Mapper.Map<TEntityType>(this);
		}

		private static void CreateMapIfNotExists(Type sourceType, Type destinationType) {
			if (Mapper.FindTypeMapFor(sourceType, destinationType) == null) {
				Mapper.CreateMap(sourceType, destinationType);
			}
		}
	}
}