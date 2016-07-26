(function() {
    "use strict";
    angular
        .module("videoManagement")
        .controller("LoginCtrl", ["auth0", LoginCtrl]);

    function LoginCtrl() {
        
    }
}());


angular.module('videoManagement', ['auth0'])
.controller('LoginCtrl', function ($scope, auth, $location, store) {
    $scope.login = function() {
        auth.signin({
                authParams: {
                    scope: 'openid offline_access'
                }
            }, function(profile, token, access_token, state, refresh_token) {
                store.set('profile', profile);
                store.set('token', token);
                store.set('refreshToken', refresh_token);
                $location.path('/');
            }, function(error) {
                console.log("There was an error", error);
            });
    };
});