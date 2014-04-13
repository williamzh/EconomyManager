controllers.controller('LoginCtrl', ['$scope', '$location', 'authService', function($scope, $location, authService) {

	$scope.onSubmit = function() {
		authService.authenticateUser($scope.username, $scope.password, function success() {
			$location.path('/');
		}, function() {
			$scope.credentialsValid = false;
			$scope.errorMessage = 'Invalid username or password.';
		});
	};
}]);