solve = (data) => {
    data = Number(data);


    var sum = 0;
    Array.from(Array(data).keys()).forEach(
        (_num) => {
            if (data % _num == 0) sum += 1;
        }
    );
    return sum + 1;
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});