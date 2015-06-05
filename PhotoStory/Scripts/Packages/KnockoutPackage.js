define(function (require) {

	var $ = require("jquery"),
		ko = require("knockout"),
		komapping = require("knockoutmapping");

	var knockoutPackage = {};
	knockoutPackage.$ = $;
	knockoutPackage.ko = ko;
	knockoutPackage.komapping = komapping;

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
			if (!this._hasBeenUpdated) {
				valueAccessor()(element);
				this._hasBeenUpdated = true;
			}
		}
	};

	ko.bindingHandlers.bootstrapFileInput = {
		init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
			require(["fileinput"], function () {
				var fileInput = $(element).fileinput({
					uploadUrl: "http://localhost/file-upload-batch/1", // server upload action
					uploadAsync: true,
					maxFileCount: 20,
					previewFileType: "image",
					previewSettings: {
						image: { width: "120px", height: "auto" }
					},
					layoutTemplates: {
						actions:
								'<div class="file-actions">\n' +
								'    <div class="file-footer-buttons">\n' +
								'        {delete}' +
								'    </div>\n' +
								'    <div class="file-upload-indicator" tabindex="-1" title="{indicatorTitle}">{indicator}</div>\n' +
								'    <div class="clearfix"></div>\n' +
								'</div>'
					}
				});

				valueAccessor()($(fileInput).data('fileinput'));
			});
		}
	};

	ko.bindingHandlers.fileInput = {
		init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
			var value = valueAccessor(),
				name = value.name,
				uploadUrl = value.uploadUrl,
				maxFileCount = isNaN(value.maxFileCount) ? 5 : value.maxFileCount;

			require(["fileinput"], function () {
				$(element).fileinput({
					uploadAsync: true,
					maxFileCount: maxFileCount,
					uploadUrl: uploadUrl,
					previewFileType: "image",
					previewSettings: {
						image: { width: "120px", height: "auto" }
					},
					layoutTemplates: {
						actions:
								'<div class="file-actions">\n' +
								'    <div class="file-footer-buttons">\n' +
								'        {delete}' +
								'    </div>\n' +
								'    <div class="clearfix"></div>\n' +
								'</div>'
					}
				});
			});
			

			viewModel[name](value);
		}
	};

	return knockoutPackage;
});