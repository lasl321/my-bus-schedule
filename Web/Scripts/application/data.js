(function() {
    var module = angular.module('data', ['ngResource']);
    var baseUrl = 'http://localhost:64154/api';
    module.factory('data', function($resource) {
        return $resource(baseUrl + '/arrivals/:stopId');
    });
}());