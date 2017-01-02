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
    };


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
    };
    $scope.GetLegType = (id) => {
        $http.get("api/MonsterDetail/Leg/" + id).success(function (response) {
            var legImage = response.ImageURL;
            $scope.DrawLegs(legImage);
            userMonster.LegId = response.LegId;
            console.log(response);
        }).error(function (error) {
            console.log(error)
        });
    };
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
            //canvas.add(oImg.set({
            //    type: "body",
            //    lockMovementX : true,
            //    lockMovementY : true,
            //    hasControls:false
            //}));
            oImg.set({
                type: 'body',
                lockMovementX: true,
                lockMovementY: true,
                hasControls: false
            });
            canvas.centerObject(oImg);
            canvasElements.body = oImg;
            canvasElements.body.XY = canvasElements.body.calcCoords();
            //var testcircleleft = new fabric.Circle({ radius: 10, top: 125, left: 200 }); //delete
            //var testcircleright = new fabric.Circle({ radius: 10, top: 125, left: 400 }) //delete
            canvas.add(oImg);
        });
        console.log(canvasElements.body)
    };
    $scope.DrawHead = (headImage) => {
        fabric.Image.fromURL(headImage, function (oImg) {
            checkIfCanvasObjectExists(canvasElements.head)
            canvas.add(oImg.set({
                type: 'head',
                originX: 'center',
                left: ((canvasElements.body.XY.tl.x + canvasElements.body.XY.tr.x) / 2)
            }));
            canvasElements.head = oImg;
        });
    };
    $scope.DrawArms = (armImage) => {
        var armGroup = new fabric.Group([]);
        fabric.Image.fromURL(armImage, function (oImg) {
            checkIfCanvasObjectExists(canvasElements.leftArm)
            var leftArm = oImg;
            leftArm.set({
                type: 'leftarm',
                originX: 'right',
                left: canvasElements.body.XY.ml.x,
                top: canvasElements.body.XY.ml.y
            });
            canvasElements.leftArm = leftArm;
            console.log(leftArm);
            canvas.add(leftArm);
        });
        fabric.Image.fromURL(armImage, function (oImg) {
            checkIfCanvasObjectExists(canvasElements.rightArm);
            var rightArm = oImg;
            rightArm.set({
                type: 'rightarm',
                originX: 'left',
                left: canvasElements.body.XY.mr.x,
                top: canvasElements.body.XY.mr.y
            });
            canvasElements.rightArm = rightArm;
            console.log(rightArm);
            canvas.add(rightArm);
        });
    };
    $scope.DrawLegs = (legImage) => {
        var legGroup = new fabric.Group([]);
        fabric.Image.fromURL(legImage, function (oImg) {
            checkIfCanvasObjectExists(canvasElements.leftLeg)
            var leftLeg = oImg;
            leftLeg.set({
                type: 'leftleg',
                originX: 'right',
                left: canvasElements.body.XY.bl.x,
                top: canvasElements.body.XY.bl.y
            });
            canvasElements.leftLeg = leftLeg;
            console.log(leftLeg);
            canvas.add(leftLeg);
        });
        fabric.Image.fromURL(legImage, function (oImg) {
            checkIfCanvasObjectExists(canvasElements.rightLeg);
            var rightLeg = oImg;
            rightLeg.set({
                type: 'rightleg',
                originX: 'left',
                left: canvasElements.body.XY.br.x,
                top: canvasElements.body.XY.br.y
            });
            canvasElements.rightLeg = rightLeg;
            console.log(rightLeg);
            canvas.add(rightLeg);
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
        };
        userMonster.monsterName = $scope.name;
        var monster = userMonster;
        console.log(monster);
        $http.post("/MonsterDetail/Monsters", monster).success(function (response) {
            console.log(response)
        }).error(function (error) {
            console.log(error)
        });
    };
});
app.controller("MonsterListCtrl", function ($scope, $http) {
    var canvas = new fabric.Canvas('c');
    var canvasElements = {};
    $scope.allMonsters = [];
    $scope.currentUserMonsters = [];
    $scope.runUserGet = false;
    barg = $scope.allMonsters;
    
    $http.get("api/MonsterList/Monsters/").success(function (response) {
        $scope.allMonsters = response;
        console.log(response)
            return $scope.allMonsters
        }).error(function (error) {
              console.log(error)
        });
    $http.get("api/MonsterList/User/" + $('#makerId').val()).success(function (response) {
        $scope.currentUserMonsters = response;
        console.log(response)
        return $scope.currentUserMonsters
    }).error(function (error) {
        console.log(error)
    });
    
    $scope.viewUserMonster = (id) =>
    {
        let monsters = $scope.allMonsters;
        let poop = id;
        for (let i = 0; i <= $scope.allMonsters.length; i++)
        {
            console.log(monsters[i].MonsterId)
            if (monsters[i].MonsterId == poop)
            {
                canvasElements = $scope.allMonsters[i].canvasData;
            }
        }
        drawMonsterToPage(canvasElements);
    }
    var drawMonsterToPage = (data) =>
    {
        canvas.loadFromJSON(data);
    }
    
});

var barg;

