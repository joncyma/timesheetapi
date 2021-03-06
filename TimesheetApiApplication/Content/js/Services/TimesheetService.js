/// <reference path="../typings/angularjs/angular.d.ts" />
'use strict';

var timesheetServices = angular.module('timesheetServices', ['ngResource']);

timesheetServices.factory('Timesheet', ['$resource',
	function ($resource) {
		return $resource('/api/Timesheets', {}, {
			query: { method: 'GET', params: {}, isArray: true }
		});
	}]);