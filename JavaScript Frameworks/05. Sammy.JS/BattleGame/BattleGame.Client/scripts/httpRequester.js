define(["q", "jquery"], function (Q, $) {
    var makeRequest = function (url, type, data) {
        var deferred = Q.defer();

        var stringedData = "";
        if (data) {
            stringedData = JSON.stringify(data);
        }

        $.ajax({
            url: url,
            type: type,
            contentType: "application/json",
            data: stringedData,
            success: function (result) {
                deferred.resolve(result);
            },

            error: function (errorData) {
                deferred.reject(errorData);
            }
        })

        return deferred.promise;
    }

    function getJson(url) {
        return makeRequest(url, "GET");
    }

    function postJson(url, data) {
        return makeRequest(url, "POST", data);
    }

    function deleteJson(url) {
        return makeRequest(url, "DELETE");
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
});