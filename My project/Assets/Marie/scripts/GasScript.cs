using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasScript : MonoBehaviour
{
    public float gasPercent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gasBar.fillAmount = gasPercent;

        Debug.Log("Gas Percent: " + gasPercent);
    }
}
