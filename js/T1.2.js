let ALPHABET = 'abcdefghijklmnopqrstuvwxyz'.split("");

function IsPangram(string){
    string = string.toLowerCase();
    return ALPHABET.every(x => string.includes(x));
}


process.stdin.on('data', data => {

    if (IsPangram(data.toString())) console.log("yes");
    else console.log("no");

    process.exit();
});


// The five boxing wizards jump quickly