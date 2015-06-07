define(function (require) {

	var KnockoutPackage = require("Packages/KnockoutPackage"),
		ko = KnockoutPackage.ko,
		komapping = KnockoutPackage.komapping,
		FileUploader = require("Util/FileUploader"),
		CollapsiblePanel = require("Util/CollapsiblePanel");

	function Chapter_New(data) {
		var self = this;
		this._isEnabled = true;

		KnockoutPackage.toTargetFromJS(this, data);
		komapping.fromJS(data, this);

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
				$.post("/Chapter/CreateNew", {
					data: {
						StoryID: self.StoryID,
						UserID: self.UserID
					}
				})
				.done(expansionAction)
				.error(function () {
					alert("Error creating new chapter");
				});
			}
		});
	}

	return Chapter_New;

});