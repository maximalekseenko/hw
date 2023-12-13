function FindIndexes(_array, _value) {
    _found = []

    _array.forEach((_element, _index) => {
        if (_element == _value)
        _found.push(_index)
    });

    return _found;
}

solve = (data) => {
    data = data.split(' ')
    toFind = data[0];
    data.shift();

    return FindIndexes(data, toFind)
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});