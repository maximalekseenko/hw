solve = (data) => {
    
    data = data.split(' ').map(Number);

    return (data.reduce((_num1, _num2) => _num1 + _num2, 0) / data.length);
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});