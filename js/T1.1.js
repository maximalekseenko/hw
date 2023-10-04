solve = (data) => {
    data = data.split(' ').map(Number);

    return (data[0] + data[1]) % 360;
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});