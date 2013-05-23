var cookies = (function () {

    if (!String.prototype.startsWith) {
        String.prototype.startsWith = function (string) {
            if (this.length < string.length) {
                return false;
            }
            for (var i = 0; i < string.length; i++) {
                if (this[i] !== string[i]) {
                    return false;
                }
            }
            return true;
        }
    }

    function readCookie(cookiName) {
        var cookieValue = document.cookie;
        var cookieStart = cookieValue.indexOf(" " + cookiName + "=");
        if (cookieStart == -1) {
            cookieStart = cookieValue.indexOf(cookiName + "=");
        }
        if (cookieStart == -1) {
            cookieValue = null;
        }
        else {
            cookieStart = cookieValue.indexOf("=", cookieStart) + 1;
            var cookieEnd = cookieValue.indexOf(";", cookieStart);
            if (cookieEnd == -1) {
                cookieEnd = cookieValue.length;
            }
            cookieValue = unescape(cookieValue.substring(cookieStart, cookieEnd));
        }
        return cookieValue;
    }

    function createCookie(cookieName, value, cookieExpDays) {
        var expDate = new Date();
        expDate.setDate(expDate.getDate() + cookieExpDays);
        var expString = (cookieExpDays == null) ? "" : "; expires=" + expDate.toUTCString();
        var cookieValue = escape(value) + expString;
        document.cookie = cookieName + "=" + cookieValue;
    }

    function removeCookie() {
        createCookie(name, "", -1);
    }

    function getCookies() {
        var pairs = document.cookie.split(";");
        var cookies = new Array();
        for (var i = 0; i < pairs.length; i++) {
            var pair = pairs[i].split("=");
            cookies.push({ name: pair[0], value: pair[1] });
        }

        return cookies;
    }

    return {
        readCookie: readCookie,
        createCookie: createCookie,
        removeCookie: removeCookie,
        getCookies: getCookies
    };

}());

var customLocalStorage = (function () {
    var prefix = "customLocalStorage";

    function setItem(key, value) {
        cookies.createCookie(prefix + key, value);
    }

    function getItem(key) {
        return cookies.readCookie(prefix + key);
    }

    function removeItem(key) {
        cookies.removeCookie(prefix + key);
    }

    function clear() {
        var all = cookies.getCookies();
        for (var i = 0; i < all.length; i++) {
            var name = all[i].name;

            if (name.indexOf(prefix) != -1) {
                cookies.removeCookie(name);
            }
        }
    }

    function key(index) {
        var all = cookies.getCookies();
        if (index < all.length) {
            return all[index].
                name.toString().replace(prefix, "").trim();
        }
    }

    function length() {
        var len = 0;
        var all = cookies.getCookies();
        for (var i = 0; i < all.length; i++) {
            var name = all[i].name;

            if (name.indexOf(prefix) != -1) {
                len++;
            }
        }

        return len;
    }

    return {
        setItem: setItem,
        getItem: getItem,
        removeItem: removeItem,
        clear: clear,
        key: key,
        length: length
    };
})();

var customSessionStorage = (function () {
    var data = {};

    function setItem(key, value) {
        data[key] = value.toString();
    }

    function getItem(key) {
        return data[key];
    }

    function removeItem(key) {
        delete data[key];
    }

    function clear() {
        data = {};
    }

    function key(index) {
        var count = 0;
        for (var elem in data) {
            if (count == index) {
                return elem;
            }

            count++;
        }
    }

    function length() {
        var count = 0;

        for (var i in data) {
            count++;
        }

        return count;
    }

    return {
        setItem: setItem,
        getItem: getItem,
        removeItem: removeItem,
        clear: clear,
        key: key,
        length: length
    };
})();

customLocalStorage.setItem("Test", 123);
customLocalStorage.setItem("SecondTest", 123);
var item = customLocalStorage.getItem("Test");
console.log(item);

var key = customLocalStorage.key(1);
console.log(key);

customLocalStorage.clear();


customSessionStorage.setItem("Ses", 1);
customSessionStorage.setItem("test", 2);
console.log(customSessionStorage.length());
customSessionStorage.clear();