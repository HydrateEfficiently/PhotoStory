define(function (require) {

	var KnockoutPackage = require("Packages/KnockoutPackage"),
		ko = KnockoutPackage.ko,
		komapping = KnockoutPackage.komapping,
		Chapter_New = require("ViewModels/Stories/Chapter_New");

	function create(data) {
		var viewModel = komapping.fromJS(data);
		komapping.fromJS(data, viewModel);
		viewModel.Chapter_New = ko.observable(new Chapter_New({
			StoryID: data.StoryID,
			UserID: data.UserID
		}));


		ko.applyBindings(viewModel);
		return viewModel;
	}

	return {
		create: create
	};
});