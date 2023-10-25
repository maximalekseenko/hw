solve = (data) => {
    data = data.split(' ').map(Number);

    return '[' + data.map(
        (_num1, __index1) => data.filter(
            (_num2, __index2) => __index1 < __index2 && _num2 < _num1
        ).length
    ).join(', ') + ']';
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});