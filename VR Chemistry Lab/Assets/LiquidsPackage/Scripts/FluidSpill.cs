using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FluidSpill : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Prefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        Instantiate(Prefab, other.transform.position, Quaternion.identity);
        //Debug.Log("anything");
    }
}
