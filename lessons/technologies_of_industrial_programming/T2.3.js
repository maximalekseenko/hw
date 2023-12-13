solve = (data) => {
    return Math.ceil(Number(data) / 100);
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});