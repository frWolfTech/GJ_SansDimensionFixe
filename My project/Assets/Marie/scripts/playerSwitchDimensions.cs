using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class playerSwitchDimensions : MonoBehaviour
{

    [Header("Input Action References")]
    [SerializeField] InputActionReference moving;

    [SerializeField] InputActionReference goToNextScene;
    [SerializeField] InputActionReference goToPreviousScene;
    [SerializeField] InputActionReference ability;


    public string nextScene;
    public string previousScene;
    public float speed = 10;
    private bool canTeleport = false;

    void Awake()
    {
        if(inventoryScript.instance != null)
        {
            transform.position = inventoryScript.instance.carPosition;
            transform.rotation = inventoryScript.instance.carRotation;
        }
        goToNextScene.action.performed += goNext;
        goToPreviousScene.action.performed += goPrevious;
        ability.action.performed += useActiveAbility;
        Invoke(nameof(setTeleportPossible), 5);
    }


    private void Update()
    {
        Vector2 direction = moving.action.ReadValue<Vector2>();
        transform.position += transform.forward * direction.y * Time.deltaTime * speed;
        transform.Rotate(0, direction.x * Time.deltaTime * 120, 0);
        Cursor.lockState = CursorLockMode.Locked;
       
    }

    private void goNext(InputAction.CallbackContext obj)
    {
        if (canTeleport) { 
            inventoryScript.instance.carPosition = transform.position;
            inventoryScript.instance.carRotation = transform.rotation;
            goToNextScene.action.performed -= goNext;
            goToPreviousScene.action.performed -= goPrevious;
            ability.action.performed -= useActiveAbility;
            SceneManager.LoadScene(nextScene);
        }
    }
    private void goPrevious(InputAction.CallbackContext obj)
    {
        if (canTeleport)
        {
            inventoryScript.instance.carPosition = transform.position;
            inventoryScript.instance.carRotation = transform.rotation;
            goToNextScene.action.performed -= goNext;
            goToPreviousScene.action.performed -= goPrevious;
            ability.action.performed -= useActiveAbility;
            SceneManager.LoadScene(previousScene);
        }
    }
    private void useActiveAbility(InputAction.CallbackContext obj)
    {

    }
    private void setTeleportPossible()
    {
        canTeleport = true;
    }
}
