solve = (data) => {
    return Float64Array(Number.EPSILON) + Float64Array(data);
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});