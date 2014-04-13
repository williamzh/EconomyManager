var recipeRepoApp = angular.module('economyManagerApp', [
	'ngRoute', 
	'ngCookies',
	// App modules
	'emSecurity',
	'emPlot',
	'emControllers'
]);

recipeRepoApp.config(['$routeProvider', '$httpProvider', function($routeProvider, $httpProvider) {
	$routeProvider.
		when('/', { 
			templateUrl: 'partials/dashboard.html', 
			controller: 'DashboardCtrl'
		}).
		when('/login', { 
			templateUrl: 'partials/login.html', 
			controller: 'LoginCtrl' 
		}).
		// when('/recipes/:recipeId', { 
		// 	templateUrl: 'partials/recipe-details.html', 
		// 	controller: 'RecipeDetailsCtrl'
		// }).
		otherwise({
			redirectTo: '/'
		});

		$httpProvider.interceptors.push('authInterceptor');
}]);

// Monitor unauthorized routes
recipeRepoApp.run(['$rootScope', '$http', '$location', 'authService', function($rootScope, $http, $location, authService) {
	$rootScope.$on("$locationChangeStart", function(event, next, current) { 

		if(next.indexOf('/login') > -1) {
			authService.clearToken();
			return;
		}

    var authToken = authService.getToken();

		if(authToken === null) {
			$location.path('/login');
		}
		else {
			$http.defaults.headers.common['Bearer'] = authToken.value;
		}
  });
}]);

recipeRepoApp.factory('authInterceptor', ['$q', '$location', function($q, $location) {
  return {
    // request: function (config) {
    //   return config || $q.when(config);
    // },
    // requestError: function(request){
    //   return $q.reject(request);
    // },
    // response: function (response) {
    //   return response || $q.when(response);
    // },
    responseError: function (response) {
      if (response && response.status === 401) {
      	$location.path('/login');
      }
      return $q.reject(response);
    }
  }
}]);