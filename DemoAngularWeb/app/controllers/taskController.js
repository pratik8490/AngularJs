'use strict';
app.controller('taskController', ['$scope', '$location', 'taskService', function ($scope, $location, taskService) {

    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.tasks = [];

    $scope.task = {
        title: "",
        description: "",
        dueDate: "",
        label: "",
        rowClass: ""
    };

    $scope.comments = {
        taskId: 0,
        id: 0,
        comment: ''
    };

    $scope.commentList = [];

    taskService.getGetTasks().then(function (results) {

        $scope.tasks = results.data;

    }, function (error) {
        //alert(error.data.message);
    });

    $scope.AddNewTask = function () { $location.path('/addTask'); };

    $scope.saveTask = function () {
        taskService.addTasks($scope.task).then(function (response) {
            $location.path('/task');
        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to add task due to:" + errors.join(' ');
         });
    };

    $scope.getComments = function (id) {

        $scope.comments.taskId = id;

        document.getElementById("commentList").className = "row";
        taskService.getComments(id).then(function (results) {
            if (results.data.length > 0)
                $scope.commentList = results.data;
            else
                $scope.commentList = [];
        }, function (error) {
            //alert(error.data.message);
        });
    };

    $scope.addComment = function () {
        //do api call for save comment
        taskService.addComments($scope.comments).then(function (response) {
            document.getElementById("commentList").className = "disnone";
        },
         function (response) {
             var errors = [];
             for (var key in response.data.modelState) {
                 for (var i = 0; i < response.data.modelState[key].length; i++) {
                     errors.push(response.data.modelState[key][i]);
                 }
             }
             $scope.message = "Failed to add comments due to:" + errors.join(' ');
         });
    };

}]);