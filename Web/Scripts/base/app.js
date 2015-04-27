var myapp = angular.module("myApp", []);

function baseController(viewService) {
    $scope = this;

    $scope.request = function (fun) {
        fun.success(function (data) {
            $scope.viewModel = data;
        })
        .error(function (data) {
            alert(angular.toJson(data));
        })
    }
}

function baseListController(viewService) {
    baseController.call(this, viewService);

    $scope = this;
    $scope.add = function () {
        location.href = "/" + viewService.area + "/" + viewService.name+"/create";
    }
    $scope.search = function () {
        $scope.request(viewService.search($scope.viewModel));
    }
    $scope.commit = function () {
        $scope.request(viewService.create($scope.viewModel));
    }
    $scope.edit = function () {
        $scope.request(viewService.getById($scope.rowData.Id));
    }
    $scope.rowClick = function (rowData) {
        $scope.selectedData = rowData;
    }
}

function baseEditController(viewService) {
    baseController.call(this, viewService);

    $scope = this;

    $scope.submit = function () {
        $scope.request(viewService.create($scope.viewModel));
    }
}
