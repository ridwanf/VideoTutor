(function () {
    "use strict";
    angular
        .module("common.services")
        .factory("levelResource",
            ["$resource",
            "appSettings",
            levelResource]);


    function levelResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "api/levels/", null, {

        });
    }
}());