(function () {
    "use strict";

    var app = angular.module("videoManagement",
        [
            "common.services",
            "ui.router",
            "ui.bootstrap"
        ]);

    app.config(["$stateProvider", "$urlRouterProvider",
        function ($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise("/");

            $stateProvider
                .state("home", {
                    url: "/",
                    templateUrl: "app/welcomeView.html",
                })
                //videos
                .state("videoList", {
                    url: "/videos",
                    templateUrl: "app/videos/videoListView.html",
                    controller: "VideoListCtrl as vm"
                })

             .state("videoEdit", {
                 url: "/videos/edit/:videoId",
                 templateUrl: "app/videos/videoEditView.html",
                 controller: "VideoEditCtrl as vm",
                 resolve: {
                     videoResource: "videoResource",

                     video: function (videoResource, $stateParams) {
                         var videoId = $stateParams.videoId;
                         return videoResource.get({ id: videoId }).$promise;
                     }
                 }
             })

             .state("videoDetail", {
                 url: "/videos/detail/:videoId",
                 templateUrl: "app/videos/videoDetailView.html",
                 controller: "VideoDetailCtrl as vm",
                 resolve: {
                     videoResource: "videoResource",

                     video: function (videoResource, $stateParams) {
                         var videoId = $stateParams.videoId;
                         return videoResource.get({ id: videoId }).$promise;
                     }
                 }
             })

        }
    ]);
}());