using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DissolveController : MonoBehaviour
{
    public SkinnedMeshRenderer _skinnedMesh;
    public MeshRenderer _mesh;
    public VisualEffect VFXGraph;

    public float _dissolveRate = 0.0125f;
    public float _refreshRate = 0.025f;

    private Material[] _materials;

    // Start is called before the first frame update
    void Start()
    {
        if( _skinnedMesh != null )
            _materials = _skinnedMesh.materials;

        else if ( _mesh != null )
            _materials = _mesh.materials;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(DissolveCo());
        }

    }

    IEnumerator DissolveCo ()
    {
        if(VFXGraph != null)
        {
            VFXGraph.Play();
        }

        float counter = 0;
        while (_materials[0].GetFloat("_DissolveAmount") < 1)
        {
            counter += _dissolveRate;
            for (int i = 0; i < _materials.Length; i++)
            {
                _materials[i].SetFloat("_DissolveAmount", counter);
            }
            yield return new WaitForSeconds(_refreshRate);
        }
    }
}