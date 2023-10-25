solve = (data) => {
    data = Number(data);
    _found = Array.from(Array(data).keys()).filter(
        (_num) => data % _num == 0
    ).slice(1);

    if (_found.length == 0) return data + " является простым"

    return '[' + _found.join(', ') + ']';
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});