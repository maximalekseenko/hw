solve = (data) => {
    data = data.split('.')[1];
    
    return -data.length;
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});