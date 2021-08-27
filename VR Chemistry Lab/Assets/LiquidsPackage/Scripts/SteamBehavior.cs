using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamBehavior : MonoBehaviour
{
    float TimeOfExitation;
    // Start is called before the first frame update
    void Start()
    {
        TimeOfExitation =0;
    }

    // Update is called once per frame
    void Update()
    {
        TimeOfExitation += Time.deltaTime;
        if(TimeOfExitation >= 3)
        {
            Destroy(gameObject);
        }
    }
}
