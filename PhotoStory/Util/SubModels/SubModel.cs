using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace PhotoStory.Util.SubModels {

	// TODO: Copy all other attributes from the Model i.e. validation attributes

	public abstract class SubModel<TModel> {

		public SubModel() { }

		public SubModel(TModel model) {
			ModelMapper.MapFromModel(model, this);
		}

		public TModel ToModel() {
			return ModelMapper.MapToModel<TModel>(this);
		}
	}
	
	public class ModelMappingAttribute : Attribute {

		public string ModelPropertyName { get; private set; }

		public ModelMappingType ModelMappingType { get; private set; }

		public ModelMappingDirection ModelMappingDirection { get; set; }

		public ModelMappingAttribute(
			string modelPropertyName = null,
			ModelMappingType modelMappingType = ModelMappingType.Property,
			ModelMappingDirection modelMappindDirection = ModelMappingDirection.Bidirectional) {

			ModelPropertyName = modelPropertyName;
			ModelMappingType = modelMappingType;
			ModelMappingDirection = ModelMappingDirection; // TODO?
		}
	}

	public enum ModelMappingType {

		Unknown = 0,

		Property = 1,

		ConstructorParameter = 2
	}

	public enum ModelMappingDirection {

		Unknown = 0,

		ToModel = 1,

		FromModel = 2,

		Bidirectional = 4
	}
}
