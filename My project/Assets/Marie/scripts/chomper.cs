using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chomper : MonoBehaviour
{
    private GameObject toChompOn;
    private bool canChomp = true;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<chompable>(out chompable chomp))
        {
            toChompOn = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<chompable>(out chompable chomp))
        {
            toChompOn = null;
        }
    }

    private void Update()
    {
        if (toChompOn != null && canChomp) {
            toChompOn.GetComponent<chompable>().onChomp();
            canChomp = false;
            Invoke(nameof(resetChomp),2);
        }
    }
    private void resetChomp()
    {
        canChomp = true;
    }

}
