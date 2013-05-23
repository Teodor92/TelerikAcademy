(function () {

    var db = {
        folders: ["New Folder", "New Folder(1)", "New Folder(2)"]
    }

    TreeView = function (params) {

        this.treeViewContainer = params.treeViewContainer

    }

    TreeView.prototype.init = function () {
        this.initDB()
    }

    TreeView.prototype.initDB = function () {
        var i;
        var foldersCount = db.folders.length;
        for (i = 0; i < foldersCount; i++) {

            this.treeViewContainer.innerHTML += "<li>" + db.folders[i] + "</li>";

        }
    }

}());