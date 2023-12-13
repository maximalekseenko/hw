function FindIndexes(_array, _func) {
    _found = []

    _array.forEach((_element, _index) => {
        if (_func(_element))
        _found.push(_index)
    });

    return _found;
}


solve = (data) => {
    data = data.split(' ').map(Number);
    return FindIndexes(data, _e =>_e > 2);
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});