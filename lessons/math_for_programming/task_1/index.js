// --- HTML elements ---

/** @type {HTMLElement} */
var GAME_BORDERS

/** @type {HTMLElement} */
var GAME_BALL


// --- game logic constants ---
const V_SPEED = 10;
const H_SPEED = 20;
const BALL_START_X = 50;
const BALL_START_Y = 50;
const BALL_RADIUS = 5;
const BALL_STEP_WAIT_MS = 100


// --- game runtime variables ---
var isVMovePositive = false,
    isHMovePositive = true;

var ballPositionX,
    ballPositionY;

var gameAreaWidth,
    gameAreaHeight;

var isRunning = false;


window.addEventListener('DOMContentLoaded', function () {
    GAME_BORDERS = document.getElementById("game-borders");
    GAME_BALL = document.getElementById("game-ball");
});


function UpdateBallPosition() {
    // fix position
    //  left wall
    if (ballPositionX <= 0) {
        ballPositionX = 0;
        isHMovePositive = !isHMovePositive;
    }
    //  right wall
    if (ballPositionX >= gameAreaWidth) {
        ballPositionX = gameAreaWidth;
        isHMovePositive = !isHMovePositive;
    }
    //  top wall
    if (ballPositionY <= 0) {
        ballPositionY = 0;
        isVMovePositive = !isVMovePositive;
    }
    //  bottom wall
    if (ballPositionY >= gameAreaHeight) {
        ballPositionY = gameAreaHeight;
        isVMovePositive = !isVMovePositive;
    }


    // Update position visually
    GAME_BALL.style.left = ballPositionX + "px";
    GAME_BALL.style.top = ballPositionY + "px";
}

function UpdateGameArea() {
    gameAreaWidth = parseInt(GAME_BORDERS.style.width, 10) - BALL_RADIUS * 2;
    gameAreaHeight = parseInt(GAME_BORDERS.style.height, 10) - BALL_RADIUS * 2;
}

function Initialize() {
    ballPositionX = BALL_START_X;
    ballPositionY = BALL_START_Y;
    GAME_BALL.style.height = BALL_RADIUS * 2;

    UpdateBallPosition();
    UpdateGameArea();
}

async function StartGameLoop() {
    isRunning = true;
    while (isRunning) {
        await new Promise(resolve => setTimeout(resolve, BALL_STEP_WAIT_MS));
        ballPositionX += H_SPEED * (isHMovePositive ? 1 : -1);
        ballPositionY += V_SPEED * (isVMovePositive ? 1 : -1);

        UpdateBallPosition();
    }
}

function GameBegin() {
    Initialize();
    StartGameLoop();
}

function GameRescale() {

}
