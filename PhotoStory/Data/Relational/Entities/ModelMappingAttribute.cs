using System;

namespace PhotoStory.Data.Relational.Entities {
	
	public class ModelMappingAttribute : Attribute {

		public string ModelPropertyName { get; private set; }

		public ModelMappingAttribute(string modelPropertyName = null) {
			ModelPropertyName = modelPropertyName;
		}

	}
}
