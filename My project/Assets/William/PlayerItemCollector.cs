using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerItemCollector : MonoBehaviour
{
    public static PlayerItemCollector Instance;

    public float collectTime = 2f; // Temps nécessaire pour collecter un objet
    private float collectProgress = 0f; // Progression actuelle
    public KeyCode collectKey = KeyCode.E; // Touche pour collecter
    public TMP_Text progressText; // Texte pour afficher le pourcentage

    private bool isCollecting = false; // La collecte est en cours
    private GameObject currentItem; // L'objet actuellement collecté

    public GameObject power1, power2, power3;

    void Start()
    {
        Debug.Log("=== État du SingletonGlobal ===");

        Debug.Log($"hasChomper: {SingletonGlobal.Instance.hasChomper}");
        Debug.Log($"hasFlameThrower: {SingletonGlobal.Instance.hasFlameThrower}");
        Debug.Log($"hasEraser: {SingletonGlobal.Instance.hasEraser}");

        Debug.Log("==============================");
    }

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        // Gestion de la collecte
        if (currentItem != null && Input.GetKey(collectKey))
        {
            if (!isCollecting)
            {
                isCollecting = true;
                collectProgress = 0f;
            }

            // Avancer la progression
            collectProgress += Time.deltaTime / collectTime;

            if (progressText)
                progressText.text = $"{Mathf.Clamp(collectProgress * 100f, 0f, 100f):0}%"; // Afficher le pourcentage

            // Si la collecte est terminée
            if (collectProgress >= 1f)
                CollectItem();
        }
        else if (!Input.GetKey(collectKey) && isCollecting)
        {
            ResetProgress();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item") || other.CompareTag("Gasoline")) // Combine les deux tags
        {
            currentItem = other.gameObject; // Sauvegarder l'objet en interaction
            if (progressText)
            {
                progressText.gameObject.SetActive(true); // Afficher le texte
                progressText.text = ""; // Réinitialiser le texte
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item") || other.CompareTag("Gasoline"))
        {
            currentItem = null; // Réinitialiser l'objet en interaction
            ResetProgress();
            if (progressText)
                progressText.gameObject.SetActive(false); // Masquer le texte
        }
    }

    private void CollectItem()
    {
        if (currentItem.CompareTag("Gasoline"))
        {
            GasScript gasScript = GetComponent<GasScript>();
            gasScript.FillGaz();

        }
        else if (currentItem.CompareTag("Item"))
        {
            if (currentItem.name == "Dentier")
            {
                SingletonGlobal.Instance.hasChomper = true; // Rendre persistant
                power1.SetActive(true);
            }
            if (currentItem.name == "LanceFlamme")
            {
                SingletonGlobal.Instance.hasFlameThrower = true; // Rendre persistant
                power3.SetActive(true);
            }
            if (currentItem.name == "Gomme")
            {
                SingletonGlobal.Instance.hasEraser = true; // Rendre persistant
                power2.SetActive(true);
            }
            Debug.Log("Other item collected.");
        }

        Destroy(currentItem); 
        ResetProgress();
    }

    private void ResetProgress()
    {
        isCollecting = false;
        collectProgress = 0f;
        if (progressText)
            progressText.text = "0%";
    }
}
