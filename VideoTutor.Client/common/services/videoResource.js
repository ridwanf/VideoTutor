(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("videoResource",
            ["$resource",
                "appSettings",
                videoResource]);

    function videoResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "api/videos/:id", null, {
            'update': { method: 'PUT' },
            
        });
    }
}());