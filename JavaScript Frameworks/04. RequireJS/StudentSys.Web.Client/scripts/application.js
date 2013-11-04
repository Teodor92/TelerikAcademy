require(["class", "jquery", "q", "dataPersister", "mustache", "controls"], function (Class, $, Q, StudebtSystem, Mustache, Controls) {
    var persister = StudebtSystem.Data.get("http://localhost:44901/api/");

    var template = '{{#students}} \
            <ul class="grades"> \
            <li style="display:none" data-id="{{id}}"></li> \
                <li>First Name: {{firstname}}</li> \
                <li>Last Name: {{lastname}}</li> \
                <li>Grade: {{grade}}</li> \
                <li>Age: {{age}}</li> \
            </ul> \
                {{/students}}'

    var markTemplate = '<ul class="marks-list"> \
            {{#marks}} \
            <li>Value: {{subject}}</li> \
            <li>Value: {{value}}</li> \
            {{/marks}} \
        </ul>';

    persister.student.getAll().then(function (result) {
        var view = {
            students: result
        };

        var control = Controls.listView(view, "content");
        control.loadList(template);

        loadEventHandlers();

    }, function (error) {
        console.log("Fuck! Something went wrong!");
        console.log(error);
    });

    function loadEventHandlers() {
        $("#content").on("click", ".grades", function () {

            var id = $(this).find("li:first").data("id");
            persister.student.getMarksById(id).then(function (result) {
                var view = {
                    marks: result
                };

                var control = Controls.tableView(view, "marks-container");
                control.loadTable(markTemplate);

            }, function (error) {
                console.log(error);
            });
        });
    }
});