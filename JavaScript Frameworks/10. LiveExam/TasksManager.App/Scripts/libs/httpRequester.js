window.httpRequester = (function () {
    var makeRequest = function (url, type, data, headers) {
        var deferred = Q.defer();

        var stringedData = "";
        if (data) {
            stringedData = JSON.stringify(data);
        }

        $.ajax({
            url: url,
            type: type,
            headers: headers,
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

    function getJson(url, headers) {
        return makeRequest(url, "GET", null, headers);
    }

    function postJson(url, data, headers) {
        return makeRequest(url, "POST", data, headers);
    }

    function deleteJson(url, headers) {
        return makeRequest(url, "DELETE", null, headers);
    }

    function putJson(url, data, headers) {
        return makeRequest(url, "PUT", data, headers);
    }

    return {
        getJson: getJson,
        postJson: postJson,
        deleteJson: deleteJson,
        putJson: putJson
    };
})();