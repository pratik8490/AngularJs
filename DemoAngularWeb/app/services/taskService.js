'use strict';
app.factory('taskService', ['$http', '$q', 'ngAuthSettings', function ($http, $q, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var tasksServiceFactory = {};

    var _getTasks = function () {

        return $http.get(serviceBase + 'api/task').then(function (results) {
            return results;
        });
    };

    var _addTasks = function (task) {

        var deferred = $q.defer();

        $http.post(serviceBase + 'api/task/post', task).success(function (response) {

        }).error(function (err, status) {
            deferred.reject(err);
        });

        return deferred.promise;
    };

    var _getComments = function (taskID) {

        return $http.get(serviceBase + 'api/comment?taskID=' + taskID).then(function (results) {
            return results;
        });
    };

    var _addComments = function (comment) {

        var deferred = $q.defer();

        $http.post(serviceBase + 'api/comment/post', comment).success(function (response) {
            return response;
        }).error(function (err, status) {
            deferred.reject(err);
        });

        return deferred.promise;
    };

    tasksServiceFactory.getGetTasks = _getTasks;
    tasksServiceFactory.addTasks = _addTasks;
    tasksServiceFactory.getComments = _getComments;
    tasksServiceFactory.addComments = _addComments;

    return tasksServiceFactory;

}]);
