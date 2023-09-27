// ---------- +++ CONSTANTS +++ ----------
const FIELDSIZE = 3;
const prompt = require("prompt-sync")({ sigint: true });


// ---------- +++ GLOBAL RUNTIME VARIABLES +++ ----------
var isRunning = true;
var field = new Array(FIELDSIZE).fill(0).map(_ => new Array(FIELDSIZE).fill(' '));
var currTurn = 'x';


// ---------- +++ FUNCTIONS +++ ----------
function Clear()
{
    isRunning = true;
    field = new Array(FIELDSIZE).fill(0).map(_ => new Array(FIELDSIZE).fill(' '));
    currTurn = 'x';
}

function Loop()
{
    PrintBoard();

    while (!Turn()) ;

    if (CheckForWin())
    {
        isRunning = false;
        PrintWin();
    }
    else NextTurn();
}

function Turn()
{
    pos = prompt("turn of " + currTurn + ": ").split(' ').map(Number);

    // validate user input
    if (pos[0] < 0 || pos[1] < 0) return false;
    if (pos[0] >= FIELDSIZE || pos[1] >= FIELDSIZE) return false;
    if (field[pos[0]][pos[1]] != ' ') return false;

    // make turn
    field[pos[0]][pos[1]] = currTurn;

    return true;
}


function PrintBoard()
{
    field.forEach((_line) => console.log(_line));
}


function CheckForWin()
{
    var _lastIndex = field.length - 1;
    return field.some(_line => _line[0] != ' ' && _line.every(_value => _value == _line[0])) ||
           field.some((_, _index) => field[0][_index] != ' ' && field.every((_line) => _line[_index] == field[0][_index] != ' ')) ||
           (field[0][0] != ' ' && field.every((_line, _index) => _line[_index] == field[0][0] != ' ')) ||
           (field[_lastIndex][_lastIndex] != ' ' && field.every((_line, _index) => _line[_lastIndex - _index] == field[_lastIndex][_lastIndex] != ' '))
}
function PrintWin()
{
    PrintBoard();
    prompt("player " + currTurn + " won!").split(' ').map(Number);
}
function NextTurn()
{
    if (currTurn == 'x')
        currTurn = 'o';
    else currTurn = 'x';
}


// ---------- +++ THE IGNITER +++ ----------
while (true) { 
    Clear(); 
    while (isRunning) Loop();
}