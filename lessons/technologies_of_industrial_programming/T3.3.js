class Random
{
    static nextDouble(low, high)
    {
        return Math.random() * (high - low) + low;
    }
    static nextInt(low, high)
    {
        return Math.round(Random.nextDouble(low, high));
    }
    static nextElement(array) 
    {
        return array[Random.nextInt(0, array.length)];
    }
}

solve = (data) => {
    
    data = data.split(' ');

    _results = [
        Random.nextDouble( Number(data[0]), Number(data[1]) ),
        Random.nextInt( Number(data[2]), Number(data[3]) ),
        Random.nextElement( data.splice(4) )
    ]

    return '[' + _results.join(', ') + ']';
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});