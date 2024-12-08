using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerItemCollector : MonoBehaviour
{
    public float collectTime = 2f; // Temps nécessaire pour collecter un objet
    private float collectProgress = 0f; // Progression actuelle
    public KeyCode collectKey = KeyCode.E; // Touche pour collecter
    public Slider progressBar; // Barre de progression
    public TMP_Text progressText; // Texte pour afficher le pourcentage

    private bool isCollecting = false; // La collecte est en cours
    private GameObject currentItem; // L'objet actuellement collecté

    void Update()
    {
        // Gestion de la collecte
        if (currentItem != null && Input.GetKey(collectKey))
        {
            if (!isCollecting)
            {
                isCollecting = true;
                collectProgress = 0f; // Réinitialiser la progression
            }

            // Avancer la progression
            collectProgress += Time.deltaTime / collectTime;
            if (progressBar)
                progressBar.value = collectProgress;

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
        if (other.CompareTag("Item"))
        {
            currentItem = other.gameObject; // Sauvegarder l'objet en interaction
            if (progressBar)
            {
                progressBar.gameObject.SetActive(true); // Afficher la barre
                progressBar.value = 0f; // Réinitialiser visuellement
            }
            if (progressText)
            {
                progressText.gameObject.SetActive(true); // Afficher le texte
                progressText.text = ""; // Réinitialiser le texte
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            currentItem = null; // Réinitialiser l'objet en interaction
            ResetProgress();
            if (progressBar)
                progressBar.gameObject.SetActive(false); // Masquer la barre
            if (progressText)
                progressText.gameObject.SetActive(false); // Masquer le texte
        }
    }

    private void CollectItem()
    {
        Debug.Log($"Item collected: {currentItem.name}");
        Destroy(currentItem); // Détruire l'objet collecté
        ResetProgress();
    }

    private void ResetProgress()
    {
        isCollecting = false;
        collectProgress = 0f;
        if (progressBar)
            progressBar.value = 0f;
        if (progressText)
            progressText.text = "0%";
    }
}
