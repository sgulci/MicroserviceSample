(function (app) {
    'use strict';

    app.factory('fileUploadService', fileUploadService);

    fileUploadService.$inject = ['$rootScope', '$http', '$timeout', '$upload', 'notificationService'];

    function fileUploadService($rootScope, $http, $timeout, $upload, notificationService) {

        $rootScope.upload = [];

        var service = {
            uploadImage: uploadImage
        }

        //demo root http://localhost:3000  production root http://localhost:1487
        var root = "http://localhost:1487";

        function uploadImage($files, movieId, callback) {
            //$files: an array of files selected
            for (var i = 0; i < $files.length; i++) {
                var $file = $files[i];
                (function (index) {
                    $rootScope.upload[index] = $upload.upload({
                        url: root + "/api/movies/images/upload?movieId=" + movieId, // webapi url
                        method: "POST",
                        file: $file
                    }).progress(function (evt) {
                    }).success(function (data, status, headers, config) {
                        // file is uploaded successfully
                        notificationService.displaySuccess(data.FileName + ' uploaded successfully');
                        callback();
                    }).error(function (data, status, headers, config) {
                        notificationService.displayError(data.Message);
                    });
                })(i);
            }
        }

        return service;
    }

})(angular.module('common.core'));