solve = (data) => {
    data = data.split(' ').map(Number);

    if (data.length < 3) return false;

    var ascend = true;
    return data.every(
        (_value, _index) => {
            if (_index == 0) return true;

            if (ascend && _value < data[_index - 1])
            {
                ascend = false;
                return true;
            }

            return (ascend && (_value > data[_index - 1])) || (!ascend && (_value < data[_index - 1]))
        }
    )
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});