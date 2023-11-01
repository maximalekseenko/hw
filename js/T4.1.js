
solve = (data) => {
    data = Math.log10(Number(data))
    return data > 0? Math.ceil(data) : Math.floor(data);
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});