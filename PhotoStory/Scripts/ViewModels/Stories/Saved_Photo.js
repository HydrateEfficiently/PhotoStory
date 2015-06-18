define(function (require) {

	var KnockoutPackage = require("Packages/KnockoutPackage"),
		ko = KnockoutPackage.ko,
		komapping = KnockoutPackage.komapping;

	function Saved_Photo(data, photoPreview) {
		var self = this;

		KnockoutPackage.callFromJS(this, data);
		komapping.fromJS(data, this);
	}

});

