(function () {
    "use strict";

    angular
        .module("videoManagement")
        .controller("VideoEditCtrl",
           ["video",'levelResource', "$state", VideoEditCtrl]);

    function VideoEditCtrl(video,levelResource, $state) {
        var vm = this;
        levelResource.query(function(data) {
            vm.levels = data;
        });
        vm.video = video;
        vm.rating = 0;
        vm.ratings = [{
            current: 5,
            max: 10
        }, {
            current: 3,
            max: 5
        }];

        vm.getSelectedRating = function (rating) {
            console.log(rating);
        }
        vm.message = '';
        vm.onlyNumbers = /^\d+$/;

        if (vm.video && vm.video.id) {
            vm.title = "Edit: " + vm.video.title;
        } else {
            vm.title = "New Video";
        }

        vm.submit = function () {
            vm.video.technology = vm.video.technology ? vm.video.technology.toString() : vm.video.technology;
            vm.message = '';
            if (vm.video.id) {
                vm.video.$update({ id: vm.video.id },
                    function (data) {
                        toastr.success("save successful");
                        $state.go('videoList');

                    },
            function (response) {
                vm.message = response.statusText + "\r\n";
                if (response.data.modelState) {
                    for (var key in response.data.modelState) {
                        vm.message += response.data.modelState[key] + "\r\n";
                    }
                }
                if (response.data.exceptionMessage) {
                    vm.message += response.data.exceptionMessage;
                }
            });
            } else {
                vm.video.$save(function (data) {
                    toastr.success("save successful");
                    $state.go('videoList');

                },
            function (response) {
                vm.message = response.statusText + "\r\n";
                if (response.data.modelState) {
                    for (var key in response.data.modelState) {
                        vm.message += response.data.modelState[key] + "\r\n";
                    }
                }
                if (response.data.exceptionMessage) {
                    vm.message += response.data.exceptionMessage;
                }
            });
            }
        };

        vm.cancel = function (editForm) {
            editForm.$setPristine();
            $state.go('videoList');
        };

        vm.open = function($event) {
            $event.preventDefault();
            $event.stopPropagation();

            vm.opened = !vm.opened;
        };

        vm.addTech = function(tech) {
            if (tech) {
                var array = tech.split(',');
                vm.video.techArray = vm.video.techArray ? vm.video.techArray.concat(array) : array;
                vm.newTech = "";
            } else {
                alert("Please enter one or more tech separated by commas");
            }
        };

        vm.removeTech = function(idx) {
            vm.video.techArray.splice(idx, 1);
        };
    }
}());