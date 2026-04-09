using UnityEngine;
using TMPro; 
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI highscore; // sets the visible highscore of the game
    public bool SettingsUIActive; // sets if the UI is active or not
    public Transform StopCoroutineBufferButton; // stops the coroutine buffer in the collision
    public Transform StopSpawnButton; // stops spawning of enemies
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowOptions();// activates the show options pannel
    }
    public void UIactiveState(){
        SettingsUIActive = !SettingsUIActive;// swaps the state of the menu
    }
    private void ShowOptions()
    {
        if (SettingsUIActive)
        {
            StopCoroutineBufferButton.position = new Vector3(transform.position.x + 60,StopCoroutineBufferButton.position.y,0);// moves the button on screen
            StopSpawnButton.position = new Vector3(transform.position.x + 120,StopCoroutineBufferButton.position.y,0);// moves the button on screen
        }
        else
        {
            StopCoroutineBufferButton.position = new Vector3(transform.position.x - 1000,StopCoroutineBufferButton.position.y,0);// moves the button off screen
            StopSpawnButton.position = new Vector3(transform.position.x - 1000,StopCoroutineBufferButton.position.y,0);// moves the button off screen
        }
    }
}
