using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryScript : MonoBehaviour
{
    public static inventoryScript instance;

    [SerializeField] bool hasFragmentPaper;
    [SerializeField] bool hasFragmentPixel;
    [SerializeField] bool hasFragmentSugar;
    [SerializeField] bool hasFlameThrower;
    [SerializeField] bool hasEraser;
    [SerializeField] bool hasChomper;
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
