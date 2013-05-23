var specialConsole = (function () {
    // module methods
    function writeLine() {
        var output = formatString.apply(this, arguments);
        console.log(output.toString());
    }

    function writeError() {
        var output = formatString.apply(this, arguments);
        console.error(output.toString());
    }

    function writeWarning() {
        var output = formatString.apply(this, arguments);
        console.warn(output.toString());
    }

    // formating func
    function formatString() {
        var output = arguments[0];

        for (var i = 1; i < arguments.length; i++)
            output = output.replace(new RegExp('\\{' + (i - 1) + '\\}', "gi"), arguments[i]);

        return output;
    }

    // expouse
    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    };
}())

// tests
specialConsole.writeLine('Test');
specialConsole.writeLine('Test {0} {1} {2}', 1, 2, 3);

specialConsole.writeWarning('Waring!');
specialConsole.writeWarning('Waring {0} {1} {2}', 1, 2, 3);

specialConsole.writeError('Error!');
specialConsole.writeError('Error {0} {1} {2}', 1, 2, 3);

