define(function (require) {

	var KnockoutPackage = require("Packages/KnockoutPackage"),
		ko = KnockoutPackage.ko,
		$ = require("jquery");

	function Chapter_New() {
		var self = this;
		this.FileInputHandle = ko.observable();
		// this.FileInputHandle.subscribe(function (element) {
		// 	require(["fileinput"], function () {
		// 		self.FileInput = $(element).fileinput({
		// 				uploadUrl: "http://localhost/file-upload-batch/1", // server upload action
		// 				uploadAsync: true,
		// 				maxFileCount: 20,
		// 				previewFileType: "image",
		// 				previewSettings: {
		// 					image: { width: "120px", height: "auto" }
		// 				},
		// 				layoutTemplates: {
		// 					actions:
		// 							'<div class="file-actions">\n' +
		// 							'    <div class="file-footer-buttons">\n' +
		// 							'        {delete}' +
		// 							'    </div>\n' +
		// 							'    <div class="file-upload-indicator" tabindex="-1" title="{indicatorTitle}">{indicator}</div>\n' +
		// 							'    <div class="clearfix"></div>\n' +
		// 							'</div>'
		// 			}
		// 		}).data("fileinput");
		// 	});
		// });

		this.test = ko.observable();
	}

	return Chapter_New;

});