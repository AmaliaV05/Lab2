"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var reservations_service_1 = require("./reservations.service");
describe('ReservationsService', function () {
    beforeEach(function () { return testing_1.TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = testing_1.TestBed.get(reservations_service_1.ReservationsService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=reservations.service.spec.js.map