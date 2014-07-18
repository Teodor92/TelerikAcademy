window.httpRequester = (function () {

    var makeRequest = function (url, type, data) {

        var stringedData = "";
        if (data) {
            stringedData = JSON.stringify(data);
        }

        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: url,
                type: type,
                contentType: "application/json",
                data: stringedData,
                timeout: 5000,
                success: function (result) {
                    resolve(result);
                },

                error: function (errorData) {
                    reject(errorData);
                }
            });
        });

        return promise;
    }

    function getJson(url) {
        return makeRequest(url, "GET", null);
    }

    function postJson(url, data) {
        return makeRequest(url, "POST", data);
    }

    function deleteJson(url) {
        return makeRequest(url, "DELETE", null);
    }

    function putJson(url, data) {
        return makeRequest(url, "PUT", data);
    }

    return {
        getJson: getJson,
        postJson: postJson,
        deleteJson: deleteJson,
        putJson: putJson
    };
}());