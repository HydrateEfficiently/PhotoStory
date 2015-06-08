define(function (require) {

	var KnockoutPackage = require("Packages/KnockoutPackage"),
		ko = KnockoutPackage.ko,
		komapping = KnockoutPackage.komapping,
		FileUploader = require("Util/FileUploader"),
		CollapsiblePanel = require("Util/CollapsiblePanel");

	function Chapter_New(data) {
		var self = this;
		this._isEnabled = true;

		KnockoutPackage.callFromJS(this, data);
		komapping.fromJS(data, this);

		this.FileInputElement = ko.observable();
		this.CollapsiblePanelElement = ko.observable();

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
				$.post("/Chapter/CreateNew", komapping.toJS(self))
					.done(function (data) {
						komapping.fromJS(data, self);
						expansionAction();
					})
					.error(function () {
						alert("Error creating new chapter");
					});
			}
		});
	}

	Chapter_New.prototype.saveDraft = function () {
		var self = this;
		$.post("/Chapter/SaveDraft", komapping.toJS(this))
			.done(function () {
				komapping.fromJS(data, self);
				alert("Draft saved!");
			})
			.error(function () {
				alert("Draft saving failed!");
			});
	};

	return Chapter_New;

});