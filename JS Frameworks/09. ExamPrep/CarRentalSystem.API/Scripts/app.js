/// <reference path="libs/_references.js" />
/// <reference path="libs/kendo.web.min.js" />
/// <reference path="libs/kendo.web.min.intellisense.js" />

(function () {
    var appLayout =
		new kendo.Layout('<div id="main-content"></div>');
    var data = persisters.get("api/");
    vmFactory.setPersister(data);

    var router = new kendo.Router();
    router.route("/", function () {
        $("#main-content").html('This is home');
    });

    router.route("/login", function () {
        if (data.users.currentUser()) {
            router.navigate("/");
        }
        else {
            viewsFactory.getLoginView()
				.then(function (loginViewHtml) {
				    var loginVm = vmFactory.getLoginVM(
						function () {
						    router.navigate("/");
						});
				    var view = new kendo.View(loginViewHtml,
						{ model: loginVm });
				    appLayout.showIn("#main-content", view);
				});
        }
    });

    router.route("/cars", function () {
        alert("cars");
        viewsFactory.getCarsView()
			.then(function (carsViewHtml) {
			    vmFactory.getCarsVM()
				.then(function (vm) {
				    var view =
						new kendo.View(carsViewHtml,
						{ model: vm });
				    appLayout.showIn("#main-content", view);
				}, function (err) {
				    //...
				});
			}).done();
    });

    router.route("/cars/filter", function () {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }

        alert("filter");
    });

    router.route("/cars/page/:page/:count", function (page, count) {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }

        viewsFactory.getCarsView()
			.then(function (carsViewHtml) {
			    vmFactory.getCarsVM()
				.then(function (vm) {
				    var view =
						new kendo.View(carsViewHtml,
						{ model: vm });
				    appLayout.showIn("#main-content", view);
				}, function (err) {

				});
			});
    });

    router.route("/stores", function () {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }
        alert("stores");
    });

    router.route("/cars/rented", function () {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }

        alert("Rented");

        viewsFactory.getCarsView()
            .then(function (rentedView) {
                vmFactory.getRentedCarsVM()
                    .then(function (vm) {
                        var view = new kendo.View(rentedView, {
                            model: vm
                        });
                        appLayout.showIn("#main-content", view);
                    }, function (error) {
                        console.log(error);
                    }, function (error) {
                        console.log(error);
                    })
            }).done();
    });

    //only for registered users
    router.route("/special", function () {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }
    });

    $(function () {
        appLayout.render("#app");
        router.start();
    });
}());
