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
    public string LiquidColor;

    public Material OrangeMat;
    public Material RedMat;
    public Material BlueMat;

    public Chemicals chem;
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
            //Debug.Log("true");
            currtime += Time.deltaTime;
            if (currtime >= time)
            {
                
                GameObject NewWaterDrop = Instantiate(LiquidDropsPrefab, gameObject.transform.position, Quaternion.identity);
                NewWaterDrop.GetComponent<WaterDropBehavior>().SetFill(FillValue);
                NewWaterDrop.GetComponent<WaterDropBehavior>().SetColor(LiquidColor);
                NewWaterDrop.GetComponent<WaterDropBehavior>().setChemicals(chem);
                // Trying Blue
                //NewWaterDrop.GetComponent<MeshRenderer>().material = BlueMat;
                //NewWaterDrop.GetComponent<TrailRenderer>().material = BlueMat;

                if(LiquidColor == "Orange")
                {
                    NewWaterDrop.GetComponent<MeshRenderer>().material = OrangeMat;
                    NewWaterDrop.GetComponent<TrailRenderer>().material = OrangeMat;
                }
                else if (LiquidColor == "Red")
                {
                    NewWaterDrop.GetComponent<MeshRenderer>().material = RedMat;
                    NewWaterDrop.GetComponent<TrailRenderer>().material = RedMat;
                }
                else if (LiquidColor == "Blue")
                {
                    NewWaterDrop.GetComponent<MeshRenderer>().material = BlueMat;
                    NewWaterDrop.GetComponent<TrailRenderer>().material = BlueMat;
                }
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

    public void SetChemical(Chemicals LiquidChem)
    {
        chem = LiquidChem;
    }
}
