using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.Data.Relational.Entities {

	public abstract class Entity<TModel> {

		public Entity() { }

		public Entity(TModel model) {
			ForEachMappedProperty((entityPropertyInfo, modelPropertyInfo) => {
				entityPropertyInfo.SetValue(this, modelPropertyInfo.GetValue(model));
			});
		}

		public TModel ToModel() {
			var instance = (TModel)Activator.CreateInstance(typeof(TModel));
			ForEachMappedProperty((entityPropertyInfo, modelPropertyInfo) => {
				modelPropertyInfo.SetValue(instance, entityPropertyInfo.GetValue(this));
			});
			return instance;
		}

		private void ForEachMappedProperty(Action<PropertyInfo, PropertyInfo> action) {
			var propertiesInfo = GetType().GetProperties();
			foreach (var propertyInfo in propertiesInfo) {
				PropertyInfo modelPropertyInfo;
				if (TryGetMappedProperty(propertyInfo, out modelPropertyInfo)) {
					action(propertyInfo, modelPropertyInfo);
				}
			}
		}

		private bool TryGetMappedProperty(PropertyInfo entityPropertyInfo, out PropertyInfo modelPropertyInfo) {
			var modelMappingAttr = (ModelMappingAttribute)entityPropertyInfo.GetCustomAttribute(typeof(ModelMappingAttribute));
			if (modelMappingAttr == null) {
				modelPropertyInfo = null;
				return false;
			} else {
				string modelPropertyName = modelMappingAttr.ModelPropertyName ?? entityPropertyInfo.Name;
				modelPropertyInfo = typeof(TModel).GetProperty(modelPropertyName);
				return true;
			}
		}
	}
}
