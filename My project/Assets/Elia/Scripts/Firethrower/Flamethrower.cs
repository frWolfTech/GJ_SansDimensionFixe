using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem Fire;
    [SerializeField]
    private ParticleSystem Fire1;
    [SerializeField]
    private ParticleSystem Fire2;
    [SerializeField]
    private ParticleSystem Fire3;

    private float BurningDamage = 0.5f;

    private float BurnDuration = 10f;

    private List<PaperObjects> BurnableObjectInRadius = new List<PaperObjects>();
    private List<int> ObjectsToRemove = new List<int>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Burnable")
        {
            BurnableObjectInRadius.Add(other.gameObject.GetComponent<PaperObjects>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Burnable")
        {
            BurnableObjectInRadius.Remove(other.gameObject.GetComponent<PaperObjects>());
        }
    }

    private void PutEnemyOnFire()
    {
        for (int i = 0; i < BurnableObjectInRadius.Count; i++)
        {
            Debug.Log(i);
            BurnableObjectInRadius[i].StartBurning(BurningDamage, BurnDuration);
        }
    }
    private void Shoot()
    {
        PutEnemyOnFire();
        Fire.Play();
        Fire1.Play();
        Fire2.Play();
        Fire3.Play();
        
    }

    private void StopShooting()
    {
        Fire.Stop();
        Fire1.Stop();
        Fire2.Stop();
        Fire3.Stop();
    }
    private void Start()
    {
        Fire.Stop();
        Fire1.Stop();
        Fire2.Stop();
        Fire3.Stop();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
        if (Input.GetKeyUp(KeyCode.F)) 
        {
            StopShooting();
        }
        for (int i = 0;i < BurnableObjectInRadius.Count; i++)
        {
            if (BurnableObjectInRadius[i].IsDead)
            {
                ObjectsToRemove.Add(i);
            }
        }

        for (int i = 0; i < ObjectsToRemove.Count; i++)
        {
            BurnableObjectInRadius.Remove(BurnableObjectInRadius[ObjectsToRemove[i]]);
        }

        ObjectsToRemove.Clear();
    }

}
