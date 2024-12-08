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

    public float gasPercent;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        Invoke(nameof(loose1percentGas),0.5f);
    }

    private void loose1percentGas()
    {
        gasPercent -= 0.01f;
        if(gasPercent > 0.01)
        {
            Invoke(nameof(loose1percentGas), 0.5f);
        }
    }


}
