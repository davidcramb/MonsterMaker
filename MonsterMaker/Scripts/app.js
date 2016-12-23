var app = angular.module("MonsterMaker", []);

app.controller("MonsterCreateCtrl", function ($scope, $http) {
    $scope.welcome = "hi";

    $scope.DrawBodyType = (id) => {
        $http.get("api/MonsterDetail/Body/"+id).success(function (response) {
            console.log(response);
        }).error(function (error) {
            console.log(error);
        });
    }
    $scope.DrawHeadType = (id) => {
        $http.get("api/MonsterDetail/Head/" + id).success(function (response) {
            console.log(response);
        }).error(function (error) {
            console.log(error);
        });
    }
    $scope.DrawArmType = (id) => {
        $http.get("api/MonsterDetail/Arm/" + id).success(function (response) {
            console.log(response);
        }).error(function (error) {
            console.log(error);
        });
    }
    $scope.DrawLegType = (id) => {
        $http.get("api/MonsterDetail/Leg/" + id).success(function (response) {
            console.log(response);
        }).error(function (error) {
            console.log(error)
        });
    }
    $scope.DrawAccessoryType = (id) => {
        $http.get("api/MonsterDetail/Accessory/" + id).success(function (response) {
            console.log(response);
        }).error(function (error) {
            console.log(error);
        });
    }
})
