solve = (data) => {
    let mid = Math.floor(data.length / 2);
    if (data.length % 2 == 0) 
        return data.slice(mid - 1, mid + 1);
    else return data.slice(mid, mid + 1);
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});