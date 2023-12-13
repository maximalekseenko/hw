solve = (data) => {
    return data.replaceAll(/[^\d]/g, '');
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});