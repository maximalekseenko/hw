solve = (data) => {
    return data.match(/src=['"`].+?['"`]/);
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});