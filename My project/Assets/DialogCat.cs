using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCat : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject GUI;
    void Start()
    {
        catDialogScript co = GUI.GetComponent<catDialogScript>();

        co.showText("Salut, c'est l'urSAFF");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
