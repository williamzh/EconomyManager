var emPlot = angular.module('emPlot', []);

emPlot.factory('chartFactory', function() {
	
	function drawArea(element, data, metaInfo) {
		Morris.Area({
		  // ID of the element in which to draw the chart.
		  element: element,
		  // Chart data records -- each entry in this array corresponds to a point on
		  // the chart.
		  data: data,
		  // The name of the data record attribute that contains x-visits.
		  xkey: metaInfo.xKey,
		  // A list of names of data record attributes that contain y-visits.
		  ykeys: metaInfo.yKeys,
		  // Labels for the ykeys -- will be displayed when you hover over the chart.
		  labels: ['Visits'],
		  // Disables line smoothing
		  smooth: false,
		});
	}

	function drawLine(element, data, metaInfo) {
		Morris.Line({
		  // ID of the element in which to draw the chart.
		  element: element,
		  // Chart data records -- each entry in this array corresponds to a point on
		  // the chart.
		  data: data,
		  // The name of the data record attribute that contains x-visits.
		  xkey: metaInfo.xKey,
		  // A list of names of data record attributes that contain y-visits.
		  ykeys: metaInfo.yKeys,
		  // Labels for the ykeys -- will be displayed when you hover over the chart.
		  labels: ['Visits'],
		  // Disables line smoothing
		  smooth: false,
		});
	}

	function drawBar(element, data, metaInfo) {
		Morris.Bar({
		  element: element,
		  data: data,
		 	xkey: metaInfo.xKey,
		  ykeys: metaInfo.yKeys,
		  labels: metaInfo.labels,
		  hideHover: true
		  // hoverCallback: function(index, options, content) {
		  // 	var parsedContent = $($(content)[1]);
		  // 	parsedContent.text(options.data[index].amount + ' kr');
		  // 	return parsedContent.html();
		  // }
	  });
	}

	function drawDonut(element, data) {
		Morris.Donut({
		  element: element,
		  data: data,
		  formatter: function (y) { return y + "%" ;}
		});
	}

	return {
		drawAreaChart: drawArea,
		drawBarChart: drawBar,
		drawDonutChart: drawDonut,
		drawLineChart: drawLine
	};
});
