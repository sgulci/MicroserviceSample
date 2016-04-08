(function (app) {
    'use strict';

    app.factory('apiService', apiService);

    apiService.$inject = ['$http', '$location', 'notificationService','$rootScope'];

    function apiService($http, $location, notificationService, $rootScope) {
        var service = {
            get: get,
            post: post
        };

        //demo root http://localhost:3000  production root http://localhost:1487
        var root = "http://217.78.97.197:3000";
        var MS_demo_login_root = "http://217.78.97.197:5001/api/gateway/authenticate/test";
        var MS_demo_movie_latest_root = "http://217.78.97.197:5001/api/gateway/movies/latest";

        function get(url, config, success, failure) {
                          
                 if (url.indexOf("movies/latest") > -1) {
                console.log("latest movies service call");
                return $http.get(MS_demo_movie_latest_root, config)
                                   .then(function (result) {
                                       success(result);
                                   }, function (error) {
                                       if (error.status == '401') {
                                           notificationService.displayError('Authentication required.');
                                           $rootScope.previousState = $location.path();
                                           $location.path('/login');
                                       }
                                       else if (failure != null) {
                                           failure(error);
                                       }
                                   });
            } else {
                return $http.get(root + url, config)
                              .then(function (result) {
                                  success(result);
                              }, function (error) {
                                  if (error.status == '401') {
                                      notificationService.displayError('Authentication required.');
                                      $rootScope.previousState = $location.path();
                                      $location.path('/login');
                                  }
                                  else if (failure != null) {
                                      failure(error);
                                  }
                              });
            }
           
        }

        function post(url, data, success, failure) {

            if (url.indexOf("authenticate") > -1) {
                console.log("login service call");
                return $http.get(MS_demo_login_root, data)
                                    .then(function (result) {
                                        success(result);
                                    }, function (error) {
                                        if (error.status == '401') {
                                            notificationService.displayError('Authentication required.');
                                            $rootScope.previousState = $location.path();
                                            $location.path('/login');
                                        }
                                        else if (failure != null) {
                                            failure(error);
                                        }
                                    });
            } else {
                console.log(4);
                return $http.post(root + url, data)
                                  .then(function (result) {
                                      success(result);
                                  }, function (error) {
                                      if (error.status == '401') {
                                          notificationService.displayError('Authentication required.');
                                          $rootScope.previousState = $location.path();
                                          $location.path('/login');
                                      }
                                      else if (failure != null) {
                                          failure(error);
                                      }
                                  });
            }

          
        }

        return service;
    }

})(angular.module('common.core'));