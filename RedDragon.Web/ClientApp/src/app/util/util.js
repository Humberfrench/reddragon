"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Util = /** @class */ (function () {
    function Util() {
    }
    Util.prototype.IsNumeric = function (val) {
        return !(val instanceof Array) && (val - parseFloat(val) + 1) >= 0;
    };
    return Util;
}());
exports.Util = Util;
;
//# sourceMappingURL=util.js.map