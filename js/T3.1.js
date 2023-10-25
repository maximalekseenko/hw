class Point
{
    constructor(__x, __y)
    {
        this.x = __x;
        this.y = __y;
    }

    getX() { return this.x; }
    getY() { return this.y; }
    translate(__dx, __dy)
    {
        this.x += __dx;
        this.y += __dy;
    }
    scale(__value)
    {
        this.x *= __value;
        this.y *= __value;
    }
}


myPoint = new Point(0, 0);
function createPoint(__x, __y) { myPoint = new Point(__x, __y); }
function getX() { return myPoint.getX(); }
function getY() { return myPoint.getY(); }
function translate(__dx, __dy) { myPoint.translate(__dx, __dy); }
function scale(__value) { myPoint.translate(__value); }


solve = (data) => {
    data = data.split(' ');
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});