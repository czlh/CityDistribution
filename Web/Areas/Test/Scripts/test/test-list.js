myapp.controller("myController", function ($scope, Site) {
    baseListController.call($scope, Site);
    
    $scope.search(null);
});