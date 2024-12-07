using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeAssetsScript : MonoBehaviour
{
    public Transform camTransform;

    void Update()
    {
        transform.LookAt(camTransform.position);
    }
}
