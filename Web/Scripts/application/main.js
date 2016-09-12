(function() {
    'use strict';

    var module = angular.module('main', ['data']);

    module.controller('MainController', function($scope, $interval, data) {
        $scope.isRunning = false;
        $scope.messages = [];

        var handle;
        $scope.handleClick = function() {
            $scope.isRunning = !$scope.isRunning;

            if ($scope.isRunning) {
                handle = $interval(function() {
                    data.get({ stopId: 0 }).$promise.then(function(response) {
                        $scope.messages.push(response);
                    });
                }, 1000);

                return;
            }

            if (handle) {
                $interval.cancel(handle);
            }
        };
    });
}())