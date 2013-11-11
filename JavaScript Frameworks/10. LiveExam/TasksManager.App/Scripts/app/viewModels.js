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
    }

    function getLoginViewModel(successCallback) {
        var viewModel = {
            username: "Teodor92",
            password: "123456",
            message: "",
            login: function () {
                var that = this;
                var user = {
                    username: this.get("username"),
                    password: this.get("password")
                };

                if (_validateUsernameAndPassword(user.username, user.password)) {
                    data.users.login(user).done(function () {
                        if (successCallback) {
                            successCallback();
                        }
                    }, function (error) {
                        var parsedMessage = JSON.parse(error.responseText);
                        that.set("message", parsedMessage.Message);
                    });
                } else {
                    this.set("message", "Password and username must be atleast 6 characters and atmost 40.");
                }
            }
        };

        return kendo.observable(viewModel);
    }

    function getRegisterViewModel(successCallback) {
        var viewModel = {
            username: "Teodor92",
            password: "123456",
            email: "asd@as.bg",
            register: function () {
                var that = this;

                var user = {
                    username: this.get("username"),
                    password: this.get("password"),
                    email: this.get("email")
                };

                if (!_validateUsernameAndPassword(user.username, user.password)) {
                    this.set("message", "Password and username must be atleast 6 characters and atmost 40.");
                } else if (!_validateEmail(user.email)) {
                    this.set("message", "Email is invalid!");
                } else {
                    data.users.register(user).then(function () {
                        if (successCallback) {
                            successCallback();
                        }
                    }, function (error) {
                        var parsedMessage = JSON.parse(error.responseText);
                        that.set("message", parsedMessage.Message);
                    });
                }
            }
        };

        return kendo.observable(viewModel);
    }

    function getAddAppointmentsViewModel() {
        var viewModel = {
            subject: "Power",
            description: "overwhelming!",
            appointmentDate: "",
            duration: "9999",
            message: "",
            successMessage: "",
            addAppointment: function () {
                var that = this;
                var appData = {
                    subject: this.get("subject"),
                    description: this.get("description"),
                    appointmentDate: this.get("appointmentDate"),
                    duration: this.get("duration")
                }

                var valData = _validateAppointmentData(appData);
                if (valData.isValid) {
                    data.appointments.create(appData).then(function () {
                        //location.reload();
                        that.set("message", "");
                        that.set("successMessage", "Added!");
                        setTimeout(function () {
                            that.set("successMessage", "");
                        }, 2000);
                    }, function (error) {
                        var parsedMessage = JSON.parse(error.responseText);
                        that.set("message", parsedMessage.Message);
                    });
                } else {
                    console.log(valData);
                    that.set("message", valData.message);
                }
            }
        };

        return kendo.observable(viewModel);
    }

    /* TODO: Refactor - can be merged in one!*/
    function getAllAppointmentsViewModel() {
        return data.appointments.getAll().then(function (data) {
            var viewModel = {
                appointments: data
            };

            return kendo.observable(viewModel);
        });
    }

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
    }

    function getCurrentAppointmentsViewModel() {
        return data.appointments.getCurrent().then(function (data) {
            var viewModel = {
                appointments: data
            };

            return kendo.observable(viewModel);
        });
    }

    function getComingAppointmentsViewModel() {
        return data.appointments.getComming().then(function (data) {
            var viewModel = {
                appointments: data
            };

            return kendo.observable(viewModel);
        });
    }

    function getTodayAppointmentsViewModel() {
        return data.appointments.getToday().then(function (data) {
            var viewModel = {
                appointments: data
            };

            return kendo.observable(viewModel);
        });
    }

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
    }

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

                    if (_validateToDoContent(todoData.text)) {
                        transgerData.lists.createSingle(id, todoData).then(function () {
                            //this.set("message", "Saved!");
                            location.reload();
                        });
                    } else {
                        this.set("message", "Todo content must be betwenn 3 and 100 characters!");
                    }
                }
            }

            return kendo.observable(viewModel);
        });
    }

    function _validateUsernameAndPassword(username, password) {
        var passwordIsValid = true;
        var usernameIsValid = true;

        if (username.length < 6 || username.length > 40) {
            usernameIsValid = false;
        }

        if (password.length < 6 || password.length > 40) {
            passwordIsValid = false;
        }

        return passwordIsValid && usernameIsValid;
    }

    function _validateEmail(email) {
        var regEx = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return regEx.test(email);
    }

    function _validateAppointmentData(appData) {
        var validationData = {
            isValid: true,
            message: ""
        };

        if (appData.subject.length < 3 || appData.subject.length > 100) {
            validationData.isValid = false;
            validationData.message = "Subject length must be between 3 and 100 characters.";
            return validationData;
        }

        // more validation if needed here.

        return validationData;
    }

    function _validateToDoContent(content) {

        if (content.length < 3 || content.length > 100) {
            return false;
        } else {
            return true;
        }
    }

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