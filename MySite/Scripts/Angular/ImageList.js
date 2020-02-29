var App = angular.module("ImageListApp", []);

App.controller("ImageListController", function ($scope, $http) {

    $scope.init = function () {
        UpdateImageList();
    }

    $scope.ShowImages = function () {
        UpdateImageList();
    }

    function UpdateImageList() {
        //https://www.w3schools.com/angular/angular_http.asp
        $http.get("/SiteImages/ImageList?ContentDataId=123")
            .then(function (data) {
                $scope.ImageList = angular.fromJson(data.data);
            }, function (response) { console.log("Error" + response) });
    }
});