using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempMovement : MonoBehaviour
{
    private float xAxis;
    private float yAxis;

    public float speed = 1;
    void Update()
    {
        xAxis = 0;
        yAxis = 0;
        if (Input.GetKey(KeyCode.W)) {
            xAxis += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            xAxis -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            yAxis -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            yAxis += 1;
        }
        transform.position += transform.forward * xAxis * Time.deltaTime * speed;
        transform.Rotate(0, yAxis*Time.deltaTime*120, 0);
    }
}
