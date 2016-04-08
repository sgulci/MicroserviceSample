(function(app) {
    'use strict';

    app.directive('componentRating', componentRating);

    function componentRating() {
        return {
            restrict: 'A',
            link: function ($scope, $element, $attrs) {
                $element.raty({
                    score: $attrs.componentRating,
                    halfShow: false,
                    readOnly: $scope.isReadOnly,
                    noRatedMsg: "Not rated yet!",
                    starHalf: "../content/images/raty/star-half.png",
                    starOff: "../content/images/raty/star-off.png",
                    starOn: "../content/images/raty/star-on.png",
                    hints: ["Poor", "Average", "Good", "Very Good", "Excellent"],
                    click: function (score, event) {
                        //Set the model value
                        $scope.movie.Rating = score;
                        $scope.$apply();
                    }
                });
            }
        }
    }

})(angular.module('common.ui'));