using UnityEngine;
using UnityEngine.UI;  // N�cessaire pour travailler avec l'UI dans Unity

public class GasScript : MonoBehaviour
{
    public float gasPercent = 1f; // Valeur initiale de gaz (100%)

    public Slider gasBar; // R�f�rence � l'UI Image qui repr�sente la barre de gaz

    private void Awake()
    {
        InvokeRepeating(nameof(Loose1PercentGas), 0.5f, 0.5f); // R�duire le gaz toutes les 0.5 secondes
    }

    private void Loose1PercentGas()
    {
        gasPercent -= 0.1f; // R�duit de 1% (0.01)

        if (gasPercent < 0f)
        {
            gasPercent = 0f; // Emp�cher le gaz de devenir n�gatif
        }
    }

    void Update()
    {
        gasBar.fillAmount = gasPercent;

        Debug.Log("Gas Percent: " + gasPercent);
    }
}
