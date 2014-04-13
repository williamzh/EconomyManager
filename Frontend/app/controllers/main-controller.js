controllers.controller('MainCtrl', ['$scope', 'authService', function($scope, authService) {
	$scope.isAuthenticated = function() {
		return authService.getToken() !== null;
	}
}]);