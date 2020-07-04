

(function ($) {
	// USE STRICT
	"use strict";
	//bar chart
	var ctx = document.getElementById("barChart");
	if (ctx) {
		ctx.height = 200;
		var myChart = new Chart(ctx, {
			type: 'bar',
			defaultFontFamily: 'Poppins',
			data: {
				labels: ["January", "February", "March", "April", "May", "June", "July"],
				datasets: [
					{
						label: "My First dataset",
						data: [65, 59, 80, 81, 56, 55, 40],
						borderColor: "rgba(0, 123, 255, 0.9)",
						borderWidth: "0",
						backgroundColor: "rgba(0, 123, 255, 0.5)",
						fontFamily: "Poppins"
					},
					{
						label: "My Second dataset",
						data: [28, 48, 40, 19, 86, 27, 90],
						borderColor: "rgba(0,0,0,0.09)",
						borderWidth: "0",
						backgroundColor: "rgba(0,0,0,0.07)",
						fontFamily: "Poppins"
					}
				]
			},
			options: {
				legend: {
					position: 'top',
					labels: {
						fontFamily: 'Poppins'
					}

				},
				scales: {
					xAxes: [{
						ticks: {
							fontFamily: "Poppins"

						}
					}],
					yAxes: [{
						ticks: {
							beginAtZero: true,
							fontFamily: "Poppins"
						}
					}]
				}
			}
		});
	}
})(jQuery);