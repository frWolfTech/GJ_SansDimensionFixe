using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : MonoBehaviour
{
    private GameObject toChompOn;  // L'objet actuellement � manger
    private bool canChomp = true;  // Pour emp�cher le chomping instantan�
    private int chompsRemaining = 3;  // Nombre de fois qu'il faut manger pour r�ussir

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

            // Si on a mang� 3 fois, on consid�re que l'objet est "mang�"
            if (chompsRemaining <= 0)
            {
                EatObject();  // Manger l'objet (par exemple, le d�truire ou accomplir une action)
            }

            // Emp�cher de chompter trop rapidement
            canChomp = false;
            Invoke(nameof(resetChomp), 2);  // R�initialiser apr�s 2 secondes
        }
    }

    // Fonction pour r�initialiser la capacit� de chomper
    private void resetChomp()
    {
        canChomp = true;
    }

    // Fonction appel�e lorsque l'objet est "compl�tement mang�"
    private void EatObject()
    {
        Debug.Log("Objet mang� !");
        // Ici tu peux effectuer une action, par exemple, d�truire l'objet
        Destroy(toChompOn);  // D�truire l'objet une fois qu'il est "mang�"
        chompsRemaining = 3;  // R�initialiser le compteur de chomps
    }
}
