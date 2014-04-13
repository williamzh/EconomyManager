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
			$cookieStore.put('auth', response.data.data);		//william:test1234
			
			if(successFn) { successFn(); }
		}, function(error) {
			if(errorFn) { errorFn(error); }
		});
	}
	
}]);