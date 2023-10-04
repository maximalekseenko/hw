solve = (data) => {
    
     if (Number(data) % 2) return "Odd";
     else return "Even";
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});