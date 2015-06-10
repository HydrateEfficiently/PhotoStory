using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PhotoStory.Util.SubModels {

	public static class ModelMapper {

		public static void MapFromModel(object model, object subModel) {
			CopyProperties(model, subModel, ModelMappingDirection.FromModel);
		}

		public static TModel MapToModel<TModel>(object subModel) {
			TModel model = CreateModel<TModel>(subModel);
			CopyProperties(model, subModel, ModelMappingDirection.ToModel);
			return model;
		}

		private static TModel CreateModel<TModel>(object subModel) {
			IEnumerable<PropertyInfo> constructorMappedProperties =	WhereModelMappingAttribute(subModel, (property, attribute) => {
				return IsApplicableModelMappingAttribute(attribute, ModelMappingDirection.ToModel, ModelMappingType.ConstructorParameter);
			}).Select(kvp => kvp.Key);

			int constructorMappedPropertiesCount = constructorMappedProperties.Count();
			if (constructorMappedPropertiesCount == 0) {
				return (TModel)Activator.CreateInstance(typeof(TModel));
			} else if (constructorMappedPropertiesCount == 1) {
				PropertyInfo mappedProperty = constructorMappedProperties.First();
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

		private static void CopyProperties(object model, object subModel, ModelMappingDirection direction) {
			ForEachModelMappingAttribute(subModel, (subModelProperty, attribute) => {
				if (IsApplicableModelMappingAttribute(attribute, direction, ModelMappingType.Property)) {
					Type modelType = model.GetType();
					string modelPropertyName = GetModelPropertyName(subModelProperty, attribute);
					PropertyInfo modelProperty = GetModelProperty(modelType, modelPropertyName);
					if (modelProperty == null) {
						throw new Exception(string.Format("ModelMapping was declared for property {0} but {1}.{0} does not exist", modelProperty.Name, modelType.FullName));
					}

					if (direction == ModelMappingDirection.ToModel) {
						modelProperty.SetValue(model, subModelProperty.GetValue(subModel));
					} else if (direction == ModelMappingDirection.FromModel) {
						subModelProperty.SetValue(subModel, modelProperty.GetValue(model));
					}	
				}
			});
		}

		private static void ForEachModelMappingAttribute(object subModel, Action<PropertyInfo, ModelMappingAttribute> action) {
			Dictionary<PropertyInfo, ModelMappingAttribute> attributesByProperty = GetAttributesByProperty(subModel);
			foreach (var kvp in attributesByProperty) {
				action(kvp.Key, kvp.Value);
			}
		}

		private static IEnumerable<KeyValuePair<PropertyInfo, ModelMappingAttribute>> WhereModelMappingAttribute(object subModel, Func<PropertyInfo, ModelMappingAttribute, bool> predicate) {
			return GetAttributesByProperty(subModel).Where(kvp => predicate(kvp.Key, kvp.Value));
		}

		private static PropertyInfo GetModelProperty(Type modelType, string modelPropertyName) {;
			return modelType.GetProperty(modelPropertyName);
		}

		private static string GetModelPropertyName(PropertyInfo subModelProperty, ModelMappingAttribute attribute) {
			return attribute.ModelPropertyName ?? subModelProperty.Name;
		}

		private static Dictionary<PropertyInfo, ModelMappingAttribute> GetAttributesByProperty(object subModel) {
			Type subModelType = subModel.GetType();
			PropertyInfo[] subModelProperties = subModelType.GetProperties();
			var attributesByProperty = new Dictionary<PropertyInfo, ModelMappingAttribute>();
			foreach (var subModelProperty in subModelProperties) {
				ModelMappingAttribute attribute = GetModelMappingAttribute(subModelProperty);
				if (attribute != null) {
					attributesByProperty.Add(subModelProperty, attribute);
				}
			}
			return attributesByProperty;
		}

		private static ModelMappingAttribute GetModelMappingAttribute(PropertyInfo subModelProperty) {
			return (subModelProperty.GetCustomAttribute(typeof(ModelMappingAttribute)) as ModelMappingAttribute);
		}

		private static bool IsApplicableModelMappingAttribute(ModelMappingAttribute attribute, ModelMappingDirection direction, ModelMappingType type) {
			return IsApplicableDirection(attribute, direction) && attribute.ModelMappingType == type;
		}

		private static bool IsApplicableDirection(ModelMappingAttribute attribute, ModelMappingDirection direction) {
			return (attribute.ModelMappingDirection & direction) != 0;
		}
	}
}