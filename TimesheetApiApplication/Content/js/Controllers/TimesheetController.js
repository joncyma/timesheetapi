/// <reference path="../typings/angularjs/angular.d.ts" />

var timesheetControllers = angular.module('timesheetControllers', []);

timesheetControllers.controller('TimesheetController', 
	['$scope', 'Timesheet',
	function ($scope, Timesheet) {
		$scope.timesheets = Timesheet.query();
		
		$scope.delete = function (timesheet) {
			console.log('Deleting ' + timesheet);
			
			timesheet.$remove();
			
		}
		
	}
]);

timesheetControllers.controller('AddTimesheetController', 
	['$scope', 'Timesheet',
	function ($scope, Timesheet) {
		
		$scope.timesheet = new Timesheet();
		
		$scope.status = {
			opened: false
		};
		
		$scope.today = function() {
			$scope.dt = new Date();
		};
		$scope.today();
		
		$scope.clear = function () {
			$scope.dt = null;
		};
		
		$scope.open = function($event) {
			$scope.status.opened = true;
		};
		
		$scope.dateOptions = {
			formatYear: 'yy',
			startingDay: 1
		};
		
		$scope.format = 'dd MMM yyyy';
				
		$scope.addTimesheet = function() { //create a new movie. Issues a POST to /api/movies
			$scope.timesheet.$save(function() {
			// $state.go('movies'); // on success go back to home i.e. movies state.
			});
		};
		
	}
]);