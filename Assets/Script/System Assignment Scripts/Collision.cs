using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Collision : MonoBehaviour
{
    public UnityEvent onCollisionFlipDirY;// what activates when the directionx is flipped
    public UnityEvent onCollisionFlipDirX;// what activates when the directiony is flipped
    public List<SpriteRenderer> FlipDirectionX; //collision will flip object along the x direction.
    public List<SpriteRenderer> FlipDirectionY; //collision will flip object along the Y direction.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        collisionCheck();
    }
    void collisionCheck()
    {
        // loops over every collidable object x
        for(int i = 0; i < FlipDirectionX.Count; i++)
        {
            // looks over all x flip objects for collision
            if(FlipDirectionX[i].bounds.Contains(transform.position))
            {
                onCollisionFlipDirX.Invoke();
            }
        }
        // loops over every collidable object y
        for(int i = 0; i < FlipDirectionY.Count; i++)
        {
        // looks over all Y flip objects for collision
            if(FlipDirectionY[i].bounds.Contains(transform.position))
            {
                onCollisionFlipDirY.Invoke();
            }
        }
    }
}
