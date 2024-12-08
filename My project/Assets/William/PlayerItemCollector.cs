using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerItemCollector : MonoBehaviour
{
    public float collectTime = 2f; // Temps n�cessaire pour collecter un objet
    private float collectProgress = 0f; // Progression actuelle
    public KeyCode collectKey = KeyCode.E; // Touche pour collecter
    public TMP_Text progressText; // Texte pour afficher le pourcentage

    private bool isCollecting = false; // La collecte est en cours
    private GameObject currentItem; // L'objet actuellement collect�

    public GameObject power1, power2, power3;

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

            // Si la collecte est termin�e
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
                progressText.text = ""; // R�initialiser le texte
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item") || other.CompareTag("Gasoline"))
        {
            currentItem = null; // R�initialiser l'objet en interaction
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
                playerSwitchDimensions switchDim = GetComponent<playerSwitchDimensions>();
                switchDim.hasChomper = true;
                power1.SetActive(true);


            }
            Debug.Log("Other item collected.");
        }

        Destroy(currentItem); // D�truire l'objet collect�
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
