using UnityEngine;
using UnityEngine.InputSystem;

public class SystemsPlayer : MonoBehaviour
{
    public float[] boundaries; // first is the left boundary, second is right
    // variables for controlling the player //
    public float speed; // speed for moving the player
    public GameObject PlayerBatHinge; // used to store the players bat hinge
    private Vector2 moveDir; // vector used to see which way the player is moving
    private Vector2 batDir; // Vector used to detect the position that the bat will point towards
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveThePlayer(); // moves the player every frame
        rotateBatDir();// rotates the bat towards the mouse
    }


    // functions for controlling the player //
    public void OnMovement(InputAction.CallbackContext context)// used for controlling the left and right movement
    {
        moveDir = context.ReadValue<Vector2>(); //reads the value of the controller
    }
    // obtains the values for the bat
    public void OnMousepos(InputAction.CallbackContext context)
    {
        batDir = context.ReadValue<Vector2>(); //reads the value of the mouse
        batDir = Camera.main.ScreenToWorldPoint(batDir); //converts the mouses position from the screen to world 
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
    // used to rotate the bat depending on where the mouse is pointing
    private void rotateBatDir()
    {
        Debug.Log(batDir);
        PlayerBatHinge.transform.up = batDir - (Vector2)transform.position; //points the hinge of the bat towards the mouse 
    }
}
