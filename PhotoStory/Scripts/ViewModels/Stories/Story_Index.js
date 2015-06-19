define(function (require) {

	var KnockoutPackage = require("Packages/KnockoutPackage"),
		ko = KnockoutPackage.ko,
		komapping = KnockoutPackage.komapping,
		Chapter_New = require("ViewModels/Stories/Chapter_New");

	function Story_Index(data) {
		var self = this;

		KnockoutPackage.callFromJS(this, data);
		komapping.fromJS(data, this); // TODO: don't map ChapterDraft
		this.Chapter_New = new Chapter_New(data.DraftChapter);
	}

	return Story_Index;
});