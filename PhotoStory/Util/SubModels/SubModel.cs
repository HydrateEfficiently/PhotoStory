using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace PhotoStory.Util.SubModels {

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

	public static class ModelMapper {

		public static TModel MapToModel<TModel>(object subModel) {
			var model = CreateModel<TModel>(subModel);
			ForEachMappedProperty<TModel>(subModel.GetType(), (subModelPropertyInfo, modelPropertyInfo) => {
				modelPropertyInfo.SetValue(model, subModelPropertyInfo.GetValue(subModel));
			});
			return model;
		}

		public static void MapFromModel<TModel>(object subModel, object model) {
			ForEachMappedProperty<TModel>(subModel.GetType(), (subModelPropertyInfo, modelPropertyInfo) => {
				subModelPropertyInfo.SetValue(subModel, modelPropertyInfo.GetValue(model));
			});
		}

		private static TModel CreateModel<TModel>(object subModel) {
			IEnumerable<PropertyInfo> propertiesMappedToConstructor = FindAllMappedProperties<TModel>(subModel.GetType(), pi => {
				ModelMappingAttribute attr = GetModelMappingAttribute(pi);
				return attr != null && attr.ModelMappingType == ModelMappingType.ConstructorParameter;
			});

			if (propertiesMappedToConstructor.Count() == 0) {
				return (TModel)Activator.CreateInstance(typeof(TModel));
			} else if (propertiesMappedToConstructor.Count() == 1) {
				PropertyInfo mappedProperty = propertiesMappedToConstructor.First();
				object mappedPropertyValue = mappedProperty.GetValue(subModel);
				Type modelType = typeof(TModel);
				ConstructorInfo constuctorInfo = modelType.GetConstructor(new [] { subModel.GetType() });
				if (constuctorInfo == null) {
					throw new Exception("Could not find appropriate constructor");
				}
				return (TModel)constuctorInfo.Invoke(new object[] { mappedPropertyValue });
			} else {
				throw new Exception("Multiple constructor parameters unsuppored");
			}
		}

		private static void ForEachMappedProperty<TModel>(Type subModelType, Action<PropertyInfo, PropertyInfo> action) {
			var propertiesInfo = subModelType.GetProperties();
			foreach (var propertyInfo in propertiesInfo) {
				PropertyInfo modelPropertyInfo;
				if (TryGetMappedProperty<TModel>(propertyInfo, out modelPropertyInfo)) {
					action(propertyInfo, modelPropertyInfo);
				}
			}
		}

		private static IEnumerable<PropertyInfo> FindAllMappedProperties<TModel>(Type subModelType, Predicate<PropertyInfo> predicate) {
			var result = new List<PropertyInfo>();
			var propertiesInfo = subModelType.GetProperties();
			foreach (var propertyInfo in propertiesInfo) {
				PropertyInfo modelPropertyInfo;
				if (TryGetMappedProperty<TModel>(propertyInfo, out modelPropertyInfo) && predicate(modelPropertyInfo)) {
					result.Add(modelPropertyInfo);
				}
			}
			return result;
		}

		private static bool TryGetMappedProperty<T>(PropertyInfo subModelPropertyInfo, out PropertyInfo modelPropertyInfo) {
			if (HasMappedProperty(subModelPropertyInfo)) {
				string modelPropertyName = GetModelMappingAttribute(subModelPropertyInfo).ModelPropertyName ?? subModelPropertyInfo.Name;
				Type modelType = typeof(T);
				modelPropertyInfo = modelType.GetProperty(modelPropertyName);
				if (modelPropertyInfo == null) {
					throw new Exception(string.Format("ModelMapping was declared for property {0} but {1}.{0} does not exist", modelPropertyName, modelType.FullName));
				}
				return true;
			}
			modelPropertyInfo = null;
			return false;
		}

		private static bool HasMappedProperty(PropertyInfo subModelPropertyInfo) {
			return GetModelMappingAttribute(subModelPropertyInfo) != null;
		}

		private static ModelMappingAttribute GetModelMappingAttribute(PropertyInfo subModelPropertyInfo) {
			return (subModelPropertyInfo.GetCustomAttribute(typeof(ModelMappingAttribute)) as ModelMappingAttribute);
		}

	}
}
