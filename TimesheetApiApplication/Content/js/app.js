/// <reference path="typings/angularjs/angular.d.ts" />

'use string';

var timesheetApp = angular.module('timesheetApp', [
	'ui.bootstrap',
	'ngRoute',
	'timesheetControllers',
	'timesheetServices'
]);

timesheetApp.config(['$routeProvider', function ($routeProvider) {
	$routeProvider.
	when('/timesheets', {
		templateUrl: 'partials/timesheets.html',
		controller: 'TimesheetController'
	}).
	when('/add', {
		templateUrl: 'partials/add-timesheet.html',
		controller: 'AddTimesheetController'
	}).
	otherwise({
		redirectTo: '/timesheets'
	})
}]);