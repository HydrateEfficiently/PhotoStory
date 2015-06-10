using PhotoStory.Util.SubModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoStory.Data.Relational.Entities {

	public abstract class Entity<TModel> : SubModel<TModel> {

		[ModelMapping]
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		public Entity() { }

		public Entity(TModel model) : base(model) { }
	}
}
