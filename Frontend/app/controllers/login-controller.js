controllers.controller('LoginCtrl', ['$scope', '$location', '$http', '$rootScope', 'authService', function($scope, $location, $http, $rootScope, authService) {

	$scope.hasError = false;

	$scope.onSubmit = function() {
		$http.post('http://localhost:2740/api/auth', {
			UserName: $scope.username,
			Password: $scope.password
		}).then(function(response) {
			if(response.data.status === 'Ok') {
				
				authService.setToken(response.data.data);
				
				$location.path('/');

				$rootScope.$emit('ev_userAuthenticated');
			}
			else {
				$scope.hasError = true;
				$scope.errorMessage = 'Invalid username or password.';
			}
		}, function(error) {
			console.error(error);
		});
	};
}]);