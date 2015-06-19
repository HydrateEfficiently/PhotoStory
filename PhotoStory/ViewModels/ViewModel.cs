using AutoMapper;
using System;

namespace PhotoStory.ViewModels {

	public abstract class ViewModel<TModel> {

		public ViewModel() { }

		public ViewModel(TModel model) {
			CreateMapIfNotExists(typeof(TModel), GetType());
			Mapper.Map(model, this);
		}

		public TModel ToModel() {
			CreateMapIfNotExists(GetType(), typeof(TModel));
			return Mapper.Map<TModel>(this);
		}

		private void CreateMapIfNotExists(Type sourceType, Type destinationType) {
			if (Mapper.FindTypeMapFor(sourceType, destinationType) == null) {
				Mapper.CreateMap(sourceType, destinationType);
			}
		}
	}
}
