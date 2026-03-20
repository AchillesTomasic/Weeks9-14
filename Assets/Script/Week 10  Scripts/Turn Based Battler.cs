using System.Collections;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;

public class TurnBasedBattler : MonoBehaviour
{
    public AnimationCurve apeAnim;
    public float apeDuration;

    private Coroutine apeCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator moveApe()
    {
        float duration = 0f;

        while (duration < apeDuration) 
        {
            duration += Time.deltaTime;
            Vector2 pos = transform.position;
            pos.x = apeAnim.Evaluate(duration / apeDuration);
            transform.position = pos;  
            yield return null;
           
        }
    }
    public void moveApeButton()
    {
       apeCoroutine = StartCoroutine(moveApe());
    }
}
