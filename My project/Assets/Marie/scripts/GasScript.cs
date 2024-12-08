using UnityEngine;
using UnityEngine.UI;

public class GasScript : MonoBehaviour
{
    private float curGasPercent = 1f; 

    public Slider gasBar; 

    private void Awake()
    {
        InvokeRepeating(nameof(Loose1PercentGas), 0.5f, 0.5f); // Réduire le gaz toutes les 0.5 secondes
    }

    private void Loose1PercentGas()
    {
        curGasPercent -= 0.1f; 
    }

    void Update()
    {
        gasBar.value = curGasPercent;

        Debug.Log("Gas Percent: " + curGasPercent);
    }

    public void FillGaz()
    {
        Debug.Log("Gasoline collected!");
        curGasPercent = 1f;
    }
}
