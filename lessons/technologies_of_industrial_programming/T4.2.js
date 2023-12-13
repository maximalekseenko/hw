
solve = (data) => {
    data = Number(data);

    const buffer = new ArrayBuffer(8);
    intView = new Int32Array(buffer); 
    floatView = new Float64Array(buffer);
    floatView[0] = data;

    if (intView[0] > 0)
        intView[0] ++;
    else intView[1] ++;
        
    return floatView[0];
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});