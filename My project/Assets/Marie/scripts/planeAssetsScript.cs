using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeAssetsScript : MonoBehaviour
{
    [SerializeField]
    private CinemachineFreeLook camTransform;

    void Update()
    {
        Vector3 lookPos = camTransform.transform.position;
        lookPos.y = transform.position.y;
        transform.LookAt(lookPos);
    }
}
