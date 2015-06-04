using PhotoStory.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.Data.Relational.Entities {

	public abstract class Entity<TModel> : SubModel<TModel> {

		public Entity() { }

		public Entity(TModel model) : base(model) { }
	}
}
