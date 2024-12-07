using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeAssetsScript : MonoBehaviour
{
    public Transform camTransform;

    void Update()
    {
        Vector3 lookPos = camTransform.position;
        lookPos.y = transform.position.y;
        transform.LookAt(lookPos);
    }
}
