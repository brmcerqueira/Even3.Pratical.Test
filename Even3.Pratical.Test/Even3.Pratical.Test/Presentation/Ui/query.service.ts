/// <reference path="references.ts"/>
/// <reference path="main.ts"/>

class QueryService {
    constructor(private $http: ng.IHttpService, private $location: ng.ILocationService, private keyService: KeyService) {
    }

    public setup(scope: ng.IScope, editRoute: string, removeRoute: string, queryRoute: string) {
        scope.source = [];

        scope.edit = (id: number) => {
            this.keyService.key = id;
            this.$location.path(editRoute);
        }

        scope.remove = (id: number) => {
            if (confirm("Deseja excluir esse item?")) {
                this.$http.delete(removeRoute + id).then(function () {
                    alert("excluido!");
                    updateSource();
                }, errorCallback);
            }
        }

        var updateSource = () => {
            this.$http.put(queryRoute, {}).then(function (response) {
                scope.source = response.data;
            }, errorCallback);
        }

        updateSource();
    }
}

main.service('$queryService', ['$http', '$location', "$keyService", QueryService]);