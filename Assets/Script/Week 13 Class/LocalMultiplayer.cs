using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiplayer : MonoBehaviour
{
    public Vector2 moveDir;
    public float moveSpeed;
    public bool attack;
    public LocalMultiplayerManager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)moveDir *  moveSpeed * Time.deltaTime;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<Vector2>();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PlayerInput playerInput = GetComponent<PlayerInput>();
            manager.TryAttack(playerInput);
        }
    }
}
