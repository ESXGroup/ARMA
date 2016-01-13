import {inject} from "aurelia-framework";
import $ = require("jquery");

@inject(Element)
export class App {
    element;
    message = "ARMA Startusp";

    constructor(element) {
        this.element = element;
    }

    userFocusIn(element) {

        var elem = this.element.querySelector(".user-icon");

        $(elem).css("left", "-48px");
    }

    userFocusOut(element) {

        var elem = this.element.querySelector(".user-icon");

        $(elem).css("left", "0px");
    }

    pwFocusIn(element) {

        var elem = this.element.querySelector(".pass-icon");

        $(elem).css("left", "-48px");
    }

    pwFocusOut(element) {

        var elem = this.element.querySelector(".pass-icon");

        $(elem).css("left", "0px");
    }

}