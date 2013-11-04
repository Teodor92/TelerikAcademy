/// <reference path="libs/_references.js" />
/// <reference path="libs/kendo.web.min.js" />
/// <reference path="app/viewModels.js" />
/// <reference path="libs/q.js" />
/// <reference path="libs/kendo.web.min.intellisense.js" />
/// <reference path="app/views.js" />

(function () {
    var appLayout =
		new kendo.Layout('<div id="main-content"></div>');
    var data = persisters.get("api/");
    viewModelFactory.setPersister(data);

    var router = new kendo.Router();
    router.route("/", function () {
        viewsFactory.getHomeView().then(function (homeHtmlView) {
            var viewmodel = viewModelFactory.getHomeViewModel();
            var view = new kendo.View(homeHtmlView,
						{ model: viewmodel });
            appLayout.showIn("#main-content", view);
        })
    });

    router.route("/login", function () {
        if (data.isUserLoggedIn()) {
            router.navigate("/");
        }
        else {
            viewsFactory.getLoginView()
				.then(function (loginViewHtml) {
				    var loginVm = viewModelFactory.getLoginViewModel(
						function () {
						    router.navigate("/");
						});
				    var view = new kendo.View(loginViewHtml,
						{ model: loginVm });
				    appLayout.showIn("#main-content", view);
				});
        }
    });

    router.route("/register", function () {
        if (data.isUserLoggedIn()) {
            router.navigate("/");
        } else {

            viewsFactory.getRegisterForm().then(function (registerHtml) {
                var registerViewModel = viewModelFactory.getRegisterViewModel(function () {
                    router.navigate("/login");
                });

                var view = new kendo.View(registerHtml, { model: registerViewModel });
                appLayout.showIn("#main-content", view);
            });
        }
    });

    router.route("/appointments/add", function () {
        if (!data.isUserLoggedIn()) {
            router.navigate("/login");
        } else {

            viewsFactory.getAddAppointmentsView()
                    .then(function (addAppointView) {
                        var addAppVm = viewModelFactory.getAddAppointmentsViewModel();
                        var view = new kendo.View(addAppointView,
                            { model: addAppVm });
                        appLayout.showIn("#main-content", view);
                    });
        }
    });

    router.route("/appointments/all", function () {
        if (!data.isUserLoggedIn()) {
            router.navigate("/login");
        } else {

            viewsFactory.getAppointmentsView().then(function (allAppointmentsView) {
                viewModelFactory.getAllAppointmentsViewModel().then(function (viewModel) {
                    var view = new kendo.View(allAppointmentsView, {
                        model: viewModel
                    });
                    appLayout.showIn("#main-content", view);
                }, function (error) {
                    console.log(error);
                })
            }, function (error) {
                console.log(error);
            })
        }
    });

    router.route("/appointments/bydate", function () {
        if (!data.isUserLoggedIn()) {
            router.navigate("/");
        }
        else {
            viewsFactory.getAppointmentsByDateView()
				.then(function (appointByDateHTml) {
				    var appointByDateVm = viewModelFactory.getDateAppointmentsViewModel();
				    var view = new kendo.View(appointByDateHTml,
						{ model: appointByDateVm });
				    appLayout.showIn("#main-content", view);
				});
        }
    });

    router.route("/appointments/coming", function () {
        if (!data.isUserLoggedIn()) {
            router.navigate("/login");
        } else {

            viewsFactory.getAppointmentsView().then(function (allAppointmentsView) {
                viewModelFactory.getComingAppointmentsViewModel().then(function (viewModel) {
                    var view = new kendo.View(allAppointmentsView, {
                        model: viewModel
                    });
                    appLayout.showIn("#main-content", view);
                }, function (error) {
                    console.log(error);
                })
            }, function (error) {
                console.log(error);
            });
        }
    });

    router.route("/appointments/current", function () {
        if (!data.isUserLoggedIn()) {
            router.navigate("/login");
        } else {

            viewsFactory.getAppointmentsView().then(function (allAppointmentsView) {
                viewModelFactory.getCurrentAppointmentsViewModel().then(function (viewModel) {
                    var view = new kendo.View(allAppointmentsView, {
                        model: viewModel
                    });
                    appLayout.showIn("#main-content", view);
                }, function (error) {
                    console.log(error);
                })
            }, function (error) {
                console.log(error);
            });
        }
    });

    router.route("/appointments/today", function () {
        if (!data.isUserLoggedIn()) {
            router.navigate("/login");
        } else {

            viewsFactory.getAppointmentsView().then(function (allAppointmentsView) {
                viewModelFactory.getTodayAppointmentsViewModel().then(function (viewModel) {
                    var view = new kendo.View(allAppointmentsView, {
                        model: viewModel
                    });
                    appLayout.showIn("#main-content", view);
                }, function (error) {
                    console.log(error);
                })
            }, function (error) {
                console.log(error);
            });
        }
    });

    router.route("/lists", function () {
        if (!data.isUserLoggedIn()) {
            router.navigate("/login");
        } else {

            viewsFactory.getListsView().then(function (lsitsViewHtml) {
                viewModelFactory.getListsViewModel().then(function (viewModel) {
                    var view = new kendo.View(lsitsViewHtml, {
                        model: viewModel
                    });
                    appLayout.showIn("#main-content", view);
                }, function (error) {
                    console.log(error);
                })
            }, function (error) {
                console.log(error);
            });
        }
    });

    router.route("/lists/:id/todos", function (id) {
        if (!data.isUserLoggedIn()) {
            router.navigate("/login");
        } else {

            viewsFactory.getTodoView().then(function (todoViewHtml) {
                viewModelFactory.getSingelTodoViewModel(id).then(function (viewModel) {
                    var view = new kendo.View(todoViewHtml, {
                        model: viewModel
                    });
                    appLayout.showIn("#main-content", view);
                }, function (error) {
                    console.log(error);
                })
            }, function (error) {
                console.log(error);
            });
        }
    });

    router.route("/todos/:id", function (id) {
        if (!data.isUserLoggedIn()) {
            router.navigate("/login");
        } else {

            data.todos.changeStatus(id).then(function () {
                router.navigate("/lists");
            });
        };
    });

    //router.route("/logout", function (id) {
    //    if (!data.isUserLoggedIn()) {
    //        router.navigate("/login");
    //    } else {

    //        data.users.logout().then(function () {
    //            router.navigate("/login");
    //        });
    //    };
    //});

    $(function () {
        appLayout.render("#app");
        router.start();
    });
}());
