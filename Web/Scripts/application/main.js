(function() {
    'use strict';

    var INTERVAL_LENGTH_IN_MINUTES = 1;

    var module = angular.module('main', ['data']);

    module.controller('MainController', function($scope, $interval, data) {
        $scope.isRunning = false;
        $scope.stop1Messages = [];
        $scope.stop2Messages = [];

        function handleResponse(response) {
            return response.map(function(item, index) {
                return 'Route ' + (index + 1) + ' at ' + item[0] + ' and ' + item[1];
            });
        }

        var intervalHandle;
        $scope.handleClick = function() {
            $scope.isRunning = !$scope.isRunning;

            if ($scope.isRunning) {
                intervalHandle = $interval(function() {
                    data.query({ stopId: 0 }).$promise.then(function(response) {
                        handleResponse(response).forEach(function(message) {
                            $scope.stop1Messages.push(message);
                        });
                    });


                    data.query({ stopId: 1 }).$promise.then(function(response) {
                        handleResponse(response).forEach(function(message) {
                            $scope.stop2Messages.push(message);
                        });
                    });
                }, 1000 * INTERVAL_LENGTH_IN_MINUTES);

                return;
            }

            if (intervalHandle) {
                $interval.cancel(intervalHandle);
            }
        };
    });
}());;