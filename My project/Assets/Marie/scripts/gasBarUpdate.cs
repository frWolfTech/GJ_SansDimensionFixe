using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gasBarUpdate : MonoBehaviour

{
    private Vector3 scale = Vector3.one;
    void Update()
    {
        scale.x = inventoryScript.instance.gasPercent;
        transform.localScale = scale;
    }
}
