/// <reference path="libs/ua-parser.js" />
/// <reference path="modernizr.custom.27712.js" />

jQuery(function ($) {
    var target = $('#features > tbody');

    var traverse = function (object, prefix) {
        prefix = prefix ? prefix + '.' : '';

        for (property in object) {
            if (typeof object[property] == 'object') {
                traverse(object[property], prefix + property);
            } else if (typeof object[property] == 'boolean') {
                var
                    tr = $('<tr />'),
                    name = $('<th />', {
                        text: prefix + property
                    }),
                    value = $('<td />', {
                        text: object[property] ? 'Yes' : 'Nope'
                    });

                target.append(tr.append(name).append(value));
            }
        }
    };

    traverse(Modernizr, 'Modernizr');

    var uaParser = new UAParser();
    var browser = uaParser.getBrowser();
    var os = uaParser.getOS();
    var device = uaParser.getDevice();
    console.log(device);
    
    $("#browser-info").html('<p>Browser name: ' + browser.name + '</p> \
        <p>Browser version: ' + browser.version + '</p> \
        <p>OS: ' + os.name + '</p> \
        <p>Device: ' + device.vendor + '</p>');
});
