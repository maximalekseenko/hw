solve = (data) => {
    data = data.split(' ').map(Number);

    return (
        data[0] + data[1] > data[2] &&
        data[1] + data[2] > data[1] &&
        data[0] + data[2] > data[1]
    )
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});