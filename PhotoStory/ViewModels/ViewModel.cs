using PhotoStory.Models.Account;
using PhotoStory.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.ViewModels {

	public abstract class ViewModel<TModel> : SubModel<TModel> {

		public ViewModel() { }

		public ViewModel(TModel model) : base(model) { }

	}
}
