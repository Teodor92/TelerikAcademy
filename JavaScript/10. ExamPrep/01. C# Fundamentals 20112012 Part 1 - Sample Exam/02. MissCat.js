function Solve(args) {
    var n = parseInt(args[0]);
    var cats = [];
    var i = 0;

    for (var i = 0; i < 12; i++) {
        cats[i] = 0;
    }

    for (i = 0; i < n; i++) {
        var index = i + 1;
        var vote = parseInt(args[index]);
        switch (vote) {
            case 1: cats[1] = cats[1] + 1; break;
            case 2: cats[2] = cats[2] + 1; break;
            case 3: cats[3] = cats[3] + 1; break;
            case 4: cats[4] = cats[4] + 1; break;
            case 5: cats[5] = cats[5] + 1; break;
            case 6: cats[6] = cats[6] + 1; break;
            case 7: cats[7] = cats[7] + 1; break;
            case 8: cats[8] = cats[8] + 1; break;
            case 9: cats[9] = cats[9] + 1; break;
            case 10: cats[10] = cats[10] + 1; break;
        }

    }

    var bestCat = 0;
    var j = 0;

    for (i = 1; i < 11; i++) {
        for (j = i; j < 11; j++) {
            if (cats[j] > cats[bestCat]) {
                bestCat = j;
            }
            else if (cats[j] === cats[bestCat] && j < bestCat) {
                bestCat = j;
            }
        }
    }

    return bestCat;

}