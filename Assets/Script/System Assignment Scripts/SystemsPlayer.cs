using UnityEngine;
using UnityEngine.InputSystem;

public class SystemsPlayer : MonoBehaviour
{
    public float[] boundaries; // first is the left boundary, second is right
    // variables for controlling the player //
    public float speed; // speed for moving the player
    public GameObject PlayerBatHinge; // used to store the players bat hinge
    private Vector2 moveDir; // vector used to see which way the player is moving
    public Vector3 batDir; // Vector used to detect the position that the bat will point towards
    // used to detect between controller and keyboard
    private Vector3 MousePositionBat; // used for the keyboards controls
    private Vector3 ControllerPositionBat; // used for the controllers controls
    public bool controllerActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveThePlayer(); // moves the player every frame
        rotateBatDir();// rotates the bat towards the mouse
        activeController();// checks which control systems active
    }


    // functions for controlling the player //
    public void OnMovement(InputAction.CallbackContext context)// used for controlling the left and right movement
    {
        moveDir = context.ReadValue<Vector2>(); //reads the value of the controller
    }
    // obtains the values for the bat
 
    public void OnRightStickpos(InputAction.CallbackContext context)
    {
        ControllerPositionBat = context.ReadValue<Vector2>(); //reads the value of the mouse
        ControllerPositionBat = (Vector3)ControllerPositionBat + transform.position; // converts the bats position to be equal with the player pos
        controllerActive = true; // controller is active
        
    }
    public void OnMousePos(InputAction.CallbackContext context)
    {
        MousePositionBat = context.ReadValue<Vector2>(); //reads the value of the mouse
        MousePositionBat = Camera.main.ScreenToWorldPoint(MousePositionBat);// sets the mouse position for the bat
        MousePositionBat.z = 0;
        controllerActive = false; // mouse is active
    }
    public void activeController()
    {
        if(controllerActive)
        {
            batDir = ControllerPositionBat; // sets the bats direction to the controller
        }
        else
        {
            batDir = MousePositionBat; // sets the bat dir to the mouse
        }
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
        PlayerBatHinge.transform.up = (Vector2)batDir - (Vector2)transform.position; //points the hinge of the bat towards the mouse 
    }
}
