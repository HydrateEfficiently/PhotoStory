namespace PhotoStory.ViewModels {

	public abstract class ViewModel<TModel> { //: SubModel<TModel> {

		public ViewModel() { }

		public ViewModel(TModel model) { } // : base(model) { }

		public TModel ToModel() {
			return default(TModel);
		}

	}
}
