var recipeRepoApp = angular.module('economyManagerApp', [
	'ngRoute', 
	// App modules
	'emControllers',
	'emPlot'
]);

recipeRepoApp.config(['$routeProvider', function($routeProvider) {
	$routeProvider.
		when('/', { 
			templateUrl: 'partials/dashboard.html', 
			controller: 'DashboardCtrl'
		}).
		// when('/recipes', { 
		// 	templateUrl: 'partials/recipe-list.html', 
		// 	controller: 'RecipeListCtrl' 
		// }).
		// when('/recipes/:recipeId', { 
		// 	templateUrl: 'partials/recipe-details.html', 
		// 	controller: 'RecipeDetailsCtrl'
		// }).
		otherwise({
			redirectTo: '/'
		});
}]);