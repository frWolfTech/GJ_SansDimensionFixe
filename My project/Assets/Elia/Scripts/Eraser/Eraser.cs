using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{

    private List<IsErasable> ErasableInRange = new List<IsErasable>();
    private List<int> ObjectsToRemove = new List<int>();
    [SerializeField]
    private Animator m_Animator;

    private float m_eraseStrenght = 0.002f;

    private float m_erasingTime = 0f;
    private float m_erasingDuration = 1f;
    private bool m_isErasing = false;


    // Start is called before the first frame update
    void Start()
    {
    }


    private void Erase()
    {
        m_erasingTime += Time.deltaTime;
        for (int i = 0; i < ErasableInRange.Count; i++)
        {
            ErasableInRange[i].Erase(m_eraseStrenght/m_erasingDuration);
        }
        if (m_erasingTime >= m_erasingDuration)
        {
            m_isErasing = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Erasable")
        {
            ErasableInRange.Add(other.gameObject.GetComponent<IsErasable>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Erasable")
        {
            ErasableInRange.Remove(other.gameObject.GetComponent<IsErasable>());
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (m_isErasing == false) m_erasingTime = 0f;
            m_isErasing = true;
        }

        if (m_isErasing)
        {
            Erase();
        }

        for (int i = 0; i < ErasableInRange.Count; i++)
        {
            if (ErasableInRange[i].IsDead)
            {
                ObjectsToRemove.Add(i);
            }
        }

        for (int i = 0; i < ObjectsToRemove.Count; i++)
        {
            ErasableInRange.Remove(ErasableInRange[ObjectsToRemove[i]]);
        }

        ObjectsToRemove.Clear();

        m_Animator.SetBool("IsErasing", m_isErasing);
    }
}
