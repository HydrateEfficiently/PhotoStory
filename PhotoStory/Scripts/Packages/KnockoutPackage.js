define(function (require) {

	var $ = require("jquery"),
		ko = require("knockout"),
		komapping = require("knockoutmapping");

	var knockoutPackage = {};
	knockoutPackage.$ = $;
	knockoutPackage.ko = ko;
	knockoutPackage.komapping = komapping;

	knockoutPackage.toTargetFromJS = function (target, data) {
		var viewModel = komapping.fromJS(data);
		$.extend(target, viewModel);
	};

	ko.bindingHandlers.valueOrPlaceholder = {
		init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
			ko.bindingHandlers.value.init(element, valueAccessor, allBindings, viewModel, bindingContext);
		},

		update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
			var value = valueAccessor(),
				text = value() || element.placeholder;
			value(text);
			ko.bindingHandlers.value.update(element, valueAccessor, allBindings, viewModel, bindingContext);
		}
	};

	// Gives access to the element, for integration with non-Knockout operations
	ko.bindingHandlers.element = {
		update: function (element, valueAccessor) {
			valueAccessor()(element);
		}
	};

	ko.subscribable.fn.subscribeOnce = function (handler, owner, eventName) {
		var subscription = this.subscribe(function (newValue) {
				subscription.dispose();
				handler(newValue);
			}, owner, eventName);
		return subscription;
	};

	return knockoutPackage;
});