/// <reference path="app/view-models.js" />
/// <reference path="app/views.js" />

(function () {

	var layout = new kendo.Layout('<div id="content"></div>');
	var router = new kendo.Router();
	var viewModelFactory = viewModels.get();
	var viewFactory = views.get("Scripts2/partials/");
	router.route("/", function () {
		if (!viewModelFactory.currentUser()) {
			router.navigate("/login");
		}
		else {
			var homeViewHtml = "";
			viewFactory.carsView()
				.then(function (viewHtml) {
					homeViewHtml = viewHtml;
					return viewModelFactory.buildCarsViewModel();
				})
				.then(function (vm) {
					debugger;
					$("body").append(homeViewHtml);
					var view = new kendo.View("cars-view-template", { model: vm });
					debugger;
					layout.showIn("#content", view);
				});
		}
	});

	router.route("/login", function () {
		viewFactory.loginForm()
			.then(function (loginFormHtml) {
				var vm = viewModelFactory.buildLoginFormVM(function () {
					//debugger;
					router.navigate("/");
				});
				var view = new kendo.View(loginFormHtml, { model: vm });
				layout.showIn("#content", view);
			});
	});

	$(function () {
		layout.render($("#app"));
		router.start("/");
	});
}());