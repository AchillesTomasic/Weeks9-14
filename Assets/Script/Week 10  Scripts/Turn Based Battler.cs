using System.Collections;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;

public class TurnBasedBattler : MonoBehaviour
{
    public AnimationCurve apeAnim;
    public float apeDuration;
    public float attackDistance;
    public GameObject enemy;
    public bool buttonBActive;

    private Coroutine apeCoroutine;
    private Coroutine enemyCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator enemyApe(){
        if(buttonBActive == true){
            float duration = 0f;
        Vector2 pos = enemy.transform.position;
        float x = enemy.transform.position.x;
        while (duration < apeDuration) 
        {
            duration += Time.deltaTime;
            
            pos.x = x - apeAnim.Evaluate((duration / apeDuration)) * attackDistance;
            enemy.transform.position = pos;  
            yield return null;
           
        }
        buttonBActive = false;
        }

    }
    private IEnumerator moveApe()
    {
        if(buttonBActive == false)
        {
        float duration = 0f;
        Vector2 pos = transform.position;
        float x = transform.position.x;
        while (duration < apeDuration) 
        {
            duration += Time.deltaTime;
            
            pos.x = x + apeAnim.Evaluate((duration / apeDuration)) * attackDistance;
            transform.position = pos;  
            yield return null;
           
        }
        buttonBActive = true;
        }
        
    }
    public void moveApeButton()
    {
       apeCoroutine = StartCoroutine(moveApe());
    }
    public void moveEnemyButton(){
        enemyCoroutine = StartCoroutine(enemyApe());
    }
}
