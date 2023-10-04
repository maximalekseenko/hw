solve = (data) => {
    data = Number(data);

    if (Math.sqrt(data) != Math.round(Math.sqrt(data))) return -1;

    while (true) {
        if (Math.sqrt(++data) == Math.round(Math.sqrt(data)))
            return data
    }
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});