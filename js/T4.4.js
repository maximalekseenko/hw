solve = (data) => {
    return data.match(/^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/) != null;
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});