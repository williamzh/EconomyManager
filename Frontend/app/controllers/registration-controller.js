controllers.controller('RegistrationCtrl', ['$scope', '$location', '$http', function($scope, $location, $http) {
	$scope.hasError = false;

	$scope.onRegister = function() {
		// $http.post('http://localhost:2740/api/auth', {
		// 	UserName: $scope.username,
		// 	Password: $scope.password
		// }).then(function(response) {
		// 	if(response.data.status === 'Ok') {
				
		// 		authService.setToken(response.data.data);
				
		// 		$location.path('/');

		// 		$rootScope.$emit('ev_userAuthenticated');
		// 	}
		// 	else {
		// 		$scope.hasError = true;
		// 		$scope.errorMessage = 'Invalid username or password.';
		// 	}
		// }, function(error) {
		// 	console.error(error);
		// });
	};
}]);