using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerSwitchDimensions : MonoBehaviour
{

    public string nextScene;
    public string previousScene;

    void Awake()
    {
        if(inventoryScript.instance != null)
        {
            transform.position = inventoryScript.instance.carPosition;
            transform.rotation = inventoryScript.instance.carRotation;
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            inventoryScript.instance.carPosition = transform.position;
            inventoryScript.instance.carRotation = transform.rotation;
            SceneManager.LoadScene(nextScene);
        };
        if (Input.GetKeyDown(KeyCode.H))
        {
            inventoryScript.instance.carPosition = transform.position;
            inventoryScript.instance.carRotation = transform.rotation;
            SceneManager.LoadScene(previousScene);
        };
    }
}
