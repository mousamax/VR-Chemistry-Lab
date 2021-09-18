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

    public GameObject Canvas;

    public bool Exp2 = false;

    Vector3 InitialPos;
    bool Inst1;
    bool Inst2;
    bool Inst3;


    void Start()
    {
        Inst1 = true;
        Inst2 = true;
        Inst3 = true;
        oppacity = 35f / 50f;
        //NitroginGasMat.SetColor("_BaseColor", new Color(0.753f, 0.259f, 0.04f, 1f));
        InitialPos = gameObject.transform.parent.position;


    }

    // Update is called once per frame
    void Update()
    {
        // To be Changed later (must be translated to be moved of shelve)
        if (Exp2 == true && (gameObject.transform.parent.position.x != InitialPos.x || gameObject.transform.parent.position.y != InitialPos.y || gameObject.transform.parent.position.z != InitialPos.z) && Inst1)
        {
            Inst1 = false;
            Canvas.GetComponent<Experiment2Instructions>().instruction1Done = true;
        }

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


        if (Physics.CheckSphere(transform.position, 0.2f, FireMask))
        {
            Temp += 5f * Time.deltaTime;
            if (Temp >= 49f)
            {
                if (Exp2 && Inst3)
                {
                    Inst3 = false;
                    Canvas.GetComponent<Experiment2Instructions>().instruction3Done = true;
                }
                Temp = 50;
            }
            oppacity = Temp / 50;
            NitroginGasMat.SetColor("_BaseColor", new Color(0.753f, 0.259f, 0.04f, oppacity));
            //Debug.Log("entered if condition");
        }
        else if (Physics.CheckSphere(transform.position, 0.2f, IceMask))
        {
            Temp -= 5f * Time.deltaTime;
            if (Temp < 1f)
            {
                if (Exp2 && Inst2)
                {
                    Inst2 = false;
                    Canvas.GetComponent<Experiment2Instructions>().instruction2Done = true;
                }
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

    public void SetExp2()
    {
        Exp2 = true;
    }

    public void ResetExperiment()
    {
        Exp2 = false;
        Inst1 = true;
        Inst2 = true;
        Inst3 = true;
    }

}
