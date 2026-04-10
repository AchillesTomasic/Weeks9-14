using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiplayer : MonoBehaviour
{
    public Vector2 moveDir;
    public float moveSpeed;
    public float attackAnimationTime;
    public bool attack;
    public AudioClip attackAudio;
    public AnimationCurve animationCurve;
    public LocalMultiplayerManager manager;
    public IEnumerator attackEnumerator;
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
            attackEnumerator = attackingAnimation();
            StartCoroutine(attackEnumerator);
            PlayerInput playerInput = GetComponent<PlayerInput>();
            manager.TryAttack(playerInput);
        }
    }
    //Attacking
    public IEnumerator attackingAnimation()
    {
        float timer = 0;
        while (timer > attackAnimationTime)
        {
            float squeeze = animationCurve.Evaluate(timer);
            transform.localScale = new Vector3(squeeze, squeeze, 0);
            timer += Time.deltaTime;
            yield return null;
        }

    }
}
