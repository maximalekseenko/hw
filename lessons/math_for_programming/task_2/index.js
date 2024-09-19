class BoxCollider {
    constructor(x = 0, y = 0, w = 0, h = 0) {
        /**
         * @type {number}
         * @private
         */
        this.x = x;

        /**
         * @type {number}
         * @private
         */
        this.y = y;

        /**
         * @type {number}
         * @private
         */
        this.w = w;

        /**
         * @type {number}
         * @private
         */
        this.h = h;
    }

    /**
     * 
     * @param {number?} newX 
     * @param {number?} newY 
     * @param {number?} newW 
     * @param {number?} newH 
     */
    Update(newX = undefined, newY = undefined, newW = undefined, newH = undefined) {
        if (newX != undefined)
            this.x = newX;
        if (newY != undefined)
            this.y = newY;
        if (newW != undefined)
            this.w = newW;
        if (newH != undefined)
            this.h = newH;
    }

    /**
     * 
     * @param {BoxCollider} otherCollider 
     * @returns {boolean}
     */
    DoCollideWith(otherCollider) {
        return this.x + this.w >= otherCollider.x
            && this.y + this.h >= otherCollider.y
            && otherCollider.x + otherCollider.w >= this.x
            && otherCollider.y + otherCollider.h >= this.y
    }

    GetCollisionSide(otherCollider) {
        return [
            otherCollider.x + otherCollider.w - this.x,
            this.y + this.h - otherCollider.y,
            this.x + this.w - otherCollider.x,
            otherCollider.y + otherCollider.h - this.y
        ].reduce((r, v, i, a) => v >= a[r] ? r : i, -1);
    }

    /**
     * 
     * @param {BoxCollider} otherCollider 
     * @returns {number}
     */
    GetCollisionAngle(otherCollider) {
        return this.GetCollisionSide(otherCollider) / 2 * Math.PI;
    }

    /**
     * 
     * @param {BoxCollider} otherCollider 
     * @returns {[number, number]?}
     */
    DeCollide(otherCollider) {
        if (!this.DoCollideWith(otherCollider)) return undefined;

        let collisionSide = this.GetCollisionSide(otherCollider);

        if (collisionSide == 0)
            this.x = otherCollider.x + otherCollider.w;
        else if (collisionSide == 1)
            this.y = otherCollider.y - this.h;
        else if (collisionSide == 2)
            this.x = otherCollider.x - this.w;
        else if (collisionSide == 3)
            this.y = otherCollider.y + otherCollider.h;

        return [this.x, this.y];
    }
}

class BallController {

    /**
     * 
     * @param {HTMLImageElement} ballImage html element that this controller is attached to
     */
    constructor(ballImage = undefined, radius = 5, speed = 10, movementAngle = -Math.PI / 4) {
        /**
         * @type {BoxCollider}
         */
        this.collider = new BoxCollider()

        /** html image this controller is 
         * @private
         * @type {HTMLImageElement}
         */
        this._ballImage;
        this.AttachToImage(ballImage);

        /** Defines the radius of the ball.
         * @private
         * @type {number} 
         */
        this._radius;
        this.SetRadius(radius);

        /** Defines how much pixels this ball moves per second. 
         * @type {number} 
         */
        this.speed = speed;

        /** @type {number} */
        this._positionX = 0;
        /** @type {number} */
        this._positionY = 0;

        /** 
         * @private
         * @type {number} 
         */
        this._movementAngle;
        this.SetMovementAngle(movementAngle);

    }

    /** Sets or updates radius of the ball.
     * @param {number} newRadius 
     */
    SetRadius(newRadius) {

        // Set
        if (newRadius != undefined)
            this._radius = newRadius;

        // Update
        if (this._ballImage != undefined) {
            this._ballImage.style.height = this._radius * 2 + "px";
            this.collider.Update(
                this._positionX - this._radius,
                this._positionY - this._radius,
                this._radius * 2,
                this._radius * 2
            );
        }
    }

    /**
     * 
     * @param {HTMLImageElement} ballImage 
     */
    AttachToImage(ballImage) {
        this._ballImage = ballImage;

        this.SetRadius();
        this.SetPosition();
    }


    SetMovementAngle(newMovementAngle) {
        this._movementAngle = newMovementAngle % (Math.PI * 2);

        if (this._movementAngle < 0)
            this._movementAngle += Math.PI * 2;
    }


