/// <reference path="data.js" />
/// <reference path="../libs/kendo.web.min.js" />

window.viewModels = (function () {
	var displayName = "";
	var ViewModels = Class.create({
		init: function (persister) {
			this.persister = persister;
			return this;
		},
		currentUser: function () {
			return displayName;
		},
		buildCarsViewModel: function () {
			return this.persister.cars.all()
			.then(function (cars) {
				console.log(cars.length);
				//var carsDataSource = new kendo.data.DataSource(cars);
				var carsViewModel = new kendo.observable({
					cars: cars
				});
				return carsViewModel;
			});
		},
		buildLoginFormVM: function (successCallback) {
			var self = this;
			var viewModel = new kendo.observable({
				username: "DonchoMinkov",
				password: "Minkov",
				message: "Common!",
				loginUser: function (e) {
					return self.persister.users
						.login(this.get("username"), this.get("password"))
							.then(function (name) {
								displayName = name;
								successCallback();
							});
				},
				registerUser: function (e) {
					return self.persister.users
						.register(this.get("username"), this.get("password"))
							.then(function (name) {
								displayName = name;
								successCallback();
							});
				}
			});
			return viewModel;
		}
	});

	return {
		get: function () {
			return new ViewModels(persisters.get("api/"))
		}
	}
}());