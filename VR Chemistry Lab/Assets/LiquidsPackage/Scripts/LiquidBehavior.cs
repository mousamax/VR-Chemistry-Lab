using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidBehavior : MonoBehaviour
{
    public int index;
    public GameObject ChemistryManager;

    Renderer rend;
    Vector3 lastPos;
    Vector3 velocity;
    Vector3 lastRot;
    Vector3 angularVelocity;
    public float MaxWobble = 0.03f;
    public float WobbleSpeed = 1f;
    public float Recovery = 1f;
    float wobbleAmountX;
    float wobbleAmountZ;
    float wobbleAmountToAddX;
    float wobbleAmountToAddZ;
    float pulse;
    float time = 0.5f;
    float fill;
    public string FillName;

    public GameObject LiquidSpawner;

    public string Color = "Blue";

    public Chemicals Chem;
    public bool Filled;
    public bool Empty;
    public float Vol;
    public float Mass;
    float TimeOfExitation;

    bool Exited;

    // Start is called before the first frame update
    void Start()
    {
        TimeOfExitation = 0;
        Exited = false;
        Empty = true;
        rend = GetComponent<Renderer>();
        fill = rend.material.GetFloat(FillName);
        if(fill > -0.1)
        {
            Empty = false;
        }

        if (fill >= 0.1)
        {
            Filled = true;
        }
        else
            Filled = false;
        //rend.material.SetFloat("_fill2", fill);
        //Debug.Log(Vol);
        //Debug.Log(Mass);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Angle(Vector3.down, LiquidSpawner.transform.forward) <= 90f && fill >= -0.1f && !Empty)
        {
            //dropping.Play();
            //Debug.Log("entered");
            LiquidSpawner.GetComponent<WaterDropsSpawner>().StartDrop();
            float FillDroped = 0.03f * Time.deltaTime;
            fill -= FillDroped;
            if(fill <= -0.05)
            {
                fill = -1;
                Empty = true;
            }
            LiquidSpawner.GetComponent<WaterDropsSpawner>().IncreaseFillValue(FillDroped);
            LiquidSpawner.GetComponent<WaterDropsSpawner>().LiquidColor = Chem.Color;
            LiquidSpawner.GetComponent<WaterDropsSpawner>().SetChemical(Chem);
            rend.material.SetFloat(FillName, fill);
        }
        else
        {
            //dropping.Stop();
            LiquidSpawner.GetComponent<WaterDropsSpawner>().EndDrop();
            //Empty = true;
        }

        time += Time.deltaTime;
        // decrease wobble over time
        wobbleAmountToAddX = Mathf.Lerp(wobbleAmountToAddX, 0, Time.deltaTime * (Recovery));
        wobbleAmountToAddZ = Mathf.Lerp(wobbleAmountToAddZ, 0, Time.deltaTime * (Recovery));

        // make a sine wave of the decreasing wobble
        pulse = 2f * Mathf.PI * WobbleSpeed;
        wobbleAmountX = wobbleAmountToAddX * Mathf.Sin(pulse * time);
        wobbleAmountZ = wobbleAmountToAddZ * Mathf.Sin(pulse * time);

        // send it to the shader
        rend.material.SetFloat("_WobbleX", wobbleAmountX);
        rend.material.SetFloat("_WobbleZ", wobbleAmountZ);

        // velocity
        velocity = (lastPos - transform.position) / Time.deltaTime;
        angularVelocity = transform.rotation.eulerAngles - lastRot;


        // add clamped velocity to wobble
        wobbleAmountToAddX += Mathf.Clamp((velocity.x + (angularVelocity.z * 0.2f)) * MaxWobble, -MaxWobble, MaxWobble);
        wobbleAmountToAddZ += Mathf.Clamp((velocity.z + (angularVelocity.x * 0.2f)) * MaxWobble, -MaxWobble, MaxWobble);

        // keep last position
        lastPos = transform.position;
        lastRot = transform.rotation.eulerAngles;

        if (rend.material.GetFloat(FillName) <= -0.1f)
        {
            Empty = true;
            rend.material.SetFloat(FillName, -1);
        }

        if(Exited)
        {
            TimeOfExitation += Time.deltaTime;
            float exFill = UnityEngine.Random.Range(fill - 0.005f, fill + 0.005f);
            rend.material.SetFloat(FillName, exFill);
            if(TimeOfExitation >= 3)
            {
                TimeOfExitation = 0;
                Exited = false;
            }
        }
    }

    public void FillLiquidContainer(float addfill, string name)
    {
        if(Empty)
        {
            fill = -0.05f - addfill;
            ChemistryManager.GetComponent<ChemistryManager>().SetLiquidChem(index, name);
        }
        else
        {
            ChemistryManager.GetComponent<ChemistryManager>().StartChemicalReaction(Chem.Name, name, index);
        }
        fill += addfill;
        rend.material.SetFloat(FillName, fill);
        Empty = false;
        Vol = ((fill + 0.1f) / 0.2f);
        Mass = Chem.Density * Vol;
    }

    public void AcquireLiquideProb()
    {
        //Chem = new Chemicals("Hcl", "Blue", new UnityEngine.Color(0.54f, 0.792f, 0.73f), new UnityEngine.Color(0.651f, 0.980f, 1f), new UnityEngine.Color(0.247f, 0.557f, 0.6784f), 1.18f);
        rend.material.SetColor("Lcol", Chem.LiquidColor);
        rend.material.SetColor("Color_2fefd8e1a99a4d158a13eba51e575822", Chem.SurfaceColor);
        rend.material.SetColor("Color_4beac76ce7c34d629b5cc6460ea6ecdb", Chem.FresnelColor);
        Vol = ((fill + 0.1f) / 0.2f);
        Mass = Chem.Density * Vol;
    }


    public bool DetectSodium()
    {
        if (Empty)
            return false;
        bool res =  ChemistryManager.GetComponent<ChemistryManager>().StartChemicalReactionOfSodium(Chem.Name, index);
        if(res)
        {
            Exited = true;
        }
        return res;
    }
}
