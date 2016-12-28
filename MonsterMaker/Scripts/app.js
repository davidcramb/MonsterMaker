angular.module("fabric", [])
//.factory('fabric', function ($window) {
//    if ($window.moment) {
//        $window._thirdParty = $window._thirdParty || {};
//        $window._thirdParty.fabric = $window.fabric;
//        try { delete $window.fabric; } catch (e) { $window.moment = undefined }
//    }
//    var fabric = $window._thirdParty.fabric;
//    return fabric;
//});


//angular.module('app').factory('myBadService', [function () {
//    try {
//        fabric();
//    }
//    catch (e) {
//        console.log('fabric is not available globally! Globals bad. ' +
//          'You have to inject it');
//    }
//}]);


var app = angular.module("MonsterMaker", ["fabric"]);
app.controller("MonsterCreateCtrl", function ($scope, $http) {

    //var canvas = document.getElementById('c');
    //var ctx = canvas.getContext('2d');
    var canvas = new fabric.Canvas('c');
   


    $scope.GetBodyType = (id) => {
        $http.get("api/MonsterDetail/Body/" + id).success(function (response) {
            var bodyImage = response.ImageURL;
            $scope.DrawBody(bodyImage);
        }).error(function (error) {
            console.log(error);
        });
    };
    $scope.DrawBody = (bodyImage) => {
        fabric.Image.fromURL(bodyImage, function (oImg) {
            canvas.add(oImg);
        });
    };
    $scope.DrawHead = (headImage) => {
        fabric.Image.fromURL(headImage, function (oImg) {
            canvas.add(oImg);
        });
    };
    $scope.DrawArms = (armImage) => {
        fabric.Image.fromURL(armImage, function (oImg) {
            canvas.add(oImg);
        });
    };
    $scope.DrawLegs = (legImage) => {
        fabric.Image.fromURL(legImage, function (oImg) {
            canvas.add(oImg);
        });
    };
    $scope.DrawAccessory = (accessoryImage) => {
        fabric.Image.fromURL(accessoryImage, function (oImg) {
            canvas.add(oImg);
        });
    };
    $scope.GetHeadType = (id) => {
        $http.get("api/MonsterDetail/Head/" + id).success(function (response) {
            var headImage = response.ImageURL;
            $scope.DrawHead(headImage);
            console.log(response);
        }).error(function (error) {
            console.log(error);
        });
    };
    $scope.GetArmType = (id) => {
        $http.get("api/MonsterDetail/Arm/" + id).success(function (response) {
            var armImage = response.ImageURL;
            $scope.DrawArms(armImage);
            console.log(response);
        }).error(function (error) {
            console.log(error);
        });
    }
    $scope.GetLegType = (id) => {
        $http.get("api/MonsterDetail/Leg/" + id).success(function (response) {
            var legImage = response.ImageURL;
            $scope.DrawLegs(legImage);
            console.log(response);
        }).error(function (error) {
            console.log(error)
        });
    }
    $scope.GetAccessoryType = (id) => {
        $http.get("api/MonsterDetail/Accessory/" + id).success(function (response) {
            var accessoryImage = response.ImageURL;
            $scope.DrawAccessory(accessoryImage);
            console.log(response);
        }).error(function (error) {
            console.log(error);
        });
    }
})

