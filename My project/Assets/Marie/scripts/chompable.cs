using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class chompable : MonoBehaviour
{
    public float size = 3;  
    private int chompsRemaining = 3; 

    private Vector3 originalScale; 

    void Start()
    {
        originalScale = transform.localScale; 
    }

    public void onChomp()
    {
        if (chompsRemaining > 0)
        {
            chompsRemaining--;  


            UpdateSize();

            if (chompsRemaining <= 0)
            {
                transform.localScale = originalScale;
                GetComponent<BreakableModel>()?.DetachChildrenAndAddRigidbody();
            }
        }
    }

    // Mettre à jour la taille du bonbon selon l'état (1 croc, 2 crocs, 3 crocs)
    private void UpdateSize()
    {
        float scaleFactor = 0f;

        if (chompsRemaining == 2)
        {
            scaleFactor = 0.7f;  
        }
        else if (chompsRemaining == 1)
        {
            scaleFactor = 0.5f; 
        }
        else if (chompsRemaining == 0)
        {
            scaleFactor = 0.2f;  
        }

        transform.localScale = originalScale * scaleFactor;
    }
}
