var emSecurity = angular.module('emSecurity', []);

emSecurity.service('authService', ['$cookieStore', function($cookieStore) {

	this.isUserAuthenticated = function() {
		var authToken = this.getToken();

		if(authToken === null) {
			return false;
		}

		var tokenExpiration = new Date(authToken.expires);
		return Date.nowAsDate() < tokenExpiration;
	}

	this.getToken = function() {
		return $cookieStore.get('emAuth') || null;
	}

	this.setToken = function(token) {
		$cookieStore.put('emAuth', token);
	}

	this.clearToken = function() {
		$cookieStore.remove('emAuth');
	}	
}]);