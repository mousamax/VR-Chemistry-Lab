using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodiumDetectorBehaviour : MonoBehaviour
{
    public GameObject LiquidContainer;
    public GameObject steam;

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
        if(LiquidContainer.GetComponent<LiquidBehavior>().DetectSodium())
        {
            GameObject ThisSteam = Instantiate(steam, transform.position, Quaternion.EulerAngles(new Vector3(90f,0,0)));
            ThisSteam.transform.parent = gameObject.transform;
            ThisSteam.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            Destroy(collision.gameObject);
        }
    }

}
