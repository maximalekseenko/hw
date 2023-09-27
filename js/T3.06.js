solve = (data) => {
    data = Number(data);

    return Array.from(Array(data).keys()).filter(
        (_num) => data % _num == 0
    ).slice(1);
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});