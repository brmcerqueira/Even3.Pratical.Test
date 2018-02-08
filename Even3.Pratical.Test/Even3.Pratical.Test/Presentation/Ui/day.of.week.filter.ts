/// <reference path="references.ts"/>
/// <reference path="main.ts"/>

function dayOfWeekFilter() {
    return function (value: number): string { 
        var result = "";
        switch (value) {
            case 0:
                result = "Domingo";
                break;
            case 1:
                result = "Segunda";
                break;
            case 2:
                result = "Terça";
                break;
            case 3:
                result = "Quarta";
                break;
            case 4:
                result = "Quinta";
                break;
            case 5:
                result = "Sexta";
                break;
            case 6:
                result = "Sábado";
                break;
        }
        return result;
    }
}

main.filter('dayOfWeek', dayOfWeekFilter);