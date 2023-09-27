solve = (data) => {
    data = Array.from(data);
    var new_data = []

    data.forEach((char) => {
        if (char == char.toUpperCase()) new_data.push(' ', char);
        else new_data.push(char);
    });

    if (new_data[0] == ' ') new_data.shift()

    return new_data.join('');
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});