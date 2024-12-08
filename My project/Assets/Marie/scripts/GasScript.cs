using UnityEngine;
using UnityEngine.UI;  // Nécessaire pour travailler avec l'UI dans Unity

public class GasScript : MonoBehaviour
{
    public float gasPercent = 1f; // Valeur initiale de gaz (100%)

    public Slider gasBar; // Référence à l'UI Image qui représente la barre de gaz

    private void Awake()
    {
        InvokeRepeating(nameof(Loose1PercentGas), 0.5f, 0.5f); // Réduire le gaz toutes les 0.5 secondes
    }

    private void Loose1PercentGas()
    {
        gasPercent -= 0.1f; // Réduit de 1% (0.01)

        if (gasPercent < 0f)
        {
            gasPercent = 0f; // Empêcher le gaz de devenir négatif
        }
    }

    void Update()
    {
        gasBar.fillAmount = gasPercent;

        Debug.Log("Gas Percent: " + gasPercent);
    }
}
