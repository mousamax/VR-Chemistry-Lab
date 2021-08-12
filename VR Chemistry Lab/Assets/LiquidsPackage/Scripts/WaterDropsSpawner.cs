using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropsSpawner : MonoBehaviour
{

    public GameObject LiquidDropsPrefab;
    public float time = 0.1f;
    float currtime;
    bool Drop = false;
    float FillValue;

    // Start is called before the first frame update
    void Start()
    {
        currtime = 0;
        Drop = false;
        FillValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Drop)
        {
            Debug.Log("true");
            currtime += Time.deltaTime;
            if (currtime >= time)
            {
                
                GameObject NewWaterDrop = Instantiate(LiquidDropsPrefab, gameObject.transform.position, Quaternion.identity);
                NewWaterDrop.GetComponent<WaterDropBehavior>().SetFill(FillValue);
                currtime = 0f;
                FillValue = 0f;
            }
        }
        else
        {
            currtime = 0;
        }
    }

    public void StartDrop()
    {
        Drop = true;
    }

    public void EndDrop()
    {
        Drop = false;
    }

    public void IncreaseFillValue(float fill)
    {
        FillValue += fill;
    }
}
