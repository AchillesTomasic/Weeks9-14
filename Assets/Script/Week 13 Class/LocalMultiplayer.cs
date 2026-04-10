using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiplayer : MonoBehaviour
{
    public Vector2 moveDir;
    public float moveSpeed;
    public float dashSpeed;
    public float normalSpeed;
    public float attackAnimationTime;
    public bool attack;
    public AudioSource attackAudio;
    public AnimationCurve animationCurve;
    public LocalMultiplayerManager manager;
    public TrailRenderer trailRendererDash;
    //ienumerators
    public IEnumerator attackEnumerator;
    public IEnumerator dashEnumerator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = normalSpeed;
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
            //checks if coroutine even exists
            if (attackEnumerator != null)
            {
                StopCoroutine(attackEnumerator); //resets the coroutine
            }
            attackEnumerator = attackingAnimation();
            StartCoroutine(attackEnumerator); //plays new coroutine

            PlayerInput playerInput = GetComponent<PlayerInput>();
            manager.TryAttack(playerInput);
        }
    }
    //Dash
    public void OnInteract(InputAction.CallbackContext context)
    {
        if(dashEnumerator != null)
        {
            StopCoroutine(dashEnumerator);
        }
        StartCoroutine(dashEnumerator);
        
    }
    public IEnumerator interactDashEnumerator()
    {
        float timer = 1f;
        trailRendererDash.enabled = true;
        moveSpeed = dashSpeed;
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        trailRendererDash.enabled = false;
        moveSpeed = normalSpeed;
    }
    //Attacking ANIMATION ENUMERATOR
    public IEnumerator attackingAnimation()
    {
        float timer = 0;
        attackAudio.Play();
        while (timer < attackAnimationTime)
        {
            
            float squeeze = animationCurve.Evaluate(timer);
            transform.localScale = new Vector3(squeeze, squeeze, 0);
            
            timer += Time.deltaTime;
            yield return null;
        }
        Debug.Log(timer);
    }
}
