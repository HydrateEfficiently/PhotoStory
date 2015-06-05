define(function (require) {

	var KnockoutPackage = require("Packages/KnockoutPackage"),
		ko = KnockoutPackage.ko,
		$ = require("jquery");

	function FileUploader(elementObservable, options) {
		options = options || {};
		this._whenReadyCallbacks = [];
		this._initUploader(elementObservable, options);		
		this._onUpload = options.onUpload;
	}

	FileUploader.prototype._initUploader = function (elementObservable, options) {
		var self = this;
		elementObservable.subscribeOnce(function (element) {
			require(["fileinput"], function () {
				self._innerFileInput = $(elementObservable()).fileinput({
						uploadAsync: true,
						maxFileCount: 20,
						uploadUrl: options.uploadUrl || "/",
						previewFileType: "image",
						dropZoneTitle: "Drag and drop your images here...",
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
						}});

				if (options.onUploadSuccess) {
					self._innerFileInput.on("fileuploaded", options.onUploadSuccess);
				}

				if (options.onUploadError) {
					self._innerFileInput.on("fileuploaderror", options.onUploadError);
				}

				var callbacks = self._whenReadyCallbacks,
					length = callbacks.length,
					i;

				for (i = 0; i < length; i++) {
					callbacks[i]();
				}
				callbacks.length = 0;
			});
		});
	};

	FileUploader.prototype._isReady = function () {
		return !!this._innerFileInput;
	};

	FileUploader.prototype._doInnerOperation = function (operation, callback) {
		var self = this;

		function innerOperationFunc() {
			self._innerFileInput.fileinput(operation);
			if (callback) {
				callback();
			}
		}

		if (this._isReady()) {
			innerOperationFunc();
		} else {
			this._whenReadyCallbacks.push(innerOperationFunc);
		}
	};

	FileUploader.prototype.disable = function (callback) {
		this._doInnerOperation("disable", callback);
	};

	return FileUploader;
});