controllers.controller('DashboardCtrl', ['$scope', 'chartFactory', function($scope, chartFactory) {
	$scope.period = {
		startDate: '2014-04-01',
		endDate: '2014-04-31',
		display: 'April 2014'
	}
	
	var invoices = [{
		id: 1,
		recipient: 'Bredbandsbolaget',
		amount: '280',
		due: '2014-03-31',
		isPaid: true,
		isRecurring: true
	}, {
		id: 2,
		recipient: 'Vattenfall',
		amount: '550,8',
		due: '2014-04-28',
		isPaid: false,
		isRecurring: true
	}];

	$scope.invoiceData = {
		paidCount: invoices.filter(function(item) { return item.isPaid === false; }).length,
		total: invoices.length,
		invoices: invoices
	};

	$scope.incomeData = {
		nextPayment: '2014-04-25',
		daysRemaining: 20,
		amount: '25000'
	};

	$scope.expenseData = {
		startDate: '2014-03-01',
		endDate: '2014-03-25',
		total: '11 458',
		expenses: [{
			date: '2014-03-19',
			amount: '85',
			description: 'Lunch'
		}, {
			date: '2014-03-20',
			amount: '150',
			description: 'Gas'
		}, {
			date: '2014-03-22',
			amount: '220',
			description: 'Movies'
		}, {
			date: '2014-03-23',
			amount: '95',
			description: 'Lunch'
		}, {
			date: '2014-03-23',
			amount: '168',
			description: 'Groceries'
		}]
	};

	$scope.eventData = {
		events: [{
			name: 'Resa',
			amount: '5400',
			due: '2014-04-25'
		}]
	};

	var transactionData = [
		{ date: '2012-10-01', amount: 802, fo: 324234 },
		{ date: '2012-10-02', amount: 783 },
		{ date: '2012-10-03', amount: 820 },
		{ date: '2012-10-04', amount: 839 },
		{ date: '2012-10-05', amount: 792 },
		{ date: '2012-10-06', amount: 859 },
		{ date: '2012-10-07', amount: 790 },
		{ date: '2012-10-08', amount: 1680 },
		{ date: '2012-10-09', amount: 1592 },
		{ date: '2012-10-10', amount: 1420 },
		{ date: '2012-10-11', amount: 882 },
		{ date: '2012-10-12', amount: 889 },
		{ date: '2012-10-13', amount: 819 },
		{ date: '2012-10-14', amount: 849 },
		{ date: '2012-10-15', amount: 870 },
		{ date: '2012-10-16', amount: 1063 },
		{ date: '2012-10-17', amount: 1192 },
		{ date: '2012-10-18', amount: 1224 },
		{ date: '2012-10-19', amount: 1329 },
		{ date: '2012-10-20', amount: 1329 },
		{ date: '2012-10-21', amount: 1239 },
		{ date: '2012-10-22', amount: 1190 },
		{ date: '2012-10-23', amount: 1312 },
		{ date: '2012-10-24', amount: 1293 },
		{ date: '2012-10-25', amount: 1283 },
		{ date: '2012-10-26', amount: 1248 },
		{ date: '2012-10-27', amount: 1323 },
		{ date: '2012-10-28', amount: 1390 },
		{ date: '2012-10-29', amount: 1420 },
		{ date: '2012-10-30', amount: 1529 },
		{ date: '2012-10-31', amount: 1892 },
  ];
	chartFactory.drawBarChart('morris-chart-area', transactionData, {
  	xKey: 'date',
  	yKeys: ['amount'],
  	labels: ['']
  });

	var expensesDistribution = [
	 	{label: "Fixed", value: 42.7},
    {label: "Shopping", value: 8.3},
    {label: "Entertainment", value: 12.8},
    {label: "Food", value: 36.2}
	];
	chartFactory.drawDonutChart('morris-chart-donut', expensesDistribution);	

}]);