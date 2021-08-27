"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.FileTypes = void 0;
var FileTypes = /** @class */ (function () {
    function FileTypes() {
        this.EXCEL = { key: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet', value: 'xlsx' };
        this.PDF = { key: 'application/pdf', value: 'pdf' };
    }
    FileTypes.prototype.GetFileExtensionFromMime = function (type) {
        var extension = '';
        switch (type) {
            case this.EXCEL.key:
                extension = this.EXCEL.value;
                break;
            case this.PDF.key:
                extension = this.PDF.value;
                break;
        }
        return extension;
    };
    return FileTypes;
}());
exports.FileTypes = FileTypes;
//# sourceMappingURL=file-types.js.map