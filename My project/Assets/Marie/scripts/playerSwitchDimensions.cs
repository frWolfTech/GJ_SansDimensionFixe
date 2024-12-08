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
    public bool hasFragmentPaper = false;
    public bool hasFragmentPixel = false;
    public bool hasFragmentSugar = false;
    public bool hasFlameThrower = false;
    public bool hasEraser = false;
    public bool hasChomper = false;

    public GameObject car;
    public GameObject distorsion;

    void Awake()
    {
        if (car != null)
        {
            transform.position = car.transform.position;
            transform.rotation = car.transform.rotation;
        }

        Invoke(nameof(setTeleportPossible), 2); // Débloquer la téléportation après 2 secondes
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && canTeleport)
        {
            StartTeleportation(nextScene);
        }
        if (Input.GetKeyDown(KeyCode.H) && canTeleport)
        {
            StartTeleportation(previousScene);
        }
    }

    private void StartTeleportation(string sceneName)
    {
        distorsion.SetActive(true); // Activer la distorsion
        Debug.Log("Activation de la distorsion. Changement de scène imminent.");

        if (car != null)
        {
            car.transform.position = transform.position;
            car.transform.rotation = transform.rotation;
        }

        StartCoroutine(ChangeSceneAfterDelay(sceneName, 2f)); // Utiliser une coroutine pour gérer le délai
    }

    private System.Collections.IEnumerator ChangeSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay); // Attendre le délai spécifié
        Debug.Log($"Téléportation vers la scène : {sceneName}");
        SceneManager.LoadScene(sceneName); // Charger la scène cible
    }

    private void setTeleportPossible()
    {
        canTeleport = true; // Autoriser la téléportation après un délai
    }
}
