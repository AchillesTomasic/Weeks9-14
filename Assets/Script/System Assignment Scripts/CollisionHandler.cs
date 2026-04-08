using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;

public class CollisionHandler : MonoBehaviour
{
    public UnityEvent onBatCollision;// what activates when the direction is flipped
    public List<SpriteRenderer> BatFlipDir; //collision will flip on the left.
    public List<SpriteRenderer> destroyalbeObj; //List of destroyabe collision objects

    private bool isHittable = true; // checks if the ball is free to be hit

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        collisionCheck();
    }
    // used to wait between each hit 
    private IEnumerator waitBeforeHit(float waitTimer)
    {
        while(waitTimer > 0)
        {
            
            waitTimer -= Time.deltaTime;
            yield return null;
        }
        isHittable = true;
    }
    void collisionCheck()
    {
        // loops over every collidable object x
        if(isHittable)
        {
        // loops over every collidable bat interaction object
        for(int i = 0; i < BatFlipDir.Count; i++)
        {
        // looks over all bat interaction flip objects for collision
            if(BatFlipDir[i].bounds.Contains(transform.position))
            {
                onBatCollision.Invoke();
                StartCoroutine(waitBeforeHit(0.5f)); // starts coroutine to wait between hits
                isHittable = false;
            }
        }
        }
        

    }
    void destroyableCollision()
    {
        for(int i = 0; i < destroyalbeObj.Count; i++)
        {
        // looks over all destroyable objects for collision
            if(destroyalbeObj[i].bounds.Contains(transform.position))
            {
            }
        }
    }
}
