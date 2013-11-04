window.viewsFactory = (function () {
    var rootUrl = "Scripts/partials/";

    var templates = {};

    function getTemplate(name) {

        var deferred = Q.defer();

        if (templates[name]) {
            deferred.resolve(templates[name])
        }
        else {
            $.ajax({
                url: rootUrl + name + ".html",
                type: "GET",
                success: function (templateHtml) {
                    templates[name] = templateHtml;
                    deferred.resolve(templateHtml);
                },
                error: function (err) {
                    deferred.reject(err);
                }
            });
        }

        return deferred.promise;
    }

    function getHomeView() {
        return getTemplate("home");
    }

    function getLoginView() {
        return getTemplate("login-form");
    }

    function getRegisterForm() {
        return getTemplate("register-form");
    }

    function getAppointmentsView() {
        return getTemplate("appointments");
    }

    function getAddAppointmentsView() {
        return getTemplate("add-appointments-from");
    }

    function getAppointmentsByDateView() {
        return getTemplate("appointments-by-date");
    }

    function getListsView() {
        return getTemplate("lists");
    }

    function getTodoView() {
        return getTemplate("todo");
    }

    return {
        getRegisterForm: getRegisterForm,
        getLoginView: getLoginView,
        getAppointmentsView: getAppointmentsView,
        getAddAppointmentsView: getAddAppointmentsView,
        getAppointmentsByDateView: getAppointmentsByDateView,
        getListsView: getListsView,
        getTodoView: getTodoView,
        getHomeView: getHomeView
    };
}());