solve = (data) => {
    return '[' + data.split('').reverse().map(Number).join(', ') + ']';
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});