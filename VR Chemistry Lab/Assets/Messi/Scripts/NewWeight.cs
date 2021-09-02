using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWeight : MonoBehaviour
{
    public TextMesh weight;
    bool IsDoorClosed;
    float totalMass;

    // Update is called once per frame
    void Update()
    {
        GameObject gameObject = GameObject.Find("ScaleBody");
        ScaleClosure scaleClosure = gameObject.GetComponent<ScaleClosure>();
        IsDoorClosed= scaleClosure.isClosed;
        if (IsDoorClosed == true)
        {
            weight.text = totalMass.ToString("##.###" + " g");
            weight.color = Color.blue;
        }
        else
        {
            weight.text = "00.000 g" ;
            weight.color = Color.grey;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        float currentMass = collider.GetComponent<Rigidbody>().mass;
        totalMass += currentMass;
    
    }
    private void OnTriggerExit(Collider collider)
    {
        float currentMass = collider.GetComponent<Rigidbody>().mass;
        totalMass -= currentMass;
    }
}

   
/*
public class Weight : MonoBehaviour
{
    
    float oldWeight, newweight, colidedweight;
    int colided;

    private void Start()
    {
        oldWeight = newweight = colided = 0;
    }

    private void Update()
    {
        if (colided == 0)
            newweight = 0;

        weight.text = newweight.ToString("#.###");

        oldWeight = newweight;
    }

    private void OnCollisionEnter(Collision collision)
    {
        colidedweight = collision.rigidbody.mass;
        newweight = oldWeight + colidedweight;
        colided++;
    }

    private void OnCollisionExit(Collision collision)
    {
        colidedweight = collision.rigidbody.mass;
        newweight = oldWeight - colidedweight;
        colided--;
    }

}

}*/
