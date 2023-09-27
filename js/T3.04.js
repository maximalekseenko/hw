solve = (data) => {
    return data.split('').reverse().map(Number);
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});