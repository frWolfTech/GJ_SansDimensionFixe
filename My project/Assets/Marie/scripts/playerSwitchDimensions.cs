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

    void Awake()
    {
        if (car != null)
        {
            transform.position = car.transform.position;
            transform.rotation = car.transform.rotation;
        }

        Invoke(nameof(setTeleportPossible), 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && canTeleport)
        {
            TeleportToNextScene();
        }
        if (Input.GetKeyDown(KeyCode.H) && canTeleport)
        {
            TeleportToPreviousScene();
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
