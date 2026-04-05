using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Vector2 distance; // direciton that the ball moves and how much it moves by.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        distance = new Vector2(1,1);
    }

    // Update is called once per frame
    void Update()
    {
        ballMovement();
    }
    void ballMovement()
    {
        transform.position += (Vector3)distance * Time.deltaTime;// moves the ball
    }
    // flips the direction of the ball when it collides with a wall
    public void onFlipDirection(bool dir) // true is X, Y is false
    {
        if (dir)
        {
            distance *= new Vector2(-1,1);// flips the x direction
        }
        else
        {
             distance *= new Vector2(1,-1);// flips the y direction
        }
    }
}
