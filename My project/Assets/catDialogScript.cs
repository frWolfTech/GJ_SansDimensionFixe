using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class catDialogScript : MonoBehaviour
{
    public GameObject catImage;
    public GameObject catText;

    private void Start()
    {
        deactivateText();
    }
    public void showText(string text)
    {
        catImage.SetActive(true);
        catText.SetActive(true);
        TextMeshProUGUI displayText = catText.GetComponent<TextMeshProUGUI>();
        displayText.SetText(text);

        Invoke(nameof(deactivateText), 5);
    }

    private void deactivateText()
    {
        catImage.SetActive(false);
        catText.SetActive(false);
    }

}
