using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDestructor : MonoBehaviour
{
    float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time>= 1.5f)
        {
            Destroy(gameObject);
        }
    }
}
