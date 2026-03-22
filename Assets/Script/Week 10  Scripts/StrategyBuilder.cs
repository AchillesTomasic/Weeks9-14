using UnityEngine;
using UnityEngine.InputSystem;

public class StrategyBuilder : MonoBehaviour
{
    private int rightClick;
    private Vector2 mousePos;
    public GameObject BuildingPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Mouse.current.position.ReadValue();
    }
    public void SpawnBuilding(InputAction.CallbackContext context){
        if(context.ReadValue<float>() == 1){
        spawnBuildingObj();
        }
    }
    /*
    public void mousePosition(InputAction.CallbackContext context){
        mousePos = context.ReadValue<Vector2>();
        
    }
    */
    private void spawnBuildingObj(){
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0;
        GameObject buildingObj = Instantiate(BuildingPrefab,worldPos,Quaternion.identity);
    }
}
