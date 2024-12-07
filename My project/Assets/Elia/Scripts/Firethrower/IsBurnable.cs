using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Rendering;

public class IsBurnable : IsAlive
{
    public bool IsBurning { get; set; }

    private float BurningTime = 0f;

    private float minTimeToDamage;
    private float DamagesPerTicks;
    private float BurnDuration;

    public void StartBurning(float _Damages, float _BurnDuration)
    {
        IsBurning = true;
        BurnDuration = _BurnDuration;
        DamagesPerTicks = _Damages;
        TakeDamage(DamagesPerTicks);
    }

    public void StopBurning()
    {
        IsBurning = false; 
    }

    private void Burn()
    {
        BurningTime += Time.deltaTime;
        TakeDamage(DamagesPerTicks);

        if (BurningTime >= BurnDuration)
        {
            StopBurning();
        }
    }

    private void Update()
    {
        if (IsDead) StopBurning();

        if (IsBurning)
            Burn();
    }
}
