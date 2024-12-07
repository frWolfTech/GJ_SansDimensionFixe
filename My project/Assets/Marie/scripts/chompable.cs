using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chompable : MonoBehaviour
{
    public float size = 3;

    public void onChomp()
    {

        transform.localScale -= Vector3.one * 0.2f;
        size -= 1;
        sendParticles();
        if(size <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void sendParticles()
    {

    }
}
