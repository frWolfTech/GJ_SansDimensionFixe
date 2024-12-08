using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryScript : MonoBehaviour
{
    public static inventoryScript instance;

    public bool hasFragmentPaper;
    public bool hasFragmentPixel;
    public bool hasFragmentSugar;
    public bool hasFlameThrower;
    public bool hasEraser;
    public bool hasChomper;
    public Vector3 carPosition;
    public Quaternion carRotation;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    
}
