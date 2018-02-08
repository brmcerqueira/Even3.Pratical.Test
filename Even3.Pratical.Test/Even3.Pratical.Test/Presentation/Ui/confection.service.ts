/// <reference path="references.ts"/>
/// <reference path="main.ts"/>

class ConfectionService {
    constructor(private $http: ng.IHttpService, private keyService: KeyService) {
    }

    public setup(scope: ng.IScope, url: string, init: () => void, load: (data: any) => void, prepareToSave: () => any) {
        var key = this.keyService.key
        this.keyService.key = null;

        init();

        if (key) {
            this.$http.get(url + key).then(function (response) {
                load(response.data);
            });
        }

        scope.save = () => {
            var entity = prepareToSave();

            if (key) {
                this.$http.post(url + key, entity).then(function () {
                    alert("salvo!");
                }, function (reason) {
                    alert(reason.data.exceptionMessage);
                });
            }
            else {
                this.$http.put(url, entity).then(function () {
                    alert("salvo!");
                    init();
                }, function (reason) {
                    alert(reason.data.exceptionMessage);
                });
            }
        }
    }
}

main.service('$confectionService', ['$http', "$keyService", ConfectionService]);