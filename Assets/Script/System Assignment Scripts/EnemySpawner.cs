using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;
public class EnemySpawner : MonoBehaviour
{
    public int maxEnemyCount; // max amount of enemies allowed in the scene at once
    public List<GameObject> enemyList = new List<GameObject>(); // list of enemies in the scene
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RemoveListObject();
    }
    // waits a period of time between enemy spawns using an IEnumerator
    private IEnumerator waitBetweenEnemies()
    {
        yield return null; // stops the program at this frame
    }
    private void AddEnemyToList()
    {
        
    }
    private void enemySelector()
    {
        int selectType = Random.Range(1,enemyList.Count);

    }
    private void RemoveListObject()
    {
        // checks over every enemy instance to be removed
        for(int i = 0; i < enemyList.Count; i++)
        {
            // checks if it should be removed from the list
            if(enemyList[i].GetComponent<EnemyBehaviour>().destroyThisInstance == true)
            {
                enemyList.Remove(enemyList[i]); // removes this enemy instance from the list
            }
        }
    }
}
