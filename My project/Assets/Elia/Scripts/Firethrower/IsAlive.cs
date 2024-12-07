using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAlive : MonoBehaviour
{
    [SerializeField]
    private float Health;
    public bool IsDead;


    public void TakeDamage(float Damage)
    {
        Debug.Log(Health);
        Health -= Damage;

        if (Health <= 0)
        {
            Health = 0;
            IsDead = true;
        }
    }
}
