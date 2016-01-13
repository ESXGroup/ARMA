var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") return Reflect.decorate(decorators, target, key, desc);
    switch (arguments.length) {
        case 2: return decorators.reduceRight(function(o, d) { return (d && d(o)) || o; }, target);
        case 3: return decorators.reduceRight(function(o, d) { return (d && d(target, key)), void 0; }, void 0);
        case 4: return decorators.reduceRight(function(o, d) { return (d && d(target, key, o)) || o; }, desc);
    }
};
define(["require", "exports", "aurelia-framework", "jquery"], function (require, exports, aurelia_framework_1, $) {
    var App = (function () {
        function App(element) {
            this.message = "ARMA Startusp";
            this.element = element;
        }
        App.prototype.userFocusIn = function (element) {
            var elem = this.element.querySelector(".user-icon");
            $(elem).css("left", "-48px");
        };
        App.prototype.userFocusOut = function (element) {
            var elem = this.element.querySelector(".user-icon");
            $(elem).css("left", "0px");
        };
        App.prototype.pwFocusIn = function (element) {
            var elem = this.element.querySelector(".pass-icon");
            $(elem).css("left", "-48px");
        };
        App.prototype.pwFocusOut = function (element) {
            var elem = this.element.querySelector(".pass-icon");
            $(elem).css("left", "0px");
        };
        App = __decorate([
            aurelia_framework_1.inject(Element)
        ], App);
        return App;
    })();
    exports.App = App;
});
//# sourceMappingURL=app.js.map