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

    $scope.welcome = "hi";
    var canvas = document.getElementById('c');
    var ctx = canvas.getContext('2d');
    $scope.GetBodyType = (id) => {
        $http.get("api/MonsterDetail/Body/"+id).success(function (response) {
            var bodyImage = response.ImageURL;
            console.log(bodyImage);
            $scope.DrawBody(bodyImage);
        }).error(function (error) {
            console.log(error);
        });
    }
    $scope.DrawBody = (bodyimage) => {
        var image = new Image();
        image.src = bodyimage;
        ctx.drawImage(image, 50, 50);
    }
    $scope.DrawHead = (headimage) => {
        var image = new Image();
        image.src = headimage;
        ctx.drawImage(image, 50, 20);
    }
    $scope.DrawArms = (armimage) => {
        var image = new Image();
        image.src = armimage;
        ctx.drawImage(image, 10, 50);
        ctx.drawImage(image, 30, 50);
    }
    $scope.DrawLegs = (legimage) => {
        var image = new Image();
        image.src = legimage;
        cx.drawImage(image, 10, 80);
        ctx.drawImage(image, 30, 80);
    }
    $scope.DrawExtra = (extraimage) => {
        var image = new Image();
        image.src = extraimage;
        ctx.drawImage(image);
    }
    $scope.DrawHeadType = (id) => {
        $http.get("api/MonsterDetail/Head/" + id).success(function (response) {
            var headImage = response.ImageURL;
            $scope.DrawHead(headImage);
            console.log(response);
        }).error(function (error) {
            console.log(error);
        });
    }
    $scope.DrawArmType = (id) => {
        $http.get("api/MonsterDetail/Arm/" + id).success(function (response) {
            var armImage = response.ImageURL;
            $scope.DrawArms(armImage);
            console.log(response);
        }).error(function (error) {
            console.log(error);
        });
    }
    $scope.DrawLegType = (id) => {
        $http.get("api/MonsterDetail/Leg/" + id).success(function (response) {
            var legImage = response.ImageURL;
            $scope.DrawLegs(legImage);
            console.log(response);
        }).error(function (error) {
            console.log(error)
        });
    }
    $scope.DrawAccessoryType = (id) => {
        $http.get("api/MonsterDetail/Accessory/" + id).success(function (response) {
            var extraImage = response.ImageURL;
            $scope.DrawExtra(extraImage);
            console.log(response);
        }).error(function (error) {
            console.log(error);
        });
    }
})