    /** Teleports and/or Updates this ball's position.
     * @param {number?} pointX 
     * @param {number?} pointY 
     */
    SetPosition(pointX = undefined, pointY = undefined) {

        // Move
        if (pointX != undefined)
            this._positionX = pointX;

        if (pointY != undefined)
            this._positionY = pointY;


        // Update
        if (this._ballImage != undefined) {
            this._ballImage.style.left = this._positionX - this._radius + "px";
            this._ballImage.style.top = this._positionY - this._radius + "px";
            this.collider.Update(
                this._positionX - this._radius,
                this._positionY - this._radius,
                this._radius * 2,
                this._radius * 2
            );
        }
    }

    /**
     * 
     * @param {number} deltaTime 
     * @param {Array.<BoxCollider>} colliders 
     */
    MakeMove(deltaTime = 1, colliders) {
        var endpointX = this._positionX + this.speed * Math.cos(this._movementAngle);
        var endpointY = this._positionY - this.speed * Math.sin(this._movementAngle);

        // Move
        this.SetPosition(
            endpointX,
            endpointY
        );

        // Fix position
        colliders.forEach(collider => {
            // Cannot collide with self
            if (this.collider === collider) return;

            // Check for collision
            if (!this.collider.DoCollideWith(collider)) return;

            // Change direction
            var collisionAngle = this.collider.GetCollisionAngle(collider);
            this.SetMovementAngle(
                Math.PI + collisionAngle - (this._movementAngle - collisionAngle)
            );

            // Fix collision
            var fixed_collider_position = this.collider.DeCollide(collider);
            this.SetPosition(
                fixed_collider_position[0] + this._radius,
                fixed_collider_position[1] + this._radius
            );
        })
    }
}

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

class Game {
    constructor(borderW = 300, borderH = 200) {
        this._borderWidth;
        this._borderHeight;
        this.SetBorder(borderW, borderH);

        this.isRunning;
        this.isPaused = true;
        this.gameStepTime = 100;

        this.balls_collision = false;
        
        const BORDER_SIZE = 999;
        this._borderColliders = [
            new BoxCollider(0, -BORDER_SIZE, this._borderWidth, BORDER_SIZE),
            new BoxCollider(-BORDER_SIZE, 0, BORDER_SIZE, this._borderHeight),
            new BoxCollider(0, this._borderHeight, this._borderWidth, BORDER_SIZE),
            new BoxCollider(this._borderWidth, 0, BORDER_SIZE, this._borderHeight),
        ];
    }


    SetBorder(newBorderW, newBorderH) {
        this._borderWidth = newBorderW;
        this._borderHeight = newBorderH;

        if (this._borderColliders != undefined) {
            this._borderColliders[0].Update(undefined, undefined, this._borderWidth, undefined);
            this._borderColliders[1].Update(undefined, undefined, undefined, this._borderHeight);
            this._borderColliders[2].Update(undefined, this._borderHeight, this._borderWidth, undefined);
            this._borderColliders[3].Update(this._borderWidth, undefined, this._borderHeight);
        }
    }


    async Start() {
        var ball = new BallController(document.getElementById("game-ball"));
        ball.SetPosition(10, 10);
        ball.SetRadius(10);
        ball.SetMovementAngle(-Math.PI / 4);

        var ball2 = new BallController(document.getElementById("game-ball2"));
        ball2.SetPosition(50, 50);
        ball2.SetRadius(15);
        ball2.SetMovementAngle(Math.PI / 4);

        this.isRunning = true;
        while (this.isRunning) {
            await new Promise(resolve => setTimeout(resolve, this.gameStepTime));

            if (this.isPaused) continue;

            if (this.balls_collision) {
                ball.MakeMove(1, [...this._borderColliders, ball.collider, ball2.collider]);
                ball2.MakeMove(1, [...this._borderColliders, ball.collider, ball2.collider]);
            }
            else {
                ball.MakeMove(1, this._borderColliders);
                ball2.MakeMove(1, this._borderColliders);
            }
        }
    }
}

var GAME = new Game();



function UpdateGameArea(aaa) {
    GAME.SetBorder(
        parseInt(aaa.style.width, 10),
        parseInt(aaa.style.height, 10)
    );
}



var isRunning = false;
var isPaused = true;
var gameStepTime = 100;


function ToggleGameLoop() {
    isPaused = !isPaused;
}


window.addEventListener('DOMContentLoaded', function () {
    console.warn("AAAAA")
    GAME.Start();
})