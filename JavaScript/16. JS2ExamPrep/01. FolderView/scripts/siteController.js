(function () {

    var SiteController = function (params) {
        this.params = params;
        this.treeViewContainer = document.getElementById(params.treeViewContainer);
    }

    SiteController.prototype.init = function () {

        this.initTreeView();

    }

    SiteController.prototype.initTreeView = function () {
        this.treeView = new TreeView({
            treeViewContainer: this.treeViewContainer
        });

        this.treeView.init();

    }


    document.querySelector('body').onload =  function () {

        var siteController = new SiteController({
            treeViewContainer: 'tree-view-container'
        });

        siteController.init();

    }

})();