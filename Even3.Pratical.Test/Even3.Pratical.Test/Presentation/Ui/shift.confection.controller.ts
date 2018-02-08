/// <reference path="references.ts"/>
/// <reference path="main.ts"/>

class ShiftConfectionController {
    constructor($scope: ng.IScope, confectionService: ConfectionService) {
        var parseFromTimeSpan = function (timeSpan: string): Date {
            return new Date('01 01 1970 ' + timeSpan);
        }

        var parseToTimeSpan = function (date: Date): string {
            return date.getHours() + ":" + date.getMinutes();
        }

        confectionService.setup($scope, 'api/shiftConfection/',
        () => {
            $scope.dayOfWeek = "0";
            $scope.input = null;
            $scope.output = null;
            $scope.interval = null;
        },
        (data) => {
            $scope.dayOfWeek = data.dayOfWeek.toString();
            $scope.input = parseFromTimeSpan(data.input);
            $scope.output = parseFromTimeSpan(data.output);
            $scope.interval = parseFromTimeSpan(data.interval);
        },
        () => {
            return {
                dayOfWeek: parseInt($scope.dayOfWeek),
                input: parseToTimeSpan($scope.input),
                output: parseToTimeSpan($scope.output),
                interval: parseToTimeSpan($scope.interval)
            };
        });
    }
}

main.controller('shiftConfectionController', ['$scope', '$confectionService', ShiftConfectionController]);