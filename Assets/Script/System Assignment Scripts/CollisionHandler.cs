using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;

public class CollisionHandler : MonoBehaviour
{
    public UnityEvent onBatCollision;// what activates when the direction is flipped
    public List<SpriteRenderer> BatFlipDir; //collision will flip on the left.
    public List<SpriteRenderer> destroyalbeObj; //List of destroyabe collision objects
    public IEnumerator hitBufferCor; // used to store the coroutine buffer

    public bool isHittable = true; // checks if the ball is free to be hit

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitBufferCor = waitBeforeHit(0.5f);
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
                hitBufferCor = waitBeforeHit(0.5f);
                onBatCollision.Invoke(); //invokes the bat collision
                StartCoroutine(hitBufferCor); // starts coroutine to wait between hits
                isHittable = false; // makes it no longer hittable
            }
        }
        }
        

    }
    public void stopCoroutineBuffer()
    {
        StopCoroutine(hitBufferCor); // stops the coroutine buffer
    }
    
    
}
