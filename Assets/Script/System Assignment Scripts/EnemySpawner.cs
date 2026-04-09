using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;
public class EnemySpawner : MonoBehaviour
{
    public int score;//saves the players current score
    public UIManager UImanager; // obtains a refrence to the UI manager
    public float timerBetweenEnemySpawns;
    public List<GameObject> enemyTypeList = new List<GameObject>(); // list of enemies types
    private IEnumerator SpawnDelay;
    public bool spawingAvalible = true;// checks if an enemy can spawn into the scene
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnDelay = waitBetweenEnemies(); // sets the coroutine to the wait between enemies
        AddEnemy();// starts the recursive chaun for spawning
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // waits a period of time between enemy spawns using an IEnumerator
    private IEnumerator waitBetweenEnemies()
    {
        float timer = timerBetweenEnemySpawns;
        while(timer > 0)
        {
            timer -= Time.deltaTime; // lowers timer over time
            yield return null; // stops the program at this frame
        }

        AddEnemy();
        
    }
    // adds an enemy into the scene
    private void AddEnemy()
    {
        int selectType = Random.Range(0, enemyTypeList.Count); //selects one of the spawnable enemies
        SpawnDelay = waitBetweenEnemies();// reinstantiates the spawn delay
        Instantiate(enemyTypeList[selectType], transform.position, Quaternion.identity); //places them at the position of the spawner
        StartCoroutine(SpawnDelay);// starts the spawn delay coroutine
    }
    // stops enemies from spawning into the scene
    public void OnStopSpawning()
    {
        StopCoroutine(SpawnDelay); // stops the spawning coroutine
    }
    // no result when destroyed
    public void NothingDestory()
    {
            Debug.Log("Nothing"); // shows that nothing happens
    }
    //points gained or losed when destroyed
    public void PointsDestroy(int numberOfPoints)
    {
        score += numberOfPoints; // increases the score
        UImanager.highscore.SetText("Highscore: {0}",score); // sets the highscore equal to 
    }
    //splits into multiple when destroyed
    public void splitIntoDestroy(Transform thisposition)
    {
        Instantiate(enemyTypeList[0], new Vector3(thisposition.position.x - 3,thisposition.position.y,0), Quaternion.identity); // spawns enemy at last enemies position
        Instantiate(enemyTypeList[0], new Vector3(thisposition.position.x + 3,thisposition.position.y,0), Quaternion.identity); // spa
    }
   
}
