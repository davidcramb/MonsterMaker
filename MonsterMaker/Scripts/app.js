angular.module("fabric", [])


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
            oImg.set({
                lockMovementX: true,
                lockMovementY: true,
                hasControls: false,
                width: 200,
                height: 350
            });
            canvas.centerObject(oImg);
            canvasElements.body = oImg;
            canvasElements.body.XY = canvasElements.body.calcCoords();
            console.log(oImg);
            canvas.add(oImg);
        });
    };
    $scope.DrawHead = (headImage) => {
        fabric.Image.fromURL(headImage, function (oImg) {
            checkIfCanvasObjectExists(canvasElements.head)
            canvas.add(oImg.set({
                originX: 'center',
                left: ((canvasElements.body.XY.tl.x + canvasElements.body.XY.tr.x) / 2),
                height: 200,
                width: 150
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
                originX: 'right',
                left: canvasElements.body.XY.ml.x,
                top: canvasElements.body.XY.ml.y,
                width: 250,
                height: 60
            });
            canvasElements.leftArm = leftArm;
            canvas.add(leftArm);
        });
        fabric.Image.fromURL(armImage, function (oImg) {
            checkIfCanvasObjectExists(canvasElements.rightArm);
            var rightArm = oImg;
            rightArm.set({
                originX: 'left',
                left: canvasElements.body.XY.mr.x,
                top: canvasElements.body.XY.mr.y,
                width: 250,
                height: 60
            });
            rightArm.set('flipX', true);
            canvasElements.rightArm = rightArm;
            canvas.add(rightArm);
        });
    };
    $scope.DrawLegs = (legImage) => {
        var legGroup = new fabric.Group([]);
        fabric.Image.fromURL(legImage, function (oImg) {
            checkIfCanvasObjectExists(canvasElements.leftLeg)
            var leftLeg = oImg;
            leftLeg.set({
                originX: 'right',
                left: canvasElements.body.XY.bl.x,
                top: canvasElements.body.XY.bl.y,
                height: 230,
                width: 70
            });
            canvasElements.leftLeg = leftLeg;
            canvas.add(leftLeg);
        });
        fabric.Image.fromURL(legImage, function (oImg) {
            checkIfCanvasObjectExists(canvasElements.rightLeg);
            var rightLeg = oImg;
            rightLeg.set({
                originX: 'left',
                left: canvasElements.body.XY.br.x,
                top: canvasElements.body.XY.br.y,
                height: 230,
                width: 70
            });
            canvasElements.rightLeg = rightLeg;
            canvas.add(rightLeg);
        });

    };
    $scope.DrawAccessory = (accessoryImage) => {
        fabric.Image.fromURL(accessoryImage, function (oImg) {
            checkIfCanvasObjectExists(canvasElements.accessory)
            canvas.add(oImg.set({
                height: 50,
                width: 50
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
        userMonster.MakerId = $('#makerId').val();
        var monster = userMonster;
        console.log(monster);
        $http.post("/MonsterDetail/Monsters", monster).success(function (response) {
            console.log(response)
        }).error(function (error) {
            console.log(error)
        });
    };
});
app.controller("MonsterListCtrl", function ($q, $scope, $http) {
    var canvas = new fabric.StaticCanvas('c');
    var canvasElements = {};
    $scope.allMonsters = [];
    $scope.currentUserMonsters = [];
    $scope.runUserGet = false;
    $scope.selected = { value: 0 };

    $scope.populateLists = () => {
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
    };
    $scope.populateLists();



    $scope.viewUserMonster = (id) => {
        let monsters = $scope.allMonsters;

        for (let i = 0; i < monsters.length; i++) {
            let currentMonster = monsters[i];
            if (currentMonster.MonsterId === id) {
                console.log(currentMonster.MonsterName);
                canvasElements = currentMonster.canvasData;
            };
        };
        drawMonsterToPage(canvasElements);
    };

    $scope.deleteMonster = (id) => {
        console.log('monsterid', id);
        $http.delete('api/MonsterList/Monsters/' + id).success(function (response) {
            console.log(response);
            $scope.populateLists();
        }).error(function (error) {
            console.log(error);
        });
    };
        
    
    
    var drawMonsterToPage = (data) => {
            canvas.loadFromJSON(data, canvas.renderAll.bind(canvas));

        };
});

app.controller("BattleCtrl", function ($scope, $http) {
    var currentUserId = $('#makerId').val()
    var p1Canvas = new fabric.Canvas('c1');
    var p2Canvas = new fabric.Canvas('c2');
    $scope.selected = { value: 0 };

    $scope.currentUserMonsters = [];
    $scope.allOtherMonsters = [];

    $scope.drawToP1CanvasArea = (id) =>
    {
        let monster = $scope.currentUserMonsters[id];
        let data = monster.canvasData;
        p1Canvas.loadFromJSON(data);
        P1Canvas.renderAll();
    };
    $scope.drawToP2CanvasArea = (id) =>
    {
        let monster = $scope.allOtherMonsters[id];
        let data = monster.canvasData;
        p2Canvas.loadFromJSON(data);
        P2Canvas.renderAll();
    };


    $http.get("http://localhost:49263/MyMonsters/api/MonsterList/User/" + currentUserId).success(function (response) {
        $scope.currentUserMonsters = response;
        console.log(response);
        return $scope.currentUserMonsters;
    }).error(function (error) {
        console.log(error);
    });

    $http.get("http://localhost:49263/MyMonsters/api/MonsterList/Monsters/").success(function (response) {
        console.log(response);
        $scope.allOtherMonsters = response;
        return $scope.allOtherMonsters;
    }).error(function (error) {
        console.log(error);
    });


});

