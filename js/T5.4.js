function GetChar(codePoint){
    if (codePoint < 0x10000) {
        s = String.fromCharCode(codePoint);
    } else {
        var offset = codePoint - 0x10000;
        s = String.fromCharCode(0xd800 + (offset >> 10),
                                0xdc00 + (offset & 0x3ff));
    }
    return s
}

String.prototype.toUnicode = function(){
    var result = "";
    for(var i = 0; i < this.length; i++){
        // Assumption: all characters are < 0xffff
        result += "\\u" + ("000" + this[i].charCodeAt(0).toString(16)).substr(-4);
    }
    return result;
};

function IsCombi(_char)
{
    return _char.toUnicode().match(/\u/g || ['']).length > 1
}


solve = (data) => {

    _found = []

    i = 0
    while (GetChar(i))
    {
        _char = GetChar(i)

        if (IsCombi(_char.normalize("NFD"))) {
            _found.push(_char)
            console.log(_char)
        } else if (IsCombi(_char.normalize("NFC"))) {
            _found.push(_char)
            console.log(_char)
        }
        
        i ++;
    }
    return _found;
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});
// ℌ