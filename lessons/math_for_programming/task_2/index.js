class BoxCollider {
    constructor(x = 0, y = 0, w = 0, h = 0) {
        /**
         * @type {number}
         * @protected
         */
        this._left;

        /**
         * @type {number}
         * @protected
         */
        this._top;

        /**
         * @type {number}
         * @protected
         */
        this._width;

        /**
         * @type {number}
         * @protected
         */
        this._height;

        /**
         * @type {number}
         * @protected
         */
        this._right;

        /**
         * @type {number}
         * @protected
         */
        this._bottom;

        this.Update(x, y, w, h);
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
            this._left = newX;
        if (newY != undefined)
            this._top = newY;
        if (newW != undefined)
            this._width = newW;
        if (newH != undefined)
            this._height = newH;

        if (newX != undefined || newW != undefined)
            this._right = this._left + this._width;
        if (newY != undefined || newH != undefined)
            this._bottom = this._top + this._height;
    }

    /** Checks if this collider is inside another collider.
     * @param {BoxCollider} otherCollider 
     * @returns {boolean}
     */
    DoCollide(otherCollider) {
        return this._right >= otherCollider._left
            && this._top <= otherCollider._bottom
            && this._left <= otherCollider._right
            && this._bottom >= otherCollider._top
    }

    /**
     * @param {BoxCollider} otherCollider 
     * @returns {number?}
     */
    GetCollisionSide(otherCollider) {
        if (!this.DoCollide(otherCollider)) return undefined;

        return [
            Math.abs(this._left - otherCollider._right),
            Math.abs(otherCollider._top - this._bottom),
            Math.abs(otherCollider._left - this._right),
            Math.abs(this._top - otherCollider._bottom),
        ].reduce((
            last_best_index, 
            value, 
            index, 
            array
        ) => value >= array[last_best_index] ? last_best_index : index, 5);
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
        if (!this.DoCollide(otherCollider)) return undefined;

        let collisionSide = this.GetCollisionSide(otherCollider);

        
        if (collisionSide == 0)
            this.Update(
                otherCollider._right,
                undefined
            )
        else if (collisionSide == 1)
            this.Update(
                undefined,
                otherCollider._top - this._height
            )
        else if (collisionSide == 2)
            this.Update(
                otherCollider._left - this._width,
                undefined
            )
        else if (collisionSide == 3)
            this.Update(
                undefined,
                otherCollider._bottom
            )
        
        return [this._left, this._top];
    }
}

class BallController {

    /**
     * 
     * @param {HTMLImageElement=} ballImage html element that this controller is attached to
     */
    constructor(ballImage, radius = 5, positionX = 0, positionY = 0, speed = 10, movementAngle = -Math.PI / 4) {
        /**
         * @readonly
         * @type {BoxCollider}
         */
        this.collider = new BoxCollider()

        /** html image this controller is 
         * @private
         * @type {HTMLImageElement}
         */
        this._ballImage;

        /** Defines the radius of the ball.
         * @private
         * @type {number} 
         */
        this._radius;

        /** Defines how much pixels this ball moves per second. 
         * @type {number} 
         */
        this.speed = speed;

        /** 
         * @private
         * @type {number} 
         */
        this._positionX;
        /** 
         * @private
         * @type {number}
         */
        this._positionY;

        /** 
         * @private
         * @type {number} 
         */
        this._movementAngle;

        // Set initial values
        this.AttachToImage(ballImage);
        this.SetRadius(radius);
        this.SetPosition(positionX, positionY);
        this.SetMovementAngle(movementAngle);
    }

    /** Sets or updates radius of the ball.
     * @param {number?} newRadius 
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
        if (pointX != undefined
            && pointY != undefined
            && this._ballImage != undefined
        ) {
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

    }

    TryCollide(collider) {
        // Cannot collide with self
        if (this.collider === collider) return;

        // Check for collision
        if (!this.collider.DoCollide(collider)) return;

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
    }
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

        const BORDER_EXTEND = 900;
        this._borderColliders = [
            new BoxCollider(
                -BORDER_EXTEND,
                -BORDER_EXTEND,
                BORDER_EXTEND,
                BORDER_EXTEND * 2 + this._borderHeight
            ),
            new BoxCollider(
                -BORDER_EXTEND,
                -BORDER_EXTEND,
                BORDER_EXTEND * 2 + this._borderWidth,
                BORDER_EXTEND
            ),
            new BoxCollider(
                this._borderWidth,
                -BORDER_EXTEND,
                BORDER_EXTEND,
                BORDER_EXTEND * 2 + this._borderHeight
            ),
            new BoxCollider(
                -BORDER_EXTEND,
                this._borderHeight,
                BORDER_EXTEND * 2 + this._borderWidth,
                BORDER_EXTEND
            ),
        ];
        /**
         * @type {Array.<BallController>}
         */
        this._balls = [];
    }

    AddBall(
        colorRotation,
        radius, positionX, positionY,
        speed, movementAngle
    ) {
        // Set random values
        if (colorRotation == undefined)
            colorRotation = Math.random() * 360;

        if (radius == undefined)
            radius = 5 + Math.random() * 20;

        if (positionX == undefined)
            positionX = Math.random() * this._borderWidth;

        if (positionY == undefined)
            positionY = Math.random() * this._borderHeight;

        if (speed == undefined)
            speed = 5 + Math.random() * 10;

        if (movementAngle == undefined)
            movementAngle = Math.random() * Math.PI * 2;


        // Make and add new ball
        this._balls.push(
            new BallController(
                MakeBall(colorRotation),
                radius, positionX, positionY,
                speed, movementAngle
            )
        );
    };


    SetBorder(newBorderW, newBorderH) {
        this._borderWidth = newBorderW;
        this._borderHeight = newBorderH;

        if (this._borderColliders != undefined) {
            this._borderColliders[2].Update(this._borderWidth, undefined);
            this._borderColliders[3].Update(undefined, this._borderHeight);
        }
    }


    async Start() {
        this.isRunning = true;
        while (this.isRunning) {
            await new Promise(resolve => setTimeout(resolve, this.gameStepTime));

            if (this.isPaused) continue;


            this._balls.forEach(ballToMove => {
                ballToMove.MakeMove();

                this._borderColliders.forEach(collider => ballToMove.TryCollide(collider));
                if (this.balls_collision)
                    this._balls.forEach(otherBall => ballToMove.TryCollide(otherBall.collider));
            })

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


function MakeBall(colorRotation = 0) {
    // Make element
    let newBall = document.createElement("img");
    newBall.src = "./ball.svg";
    newBall.style.height = "0";
    newBall.classList.add("game-object");

    // set color
    newBall.style.filter = `hue-rotate(${colorRotation}rad)`;

    // Return
    document.getElementById("game-field")
        .appendChild(newBall);
    return newBall;
}


window.addEventListener('DOMContentLoaded', function () {
    console.warn("AAAAA")
    GAME.AddBall()
    GAME.AddBall()

    GAME.Start();
})