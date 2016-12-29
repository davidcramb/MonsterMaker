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

    var canvas = new fabric.Canvas('c');
    var userMonster = {};
    var canvasElements = {};
    var checkIfCanvasObjectExists = (obj) => {
        if (canvas.contains(obj)) {
            canvas.remove(obj);
        };
    }
   
    $scope.GetBodyType = (id) => {
        $http.get("api/MonsterDetail/Body/" + id).success(function (response) {
            var bodyImage = response.ImageURL;
            $scope.DrawBody(bodyImage);
            userMonster.BodyId = response.BodyId;
            console.log(userMonster);
        }).error(function (error) {
            console.log(error);
        });
    };
    $scope.GetHeadType = (id) => {
        $http.get("api/MonsterDetail/Head/" + id).success(function (response) {
            var headImage = response.ImageURL;
            $scope.DrawHead(headImage);
            userMonster.HeadId = response.HeadId;
            console.log(response);
        }).error(function (error) {
            console.log(error);
        });
    };
    $scope.GetArmType = (id) => {
        $http.get("api/MonsterDetail/Arm/" + id).success(function (response) {
            var armImage = response.ImageURL;
            $scope.DrawArms(armImage);
            userMonster.ArmId = response.ArmId;
            console.log(response);
        }).error(function (error) {
            console.log(error);
        });
    }
    $scope.GetLegType = (id) => {
        $http.get("api/MonsterDetail/Leg/" + id).success(function (response) {
            var legImage = response.ImageURL;
            $scope.DrawLegs(legImage);
            userMonster.LegId = response.LegId;
            console.log(response);
        }).error(function (error) {
            console.log(error)
        });
    }
    $scope.GetAccessoryType = (id) => {
        $http.get("api/MonsterDetail/Accessory/" + id).success(function (response) {
            var accessoryImage = response.ImageURL;
            $scope.DrawAccessory(accessoryImage);
            userMonster.AccessoryId = response.AccessoryId;
            console.log(response);
        }).error(function (error) {
            console.log(error);
        });
    };
    
    $scope.DrawBody = (bodyImage) => {
        fabric.Image.fromURL(bodyImage, function (oImg) {
            checkIfCanvasObjectExists(canvasElements.body)
            canvas.add(oImg.set({
                type: "body",
                hasControls:false
            }));
            canvas.centerObject(oImg);
            canvasElements.body = oImg;
            console.log(canvasElements);
        });
    };
    $scope.DrawHead = (headImage) => {
        fabric.Image.fromURL(headImage, function (oImg) {
            checkIfCanvasObjectExists(canvasElements.head)

            canvas.add(oImg.set({
                type: "head"
            }));
            canvasElements.head = oImg;
        });
    };
    $scope.DrawArms = (armImage) => {
        fabric.Image.fromURL(armImage, function (oImg) {
            checkIfCanvasObjectExists(canvasElements.arm1)
            checkIfCanvasObjectExists(canvasElements.arm2)

            canvas.add(oImg.set({
                type: "arm"
            }));
            canvasElements.arm1 = oImg;
            canvasElements.arm2 = oImg;
        });
    };
    $scope.DrawLegs = (legImage) => {
        fabric.Image.fromURL(legImage, function (oImg) {
            checkIfCanvasObjectExists(canvasElements.leg1)
            checkIfCanvasObjectExists(canvasElements.leg2)

            canvas.add(oImg.set({
                type: "leg"
            }));
            canvasElements.leg1 = oImg;
            canvasElements.leg2 = oImg;
        });
    };
    $scope.DrawAccessory = (accessoryImage) => {
        fabric.Image.fromURL(accessoryImage, function (oImg) {
            checkIfCanvasObjectExists(canvasElements.accessory)

            canvas.add(oImg.set({
                type: "accessory"
            }));
            canvasElements.accessory = oImg;
        });
    };
    

    $scope.SaveMonster = () => {
        var data = canvas.toJSON();
        console.log(data);
        userMonster.canvasData = JSON.stringify(data);
        if ($scope.name == null) {
            alert("Name your monster!");
            return;
        }
        userMonster.monsterName = $scope.name;
        var monster = userMonster;
        console.log(monster);
        $http.post("/MonsterDetail/Monsters", monster).success(function (response) {
            console.log(response)
        }).error(function(error){
            console.log(error)
        });
    }
})

