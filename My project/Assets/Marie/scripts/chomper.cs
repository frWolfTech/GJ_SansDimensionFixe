using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : MonoBehaviour
{
    private GameObject toChompOn;  // L'objet actuellement à manger
    private bool canChomp = true;  // Pour empêcher le chomping instantané
    private int chompsRemaining = 3;  // Nombre de fois qu'il faut manger pour réussir

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

            // Si on a mangé 3 fois, on considère que l'objet est "mangé"
            if (chompsRemaining <= 0)
            {
                EatObject();  // Manger l'objet (par exemple, le détruire ou accomplir une action)
            }

            // Empêcher de chompter trop rapidement
            canChomp = false;
            Invoke(nameof(resetChomp), 2);  // Réinitialiser après 2 secondes
        }
    }

    // Fonction pour réinitialiser la capacité de chomper
    private void resetChomp()
    {
        canChomp = true;
    }

    // Fonction appelée lorsque l'objet est "complètement mangé"
    private void EatObject()
    {
        Debug.Log("Objet mangé !");
        // Ici tu peux effectuer une action, par exemple, détruire l'objet
        Destroy(toChompOn);  // Détruire l'objet une fois qu'il est "mangé"
        chompsRemaining = 3;  // Réinitialiser le compteur de chomps
    }
}
