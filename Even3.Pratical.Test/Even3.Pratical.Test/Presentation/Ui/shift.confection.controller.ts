/// <reference path="references.ts"/>
/// <reference path="main.ts"/>

class ShiftConfectionController {
    constructor($scope: ng.IScope, $http: ng.IHttpService, keyService: KeyService) {
        var url = 'api/shiftConfection/';

        var key = keyService.key
        keyService.key = null;

        var init = () => {
            $scope.dayOfWeek = "0";
            $scope.input = null;
            $scope.output = null;
            $scope.interval = null;
        };

        var parseFromTimeSpan = function(timeSpan: string): Date {
            return new Date('01 01 1970 ' + timeSpan);
        }

        var parseToTimeSpan = function(date: Date): string {
            return date.getHours() + ":" + date.getMinutes();
        }

        init();

        if (key) {
            $http.get(url + key).then(function (response) {
                var data: any = response.data;
                $scope.dayOfWeek = data.dayOfWeek.toString();
                $scope.input = parseFromTimeSpan(data.input);
                $scope.output = parseFromTimeSpan(data.output);
                $scope.interval = parseFromTimeSpan(data.interval);
            });
        }
   
        $scope.save = () => {
            var entity = {
                dayOfWeek: parseInt($scope.dayOfWeek),
                input: parseToTimeSpan($scope.input),
                output: parseToTimeSpan($scope.output),
                interval: parseToTimeSpan($scope.interval)
            };

            if (key) {
                $http.post(url + key, entity).then(function () {
                    alert("salvo!");
                }, function (reason) {
                    alert(reason.data.exceptionMessage);
                });
            }
            else {
                $http.put(url, entity).then(function () {
                    alert("salvo!");
                    init();
                }, function (reason) {
                    alert(reason.data.exceptionMessage);
                });
            }
        }
    }

   
}

main.controller('shiftConfectionController', ['$scope', '$http', "$keyService", ShiftConfectionController]);