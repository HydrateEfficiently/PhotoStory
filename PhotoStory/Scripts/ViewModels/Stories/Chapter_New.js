define(function (require) {

	var KnockoutPackage = require("Packages/KnockoutPackage"),
		ko = KnockoutPackage.ko,
		$ = require("jquery");

	function Chapter_New() {
		var self = this;
		this.Title = ko.observable();


		this.test = ko.observable();
	}

	return Chapter_New;

});