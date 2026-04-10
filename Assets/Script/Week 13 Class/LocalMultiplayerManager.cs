using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class LocalMultiplayerManager : MonoBehaviour
{
    public List<Sprite> possiblePlayerVisuals;
    public List<PlayerInput> existingPlayers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPlayerJoined(PlayerInput newPlayer)
    {
        //Assign Visuals To This Player
        SpriteRenderer newPlayerRenderer = newPlayer.GetComponent<SpriteRenderer>();
        newPlayerRenderer.sprite = possiblePlayerVisuals[existingPlayers.Count];

        existingPlayers.Add(newPlayer);

        LocalMultiplayer playerScript = newPlayer.GetComponent<LocalMultiplayer>();
        playerScript.manager = this;
    }

    public void TryAttack(PlayerInput attackingPlayer)
    {
        Debug.Log("Attack");
        /*
        for (int i = 0; i < existingPlayers.Count; i++)
        {
            if (attackingPlayer == existingPlayers[i]) 
            {
                continue; // go to the next itteration of the loop, skip all code
            }
            Vector3 attackingPlayerPosition = attackingPlayer.transform.position;
            Vector3 existingPlayerPostion = existingPlayers[i].transform.position;
            float distanceToPlayer = Vector3.Distance(attackingPlayerPosition,existingPlayerPostion);

            if (distanceToPlayer < 1.5f) 
            {
                Debug.Log("Attack" );
            }
        }
        */
    }
}
