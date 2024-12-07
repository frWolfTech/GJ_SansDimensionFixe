using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gameScriptControl : MonoBehaviour
{
    public GameObject textBit;
    public TextMeshProUGUI catText;
    public string currentStringDisplayed;


    private void Awake()
    {
        catText = textBit.GetComponent<TextMeshProUGUI>();
        currentStringDisplayed = "STUPID CAT";
        catText.SetText(currentStringDisplayed);
    }

    private void StopText()
    {
        catText.SetText("...");
    }

    public void getGameText(string text)
    {
        catText.SetText(text);
    }

}
