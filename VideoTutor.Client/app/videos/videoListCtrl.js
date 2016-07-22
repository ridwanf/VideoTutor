(function () {
    "use strict";

    angular
        .module("videoManagement")
        .controller("VideoListCtrl",
            ["videoResource",
                VideoListCtrl]);

    function VideoListCtrl(videoResource) {
        var vm = this;

        vm.searchCriteria = "";
        vm.sortProperty = "Title";
        vm.sortDirection = "desc";

        videoResource.query(
            {
                $filter: "contains(Title, '" + vm.searchCriteria + "')" +
                "or contains(Author, '" + vm.searchCriteria + "')",
                $orderby: vm.sortProperty + " " + vm.sortDirection
            },
            function (data) {
                vm.videos = data;
            });
    }
}());