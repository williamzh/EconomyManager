controllers.controller('MainCtrl', ['$scope', '$rootScope', '$http', 'authService', function($scope, $rootScope, $http, authService) {
	$scope.isAuthenticated = function() {
		return authService.isUserAuthenticated();
	}

	$rootScope.$on('ev_userAuthenticated', function(e) {
		$http.get('http://localhost:2740/api/accounts/' + authService.getToken().value).then(function(response) {
			$scope.user = response.data.data;
		}, function(error) {
			console.error(error);
		});
	});

	// 
}]);