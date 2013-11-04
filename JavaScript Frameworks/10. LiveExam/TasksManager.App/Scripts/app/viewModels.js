/// <reference path="../libs/_references.js" />
/// <reference path="../libs/kendo.web.min.js" />
/// <reference path="../libs/httpRequester.js" />

window.viewModelFactory = (function () {
    var data = null;

    function getHomeViewModel() {
        var viewModel = {
            // for futre use
        };

        return kendo.observable(viewModel);
    };

    function getLoginViewModel(successCallback) {
        var viewModel = {
            username: "Teodor92",
            password: "123456",
            login: function () {
                var user = {
                    username: this.get("username"),
                    password: this.get("password")
                };
                data.users.login(user)
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }
					});
            }
        };

        return kendo.observable(viewModel);
    };

    function getRegisterViewModel(successCallback) {
        var viewModel = {
            username: "Teodor92",
            password: "123456",
            email: "asd@as.bg",
            register: function () {
                var user = {
                    username: this.get("username"),
                    password: this.get("password"),
                    email: this.get("email")
                };
                data.users.register(user)
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }
					});
            }
        };

        return kendo.observable(viewModel);
    };

    function getAddAppointmentsViewModel() {
        var viewModel = {
            subject: "Power",
            description: "overwhelming!",
            appointmentDate: "",
            duration: "9999",
            addAppointment: function () {
                var appData = {
                    subject: this.get("subject"),
                    description: this.get("description"),
                    appointmentDate: this.get("appointmentDate"),
                    duration: this.get("duration")
                }

                data.appointments.create(appData).then(function () {
                    location.reload();
                })
            }
        };

        return kendo.observable(viewModel);
    };

    /* TODO: Refactor - can be merged in one!*/
    function getAllAppointmentsViewModel() {
        return data.appointments.getAll().then(function (data) {
            var viewModel = {
                appointments: data
            };

            return kendo.observable(viewModel);
        });
    };

    function getDateAppointmentsViewModel() {
        var viewModel = {
            getDate: "",
            appointments: [],
            getAppointments: function () {
                var self = this;
                var searchDate = this.get("getDate");
                data.appointments.getByDate(searchDate).then(function (data) {
                    self.set("appointments", data);
                });
            }
        };

        return kendo.observable(viewModel);
    };

    function getCurrentAppointmentsViewModel() {
        return data.appointments.getCurrent().then(function (data) {
            var viewModel = {
                appointments: data
            };

            return kendo.observable(viewModel);
        });
    };

    function getComingAppointmentsViewModel() {
        return data.appointments.getComming().then(function (data) {
            var viewModel = {
                appointments: data
            };

            return kendo.observable(viewModel);
        });
    };

    function getTodayAppointmentsViewModel() {
        return data.appointments.getToday().then(function (data) {
            var viewModel = {
                appointments: data
            };

            return kendo.observable(viewModel);
        });
    };

    function getListsViewModel() {
        var transverData = data;
        this.data
        return data.lists.getAll().then(function (data) {
            var viewModel = {
                lists: data,
                title: "",
                todos: "",
                postList: function () {
                    var allTodos = this.get("todos");
                    var splitedTodos = allTodos.split(',');
                    var transferTodos = [];
                    for (var i = 0; i < splitedTodos.length; i++) {
                        transferTodos.push({ text: splitedTodos[i] });
                    }

                    var data = {
                        title: this.get("title"),
                        todos: transferTodos
                    };

                    transverData.lists.createMany(data).then(function () {
                        alert("Saved to db.");
                    });
                },
            };

            return kendo.observable(viewModel);
        })
    };

    function getSingelTodoViewModel(id) {
        var transgerData = data;
        return data.lists.getSingle(id).then(function (data) {
            var viewModel = {
                contentText: "",
                todo: data.todos,
                message: "",
                addTodo: function () {
                    var todoData = {
                        text: this.get("contentText")
                    };
                    transgerData.lists.createSingle(id, todoData).then(function () {
                        //this.set("message", "Saved!");
                        location.reload();
                    });
                }
            }

            return kendo.observable(viewModel);
        });
    };

    return {
        getHomeViewModel: getHomeViewModel,
        getLoginViewModel: getLoginViewModel,
        getRegisterViewModel: getRegisterViewModel,
        getAllAppointmentsViewModel: getAllAppointmentsViewModel,
        getCurrentAppointmentsViewModel: getCurrentAppointmentsViewModel,
        getComingAppointmentsViewModel: getComingAppointmentsViewModel,
        getTodayAppointmentsViewModel: getTodayAppointmentsViewModel,
        getAddAppointmentsViewModel: getAddAppointmentsViewModel,
        getDateAppointmentsViewModel: getDateAppointmentsViewModel,
        getListsViewModel: getListsViewModel,
        getSingelTodoViewModel: getSingelTodoViewModel,
        setPersister: function (persister) {
            data = persister
        }
    };
}());