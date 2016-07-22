(function () {
    "use strict";
    angular
        .module("videoManagement")
        .controller("VideoDetailCtrl",
            ["video",
                VideoDetailCtrl]);

    function VideoDetailCtrl(video) {
        var vm = this;
        vm.video = video;

        vm.title = "Video Detail: " + vm.video.title;


    }
}());