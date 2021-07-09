"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PaginatedResult = exports.FilmParams = void 0;
var FilmParams = /** @class */ (function () {
    function FilmParams(film) {
        this.pageNumber = 1;
        this.pageSize = 5;
        this.titleFilter = "";
    }
    return FilmParams;
}());
exports.FilmParams = FilmParams;
var PaginatedResult = /** @class */ (function () {
    function PaginatedResult() {
    }
    return PaginatedResult;
}());
exports.PaginatedResult = PaginatedResult;
//# sourceMappingURL=films-pagination.model.js.map