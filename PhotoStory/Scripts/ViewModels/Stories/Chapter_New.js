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
			uploadUrl: "/Photo/UploadPhoto",
			uploadExtraData: {
				UserID: 1,
				StoryID: 1,
				ChapterID: 1
			},
			onUploadSuccess: function (event, data, previewId, index) {

			},
			onUploadError: function (event, data, previewId, index) {

			}
		});

		this.CollapsiblePanel = new CollapsiblePanel(this.CollapsiblePanelElement, {
			beforeFirstExpansionCallback: function (expansionAction) {
				if (self.ID() === 0) {
					self.createNew(expansionAction);
				} else {
					expansionAction();
				}
			}
		});
	}

	Chapter_New.prototype.createNew = function (expansionAction) {
		var self = this;
		$.post("/Chapter/CreateNew", komapping.toJS(self))
			.done(function (data) {
				komapping.fromJS(data, self);
				expansionAction();
			})
			.error(function () {
				alert("Error creating new chapter");
			});
	};

	Chapter_New.prototype.saveDraft = function () {
		$.post("/Chapter/SaveDraft", komapping.toJS(this))
			.done(function () {
				alert("Draft saved!");
			})
			.error(function () {
				alert("Draft saving failed!");
			});
	};

	return Chapter_New;

});