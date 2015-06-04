using System;
using System.Reflection;

namespace PhotoStory.Util {

	// TODO: Copy all other attributes from the Model i.e. validation attributes

	public abstract class SubModel<TModel> {

		public SubModel() { }

		public SubModel(TModel model) {
			ModelMapper.MapFromModel<TModel>(this, model);
		}

		public TModel ToModel() {
			return ModelMapper.MapToModel<TModel>(this);
		}
	}
	
	public class ModelMappingAttribute : Attribute {

		public string ModelPropertyName { get; private set; }

		public ModelMappingAttribute(string modelPropertyName = null) {
			ModelPropertyName = modelPropertyName;
		}
	}

	public static class ModelMapper {

		public static TModel MapToModel<TModel>(object subModel) {
			var model = (TModel)Activator.CreateInstance(typeof(TModel));
			ForEachMappedProperty<TModel>(subModel.GetType(), (subModelPropertyInfo, modelPropertyInfo) => {
				modelPropertyInfo.SetValue(model, subModelPropertyInfo.GetValue(subModel));
			});
			return model;
		}

		public static void MapFromModel<TModel>(object subModel, object model) {
			ModelMapper.ForEachMappedProperty<TModel>(subModel.GetType(), (subModelPropertyInfo, modelPropertyInfo) => {
				subModelPropertyInfo.SetValue(subModel, modelPropertyInfo.GetValue(model));
			});
		}

		public static void ForEachMappedProperty<TModel>(Type subModelType, Action<PropertyInfo, PropertyInfo> action) {
			var propertiesInfo = subModelType.GetProperties();
			foreach (var propertyInfo in propertiesInfo) {
				PropertyInfo modelPropertyInfo;
				if (TryGetMappedProperty<TModel>(propertyInfo, out modelPropertyInfo)) {
					action(propertyInfo, modelPropertyInfo);
				}
			}
		}

		private static bool TryGetMappedProperty<T>(PropertyInfo subModelPropertyInfo, out PropertyInfo modelPropertyInfo) {
			var modelMappingAttr = (ModelMappingAttribute)subModelPropertyInfo.GetCustomAttribute(typeof(ModelMappingAttribute));
			if (modelMappingAttr == null) {
				modelPropertyInfo = null;
				return false;
			} else {
				string modelPropertyName = modelMappingAttr.ModelPropertyName ?? subModelPropertyInfo.Name;
				modelPropertyInfo = typeof(T).GetProperty(modelPropertyName);
				return true;
			}

		}
	}
}
