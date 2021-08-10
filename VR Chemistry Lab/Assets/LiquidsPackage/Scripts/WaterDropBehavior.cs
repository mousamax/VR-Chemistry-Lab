using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropBehavior : MonoBehaviour
{

    float FillValue;
    public GameObject prefabImage;
    public GameObject ParticleSystem;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Fluid")
        {
            collision.gameObject.GetComponent<LiquidBehavior>().FillLiquidContainer(FillValue);
        }
        else if(collision.gameObject.tag == "Land")
        {
            Vector3 pos = new Vector3(transform.position.x, collision.gameObject.transform.position.y + 0.1f, transform.position.z);
            GameObject NewImage = Instantiate(prefabImage);
            NewImage.transform.position = pos;
            GameObject NewParticle = Instantiate(ParticleSystem);
            ParticleSystem.transform.position = pos;
        }
        Destroy(gameObject);
    }

    public void SetFill(float fill)
    {
        FillValue = fill;
    }
}
