define(function (require) {

	var ko = require("knockout"),
		komapping = require("knockoutmapping");

	function create(data) {
		var viewModel = komapping.fromJS(data);
		komapping.fromJS(data, viewModel);

		viewModel.testF = function () {
			console.log("test");
		};

		viewModel.test = ko.observable("Test");

		ko.applyBindings(viewModel);
		return viewModel;
	}

	return {
		create: create
	};
});