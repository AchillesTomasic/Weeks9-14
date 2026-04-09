using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed; // speed of enemy
    public float[] boundaries; // first is the left boundary, second is right
    public GameObject ballRefrence; // grabs the refrence of the ball from the enemy spawner
    public UnityEvent onDestroyThisObj; // condition that invokes when the object is destroyed
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkBallCollision();// checks if the ball collides with this enemy
        enemyMovement();// moves the enemies
    }
    void checkBallCollision()
    {
        // checks if enemy touches the ball
        if (ballRefrence.GetComponent<SpriteRenderer>().bounds.Contains(transform.position))
        {
        
            onDestroyThisObj.Invoke(); // invokes the effect for this enemy type when destroyed, this changes between enemies
            Destroy(gameObject); // destroys this instance of the object from the scene
        }
    }
    // moves the enemies
    void enemyMovement()
    {
        transform.position += new Vector3(1,0,0)* speed * Time.deltaTime; // moves the enemy
        // checks if enemy hits boarder
        if(transform.position.x - (transform.localScale.x/2) < boundaries[0])
        {
            speed *= -1;// flips the direction
            transform.position = new Vector3(boundaries[0] + (transform.localScale.x/2) + 0.1f,transform.position.y,0); // makes sure enemies dont get stuck in wall
        }
        if(transform.position.x + (transform.localScale.x/2) > boundaries[1])
        {   
            speed *= -1;// flips the direction
            transform.position = new Vector3(boundaries[1]- (transform.localScale.x/2)- 0.1f,transform.position.y,0); // makes sure enemies dont get stuck in wall
        }
    }
}
