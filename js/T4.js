solve = (data) => {
    data = data.split(' ');

    data = data.filter((string) => string.match(/^[0-9]+$/) != null);

    return data.join(' ');
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});