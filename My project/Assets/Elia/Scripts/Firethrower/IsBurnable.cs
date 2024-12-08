using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.VFX;

public class IsBurnable : IsAlive
{
    public bool IsBurning { get; set; }

    private float BurningTime = 0f;

    private float minTimeToDamage;
    private float DamagesPerTicks;
    private float BurnDuration;

    public SkinnedMeshRenderer _skinnedMesh;

    public MeshRenderer _mesh;
    public VisualEffect VFXGraph;

    public float _dissolveRate = 0.0125f;
    public float _refreshRate = 0.025f;

    private Material[] _materials;

    public void Start()
    {
        if (_skinnedMesh != null)
            _materials = _skinnedMesh.sharedMaterials;

        else if (_mesh != null)
            _materials = _mesh.sharedMaterials;
    }
    public void StartBurning(float _Damages, float _BurnDuration)
    {
        IsBurning = true;
        BurnDuration = _BurnDuration;
        DamagesPerTicks = _Damages;
        TakeDamage(DamagesPerTicks);
        StartCoroutine(DissolveCo());
    }

    public void StopBurning()
    {
        IsBurning = false; 
    }

    private void Burn()
    {
        BurningTime += Time.deltaTime;
        TakeDamage(DamagesPerTicks);
    }

    private void Update()
    {
        if (IsDead) StopBurning();

        if (IsBurning)
            Burn();
    }

    IEnumerator DissolveCo()
    {
        if (VFXGraph != null)
        {
            VFXGraph.Play();
        }

        float counter = 0;
        _materials[2].SetFloat("_DissolveAmount", 1.2f);
        while (_materials[0].GetFloat("_DissolveAmount") < 1.1f)
        {
            counter += _dissolveRate;
            for (int i = 0; i < _materials.Length - 1; i++)
            {
                _materials[i].SetFloat("_DissolveAmount", counter);
            }
            yield return new WaitForSeconds(_refreshRate);
        }
    }
}
