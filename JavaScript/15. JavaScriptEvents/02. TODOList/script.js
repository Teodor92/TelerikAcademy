function addHandler(element, eventType, eventHandler) {
    if (element.addEventListener) {
        element.addEventListener(eventType, eventHandler, false);
    } else {
        // IE support
        element.attachEvent("on" + eventType, eventHandler);
    }
}

function onLoad() {
    // needed elements
    var addButton = document.getElementById('add-button');
    var removeButton = document.getElementById('remove-button');
    var showButton = document.getElementById('show-button');
    var hideButton = document.getElementById('hide-button');
    var taskList = document.getElementById('task-list');

    // event handlers
    function addTask() {
        var task = document.getElementById('task');
        
        if (task) {
            var li = document.createElement('li');
            var content = '<input type="checkbox" /><span>' + task.value + '</span>'
            li.innerHTML += content;

            taskList.appendChild(li);
        }
    }

    function deleteTask() {
        var allTasks = taskList.querySelectorAll('li input');
        for (var i = 0; i < allTasks.length; i++) {
            if (allTasks[i].checked) {
                taskList.removeChild(allTasks[i].parentNode);
            }
        }
    }

    function hideTask() {
        var allTasks = taskList.querySelectorAll('li input');
        for (var i = 0; i < allTasks.length; i++) {
            if (allTasks[i].checked) {
                allTasks[i].parentNode.style.display = 'none';
            }
        }
    }

    function showTasks() {
        var allTasks = taskList.querySelectorAll('li input');
        for (var i = 0; i < allTasks.length; i++) {
            if (allTasks[i].parentNode.style.display === 'none') {
                allTasks[i].parentNode.style.display = 'block';
            }
        }
    }

    // register events
    addHandler(addButton, 'click', addTask);
    addHandler(removeButton, 'click', deleteTask);
    addHandler(hideButton, 'click', hideTask);
    addHandler(showButton, 'click', showTasks);
}