using UnityEngine;
using UnityEngine.InputSystem;

public class SystemsPlayer : MonoBehaviour
{
    public float speed; // speed for moving the player
    public float[] boundaries; // first is the left boundary, second is right
    private Vector2 moveDir; // vector used to see which way the player is moving
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveThePlayer(); // moves the player every frame
    }


    // functions for controlling the player //
    public void OnMovement(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<Vector2>(); //reads the value of the controller
    }
    // used to move the player based on their input
    private void moveThePlayer()
    {
        // left boundary
        if(transform.position.x - (transform.localScale.x/2) < boundaries[0])
        {
           transform.position = new Vector3(boundaries[0] + (transform.localScale.x/2) + 0.001f,transform.position.y,transform.position.z); //moves the player back to the left when they hit the boundary
        }
        // right boundary
        if(transform.position.x + (transform.localScale.x/2) > boundaries[1])
        {
           transform.position = new Vector3(boundaries[1] - (transform.localScale.x/2) - 0.001f,transform.position.y,transform.position.z); //moves the player back to the right when they hit the boundary
        }
        transform.position += new Vector3(moveDir.x,0,0) * speed * Time.deltaTime; // moves the player based on the direction they are moving their controller
    }
}
