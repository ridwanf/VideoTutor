(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("videoResource",
            ["$resource",
                "appSettings",
                "currentUser",
                videoResource]);

    function videoResource($resource, appSettings, currentUser) {
        return $resource(appSettings.serverPath + "/api/videos/:id", null, {
            'search': {
                method: 'GET',
                params: { search: '@search', pageSize: '@pageSize', pageNumber: '@pageNumber' },
                headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token },
            },
            'get': {
                params: { pageSize: '@pageSize', pageNumber: '@pageNumber' },
                headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token },
            },
            'save': {
                headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
            },

            'update': {
                method: 'PUT',
                headers: { 'Authorization': 'Bearer ' + currentUser.getProfile().token }
            }

        });
    }
}());