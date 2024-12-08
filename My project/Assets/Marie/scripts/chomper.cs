using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : MonoBehaviour
{
    private GameObject toChompOn;  
    private bool canChomp = true; 
    private int chompsRemaining = 3; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Eatable"))
        {
            toChompOn = other.gameObject; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Eatable"))
        {
            toChompOn = null;
        }
    }

    private void Update()
    {
        if (toChompOn != null && canChomp)
        {
            chompsRemaining--;
            Debug.Log("Chomps restants : " + chompsRemaining);

            toChompOn.GetComponent<chompable>().onChomp();

            if (chompsRemaining <= 0)
            {
                EatObject();  
            }


            canChomp = false;
            Invoke(nameof(resetChomp), 2);  
        }
    }


    private void resetChomp()
    {
        canChomp = true;
    }


    private void EatObject()
    {
        Debug.Log("Objet mangé !");
        chompsRemaining = 3; 
    }
}
