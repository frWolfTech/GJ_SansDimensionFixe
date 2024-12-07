using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInventoryControl : MonoBehaviour
{
    public GameObject chomper;
    // Start is called before the first frame update
    void Start()
    {
        if (inventoryScript.instance.hasChomper)
        {
            setChomper();
        }
    }


    public void setChomper()
    {
        chomper.SetActive(true);
    }
}
