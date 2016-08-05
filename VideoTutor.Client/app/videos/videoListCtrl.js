(function () {
    "use strict";

    angular
        .module("videoManagement")
        .controller("VideoListCtrl",
            ["videoResource", "$scope",
                VideoListCtrl]);

    function VideoListCtrl(videoResource, $scope) {
        var vm = this;

        vm.searchCriteria = "";
        vm.getData = getData;
        vm.searchData = searchData;
        var paginationOptions = {
            pageNumber: 1,
            pageSize: 10,
        };

        //grid options
        vm.videoGrid = {
            paginationPageSizes: [10, 50, 100],
            paginationPageSize: 10,
            enableSorting: true,
            enablePagination: true,
            enableColumnResizing: true,
            enablePaginationControls: true,
            useExternalPagination: true,
            columnDefs: [
              { field: 'title', displayName: 'Title' },
              { field: 'id', visible: false },
              { field: 'author' },
              { field: 'rating' },
              { field: 'technology' },
              { field: 'level' },
              { field: 'releaseDate', cellFilter: 'date' },
              {
                  name: 'Action',
                  cellTemplate: '<a class="btn btn-primary" ui-sref="videoEdit({videoId:row.entity.id})">Edit</a>',
                  width: '100',
                  align: 'center'
              }
            ],
            onRegisterApi: function (gridApi) {
                $scope.gridApi = gridApi;

                gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
                    paginationOptions.pageNumber = newPage;
                    paginationOptions.pageSize = pageSize;
                    getData();
                });
            }
        };

        function getData() {
            videoResource.get(
          {
              //search: vm.searchCriteria,
              pageNumber: paginationOptions.pageNumber,
              pageSize: paginationOptions.pageSize,
              //$filter: "contains(title, '" + vm.searchCriteria + "')" +
              //"or contains(author, '" + vm.searchCriteria + "')",
              //$orderby: vm.sortProperty + " " + vm.sortDirection
          },
          function (data) {
              vm.videoGrid.data = data.data;
              vm.videoGrid.totalItems = data.total;
          });
        }

        function searchData() {
            if (vm.searchCriteria) {
                videoResource.search(
          {
              search: vm.searchCriteria,
              pageNumber: paginationOptions.pageNumber,
              pageSize: paginationOptions.pageSize,
          },
          function (data) {
              vm.videoGrid.data = data.data;
              vm.videoGrid.totalItems = data.total;
          });
            } else {
                getData();
            }

        }

        getData();
    }
}());