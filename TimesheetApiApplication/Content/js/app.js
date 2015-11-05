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
		templateUrl: 'Content/partials/timesheets.html',
		controller: 'TimesheetController'
	}).
	when('/add', {
		templateUrl: 'Content/partials/add-timesheet.html',
		controller: 'AddTimesheetController'
	}).
	otherwise({
		redirectTo: '/timesheets'
	})
}]);