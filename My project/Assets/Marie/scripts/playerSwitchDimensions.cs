using UnityEngine;
using UnityEngine.SceneManagement;

public class playerSwitchDimensions : MonoBehaviour
{
    [Header("Input Keys")]
    public string nextScene;
    public string previousScene;
    public float speed = 10f;
    private bool canTeleport = false;

    // Inventaire
    public bool hasFragmentPaper;
    public bool hasFragmentPixel;
    public bool hasFragmentSugar;
    public bool hasFlameThrower;
    public bool hasEraser;
    public bool hasChomper;

    public GameObject car;
    public GameObject GUI;


    void Awake()
    {
        if (inventoryScript.instance != null)
        {
            transform.position = inventoryScript.instance.carPosition;
            transform.rotation = inventoryScript.instance.carRotation;
        }
        Cursor.lockState = CursorLockMode.Locked;
        Invoke(nameof(setTeleportPossible), 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && canTeleport)
        {
            GUI.GetComponent<catDialogScript>().showText("Teleporting...");
            Invoke(nameof(TeleportToNextScene), 2);
        }
        if (Input.GetKeyDown(KeyCode.H) && canTeleport)
        {
            GUI.GetComponent<catDialogScript>().showText("Teleporting...");
            Invoke(nameof(TeleportToPreviousScene), 2);
        }
    }

    private void TeleportToNextScene()
    {
        Debug.Log("Téléportation vers la scène suivante");

        if (car != null)
        {
            car.transform.position = transform.position;
            car.transform.rotation = transform.rotation;
        }

        SceneManager.LoadScene(nextScene);
    }

    private void TeleportToPreviousScene()
    {
        Debug.Log("Téléportation vers la scène précédente");

        if (car != null)
        {
            car.transform.position = transform.position;
            car.transform.rotation = transform.rotation;
        }

        SceneManager.LoadScene(previousScene);
    }

    private void setTeleportPossible()
    {
        canTeleport = true;
    }
}
