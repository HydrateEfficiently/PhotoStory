define(function (require) {

	var KnockoutPackage = require("Packages/KnockoutPackage"),
		ko = KnockoutPackage.ko,
		FileUploader = require("Util/FileUploader"),
		CollapsiblePanel = require("Util/CollapsiblePanel");

	function Chapter_New() {
		var self = this;
		this._isEnabled = true;

		this.Title = ko.observable();
		this.FileInputElement = ko.observable();
		this.CollapsiblePanelElement = ko.observable();
		this.Photos = ko.observableArray();

		this.FileUploader = new FileUploader(this.FileInputElement, {
			uploadUrl: "/Photo/Upload",
			uploadExtraData: {
				TestData: "I AM A STRING"
			},
			onUploadSuccess: function (event, data, previewId, index) {

			},
			onUploadError: function (event, data, previewId, index) {

			}
		});

		this.CollapsiblePanel = new CollapsiblePanel(this.CollapsiblePanelElement, {
			beforeFirstExpansionCallback: function (expansionAction) {
				setTimeout(function () {
					expansionAction();
				}, 1000);
			}
		});
	}

	return Chapter_New;

});