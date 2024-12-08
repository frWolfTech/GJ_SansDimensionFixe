using UnityEngine;
using UnityEngine.SceneManagement;

public class playerSwitchDimensions : MonoBehaviour
{
    [Header("Input Keys")]
    public string nextScene;
    public string previousScene;
    public float speed = 10f;
    private bool canTeleport = false;

    void Awake()
    {
        if (inventoryScript.instance != null)
        {
            transform.position = inventoryScript.instance.carPosition;
            transform.rotation = inventoryScript.instance.carRotation;
        }

        Invoke(nameof(setTeleportPossible), 1);
    }

    private void Update()
    {
        // Détection du clic gauche pour aller à la scène suivante
        if (Input.GetMouseButtonDown(0) && canTeleport) // 0 = Clic gauche
        {
            TeleportToNextScene();
        }


        if (Input.GetMouseButtonDown(1) && canTeleport) 
        {
            TeleportToPreviousScene();
        }
    }

    private void TeleportToNextScene()
    {
        Debug.Log("Téléportation vers la scène suivante");
        inventoryScript.instance.carPosition = transform.position;
        inventoryScript.instance.carRotation = transform.rotation;
        SceneManager.LoadScene(nextScene);
    }

    private void TeleportToPreviousScene()
    {
        Debug.Log("Téléportation vers la scène précédente");
        inventoryScript.instance.carPosition = transform.position;
        inventoryScript.instance.carRotation = transform.rotation;
        SceneManager.LoadScene(previousScene);
    }

    private void setTeleportPossible()
    {
        canTeleport = true;
    }
}
