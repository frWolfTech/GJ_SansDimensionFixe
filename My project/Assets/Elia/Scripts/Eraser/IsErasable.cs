using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IsErasable : IsAlive
{
    [SerializeField]
    private MeshRenderer m_Renderer;

    public void Erase(float percentage)
    {
        m_Renderer.material.color = new Color(m_Renderer.material.color.r, m_Renderer.material.color.g, m_Renderer.material.color.b, m_Renderer.material.color.a - percentage);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Renderer.material.color.a <= 0)
        {
            gameObject.SetActive(false);
        }

            //Vector3 lookPos = camTransform.position;
            //lookPos.y = transform.position.y;
            //transform.LookAt(lookPos);

    }
}
