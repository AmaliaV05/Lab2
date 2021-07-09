"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Comment = exports.GENRE = exports.Genre = exports.Film = void 0;
var Film = /** @class */ (function () {
    function Film() {
    }
    return Film;
}());
exports.Film = Film;
var Genre;
(function (Genre) {
    Genre[Genre["Action"] = 0] = "Action";
    Genre[Genre["Comedy"] = 1] = "Comedy";
    Genre[Genre["Horror"] = 2] = "Horror";
    Genre[Genre["Thriller"] = 3] = "Thriller";
})(Genre = exports.Genre || (exports.Genre = {}));
exports.GENRE = ['Action', 'Comedy', 'Horror', 'Thriller'];
var Comment = /** @class */ (function () {
    function Comment() {
    }
    return Comment;
}());
exports.Comment = Comment;
//# sourceMappingURL=films.model.js.map