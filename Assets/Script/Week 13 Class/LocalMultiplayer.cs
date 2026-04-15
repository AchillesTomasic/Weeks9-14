using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class LocalMultiplayer : MonoBehaviour
{
    public CinemachineImpulseSource impulseSource;
    public SpriteRenderer playerRenderer;
    public int health = 5;
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
    public IEnumerator DamagedEnumerator;
    public ParticleSystem particleDamaged;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        killPlayer();
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
    public void OnTakeDamage(InputAction.CallbackContext context)
    {
        if(DamagedEnumerator != null)
        {
            StopCoroutine(DamagedEnumerator);
        }
        if(context.performed == true){
        DamagedEnumerator = spinPlayer();
        StartCoroutine(DamagedEnumerator);
        impulseSource.GenerateImpulse();
        health -= 1;
        }
    }
    private void killPlayer()
    {
        if(health < 0)
        {
            playerRenderer.color = new Color(255,0,0);
        }
    }
     public IEnumerator spinPlayer()
    {
        float timer = 0;
        particleDamaged.Emit(10);
        while(timer < 1){
        float rotateZ = Mathf.Lerp(0,360,timer / 1);
        timer += Time.deltaTime;
        transform.eulerAngles = new Vector3(0,0,rotateZ);
        yield return null;
        }
        
    }   
    
    public IEnumerator interactDashEnumerator()
    {
        
        trailRendererDash.enabled = true;
        moveSpeed = dashSpeed;
        
        
        yield return new WaitForSeconds(1);
        
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
