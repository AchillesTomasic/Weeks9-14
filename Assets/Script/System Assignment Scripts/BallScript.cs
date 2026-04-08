using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Vector2 distance; // direciton that the ball moves and how much it moves by.
    public GameObject batObj; // object refrence for the bat

    public Transform bottomLeft; // used to find the position of the bottom left corner
    public Transform topRight; // used to find the top right position

    private float randXOffset; // used to offset the x
    private float randYOffset; // used to offset the y
    public float speed;// speed used to move the ball 
    public float maxSpeed; //max speed the ball can reach
    private float speedChanger; // used to change the speed of the balls
    private float dragForce = 1f;// used to ensure the balls speed does not get too high
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        distance = new Vector2(1,1);
    }

    // Update is called once per frame
    void Update()
    {
        ballMovement(); // moves the ball
        decreaseBallSpeed();// slows down the ball
        onFlipDirection();// used for the boundaries of the game
    }
    void ballMovement()
    {
        transform.position += (Vector3)distance * Time.deltaTime * speedChanger;// moves the ball
    }
    // used to increase the balls speed
    private void increaseBallSpeed()
    {
        speedChanger += speed; // increases the speed of the ball by a speed factor
    }
    // used to slow down the ball over time
    private void decreaseBallSpeed()
    {
        if(speedChanger >= maxSpeed)
        {
            speedChanger = maxSpeed;
        }
        if(speedChanger > speed)
        {
            speedChanger -= dragForce * Time.deltaTime;
        }
        // checks the current speed of the ball
        if(speedChanger <= speed)
        {
            speedChanger = speed; // resets the speed of the ball
        }
    }
    // flips the direction of the ball when it collides with a wall
    void onFlipDirection() // true is X, Y is false
    {
        float additionalSizeX = transform.localScale.x / 2;
        float additionalSizeY = transform.localScale.y / 2;
        if (transform.position.x - additionalSizeX <= bottomLeft.position.x || 
        transform.position.x + additionalSizeX >= topRight.position.x)
        {
            distance *= new Vector2(-1,1);// flips the x direction
        }
        if (transform.position.y - additionalSizeY <= bottomLeft.position.y || 
        transform.position.y + additionalSizeY >= topRight.position.y)
        {
             distance *= new Vector2(1,-1);// flips the y direction
        }
    }
    public void onBatHit()
    {
        float hitAngle = Vector3.Angle(transform.position, batObj.transform.position);// finds angle between players position and the bats position
        float radiusPlayer= 2; // radius used to find point that ball moves towards
        float newXValue = transform.position.x + ( radiusPlayer * Mathf.Cos(hitAngle));// finds the x value for where the ball will travel when hit
        float newYValue = transform.position.y + ( radiusPlayer * Mathf.Sin(hitAngle));// finds the y value for where the ball travels when hit

        distance = new Vector2(newXValue, newYValue);// sets the movement of the ball to be equal to the new direction of movment
         increaseBallSpeed(); // increases ball speed
    }
}
