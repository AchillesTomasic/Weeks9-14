using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject ballRefrence; // grabs the refrence of the ball from the enemy spawner
    public UnityEvent onDestroyThisObj; // condition that invokes when the object is destroyed
    public bool destroyThisInstance = false;// used as marker to remove this instance of the object from the enemy list
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkBallCollision();
    }
    void checkBallCollision()
    {
        if (ballRefrence.GetComponent<SpriteRenderer>().bounds.Contains(transform.position))
        {
            destroyThisInstance = true; // marks to remove from list
            onDestroyThisObj.Invoke(); // invokes the effect for this enemy type when destroyed, this changes between enemies
            Destroy(gameObject); // destroys this instance of the object from the scene
        }
    }
    public void onDestroy()
    {
            onDestroyThisObj.Invoke(); // invokes the condition for destroying this spesific object
            // destroy the object
    }
    public void GainPoints()
    {
        
    }
}
