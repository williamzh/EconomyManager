var emSecurity = angular.module('emSecurity', []);

emSecurity.service('authService', ['$cookieStore', '$http', function($cookieStore, $http) {

	this.getToken = function() {
		var authToken = $cookieStore.get('auth');
		
		// TODO: also check expiration
		return authToken ? authToken : null;
	}

	this.clearToken = function() {
		$cookieStore.remove('auth');
	}

	this.authenticateUser = function(username, password, successFn, errorFn) {
		$http.post('http://localhost:2740/api/login', {
			UserName: username,
			Password: password
		}).then(function(response) {
			if(response.data.status === 'Ok') {
				$cookieStore.put('auth', response.data.data);
			}
			else {
				if(errorFn) { errorFn(); }
			}
			
			if(successFn) { successFn(); }
		}, function(error) {
			console.err(error);
		});
	}
	
}]);