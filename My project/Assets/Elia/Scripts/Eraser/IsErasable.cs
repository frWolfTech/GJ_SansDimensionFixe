using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsErasable : IsAlive
{
    [SerializeField]
    private MeshRenderer m_Renderer;

    public void Erase(float percentage)
    {
        m_Renderer.material.color = new Color(m_Renderer.material.color.r, m_Renderer.material.color.g, m_Renderer.material.color.b, m_Renderer.material.color.a - percentage);
        Debug.Log(m_Renderer.material.color.a);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Renderer.material.color.a == 0)
        {
            IsDead = true;
        }
    }
}