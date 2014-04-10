controllers.controller('DashboardCtrl', ['$scope', '$http', '$filter', 'chartFactory', function($scope, $http, $filter, chartFactory) {
	
	// Get period info
	$http.get('http://localhost:2740/api/meta/period').then(function(response) {
		$scope.period = response.data.data;
	}, function(error) {
		console.error(error);
	});

	// Get incomes
	$http.get('http://localhost:2740/api/incomes').then(function(response) {
		
		var nextSalary = new Date(response.data.data[0].date);
		$scope.incomeData = {
			daysRemaining: nextSalary.subtract(new Date()).toDays(),
			incomes: response.data.data
		};
	}, function(error) {
		console.error(error);
	});

	// Get invoices
	$http.get('http://localhost:2740/api/invoices').then(function(response) {
		var invoices = response.data.data;

		$scope.invoiceData = {
			paidCount: invoices.filter(function(item) { return item.isPaid === false; }).length,
			total: invoices.length,
			invoices: invoices
		};
	}, function(error) {
		console.error(error);
	});

	// Get events
	$scope.eventData = {
		events: [{
			name: 'Resa',
			amount: '5400',
			due: '2014-04-25'
		}]
	};

	// Get expense history
	$http.get('http://localhost:2740/api/expenses/history').then(function(response) {
		var historyItems = response.data.data;

		var plotData = [];
		var dateFilter = $filter('date');
		for(var day in historyItems) {
			plotData.push({
				date: dateFilter(day, 'yyyy-MM-dd'),
				amount: historyItems[day]
			});
		}

		chartFactory.drawBarChart('morris-chart-area', plotData, {
	  	xKey: 'date',
	  	yKeys: ['amount'],
	  	labels: ['']
	  });
	}, function(error) {
		console.error(error);
	});

	// Get expense distribution
	$http.get('http://localhost:2740/api/expenses/distribution').then(function(response) {
		var distribution = [];
		
		for(var key in response.data.data) {
			distribution.push({
				label: key,
				value: response.data.data[key]
			});
		}

		chartFactory.drawDonutChart('morris-chart-donut', distribution);
	}, function(error) {
		console.error(error);
	});

	// Get expenses
	$http.get('http://localhost:2740/api/expenses').then(function(response) {
		var expenseData = response.data;

		$scope.expenseData = {
			startDate: expenseData.startDate,
			endDate: expenseData.endDate,
			total: Math.round(expenseData.data.aggregate(0, function(item) {
				return item.amount;
			})),
			expenses: expenseData.data
		};	
	}, function(error) {
		console.error(error);
	});
}]);