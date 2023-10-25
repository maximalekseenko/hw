solve = (data) => {
    return new Date().getTimezoneOffset() / 60;
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});