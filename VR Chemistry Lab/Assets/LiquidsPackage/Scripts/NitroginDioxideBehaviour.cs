using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroginDioxideBehaviour : MonoBehaviour
{
    // Start is called before the first frame update


    public float Temp;
    public float RoomTemp;
    public LayerMask FireMask;
    public LayerMask IceMask;
    public Material NitroginGasMat;
    public float oppacity;
    bool Hot;
    bool Cold;
    void Start()
    {
        oppacity = 35f/50f;
        //NitroginGasMat.SetColor("_BaseColor", new Color(0.753f, 0.259f, 0.04f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        NitroginGasMat.SetColor("_BaseColor", new Color(0.753f, 0.259f, 0.04f, oppacity));
        if (Temp > 45)
        {
            Hot = true;
            Cold = false;
        }
        else if (Temp < 20)
        {
            Cold = true;
            Hot = false;
        }
        else
        {
            Cold = false;
            Hot = false;
        }


        if(Physics.CheckSphere(transform.position, 0.2f, FireMask))
        {
            Temp += 5f * Time.deltaTime;
            if(Temp >= 50f)
            {
                Temp = 50;
            }
            oppacity = Temp / 50;
            NitroginGasMat.SetColor("_BaseColor",new Color(0.753f,0.259f,0.04f, oppacity));
            //Debug.Log("entered if condition");
        }
        else if(Physics.CheckSphere(transform.position, 0.2f, IceMask))
        {
            Temp -= 5f * Time.deltaTime;
            if (Temp < 0f)
            {
                Temp = 0f;
            }
            oppacity = Temp / 50;
            NitroginGasMat.SetColor("_BaseColor", new Color(0.753f, 0.259f, 0.04f, oppacity));
            //Debug.Log("entered if condition");
        }
        if (Temp > 35)
        {
            Temp -= 2.5f * Time.deltaTime;
            if (Temp < 35)
            {
                Temp = 35f;
            }
            oppacity = Temp / 50;
            NitroginGasMat.SetColor("_BaseColor", new Color(0.753f, 0.259f, 0.04f, oppacity));
        }
        else if (Temp < 35)
        {
            Temp += 2.5f * Time.deltaTime;
            if (Temp > 35)
            {
                Temp = 35f;
            }
            oppacity = Temp / 50;
            NitroginGasMat.SetColor("_BaseColor", new Color(0.753f, 0.259f, 0.04f, oppacity));
        }
        //Debug.Log(Temp);    
    }
}
