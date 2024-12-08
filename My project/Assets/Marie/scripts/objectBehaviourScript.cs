using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum ObjectType
{
    FragmentPaper,
    FragmentSugar,
    FragmentPixel,
    Chomper,
    Eraser,
    FlameThrower
}


public class objectBehaviourScript : MonoBehaviour
{
    public ObjectType objectBool;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (objectBool)
            {
                case ObjectType.FragmentPaper:
                    inventoryScript.instance.hasFragmentPaper = true;
                    
                    break;
                case ObjectType.FragmentSugar:
                    inventoryScript.instance.hasFragmentSugar = true;
                    break;
                case ObjectType.FragmentPixel:
                    inventoryScript.instance.hasFragmentPixel = true;
                    break;
                case ObjectType.Chomper:
                    inventoryScript.instance.hasChomper = true;
                    other.gameObject.GetComponent<playerInventoryControl>().setChomper();
                    break;
                case ObjectType.Eraser:
                    inventoryScript.instance.hasEraser = true;
                    break;
                case ObjectType.FlameThrower:
                    inventoryScript.instance.hasFlameThrower = true;
                    break;

            }
            Destroy(gameObject);
        }
    }
}
