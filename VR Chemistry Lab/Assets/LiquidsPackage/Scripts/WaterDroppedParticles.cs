using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDroppedParticles : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    float currtime;
    void Start()
    {
        currtime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currtime += Time.deltaTime;
        if(currtime >= time)
        {
            Destroy(gameObject);
        }
    }
}
