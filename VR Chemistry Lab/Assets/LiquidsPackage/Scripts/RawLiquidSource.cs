using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawLiquidSource : MonoBehaviour
{
    public Chemicals[] chem;
    public GameObject LiquidDropsGenerator;
    float Endtime = 0.3f;
    float currtime = 0;
    public int ind;
    //int count;
    public float fill;
    Renderer rend;
    public float Vol;
    public float Mass;

    
    public string FillName;

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
    bool Empty;

    bool StartFilling;
    float fillTime = 3f;
    float tofillTime = 1f;
    float initialfill;
    // Start is called before the first frame update
    void Start()
    {
        StartFilling = false;
        Empty = false;
        chem = new Chemicals[4];

        chem[0] = new Chemicals("Potassium Thiocyanate", "Blue", new UnityEngine.Color(0.54f, 0.792f, 0.73f), new UnityEngine.Color(0.651f, 0.980f, 1f), new UnityEngine.Color(0.247f, 0.557f, 0.6784f), 1.886f);
        chem[1] = new Chemicals("Ferric Chloride", "Orange", new UnityEngine.Color(0.9803f, 0.894f, 0.44705f), new UnityEngine.Color(1, 0.843f, 0), new UnityEngine.Color(0.7725f, 0.2588f, 0), 2.9f);
        chem[2] = new Chemicals("Ferric thiocyanate", "Red", new UnityEngine.Color(0.54117f, 0.0117f, 0.0117f), new UnityEngine.Color(0.4f, 0f, 0f), new UnityEngine.Color(1f, 0.0117f, 0), 0.9487f);
        chem[3] = new Chemicals("HydroChloric acid", "Blue", new UnityEngine.Color(0.54f, 0.792f, 0.73f), new UnityEngine.Color(0.651f, 0.980f, 1f), new UnityEngine.Color(0.247f, 0.557f, 0.6784f), 1.18f);

        rend = GetComponent<Renderer>();
        fill = rend.material.GetFloat(FillName);
        rend.material.SetColor("Lcol", chem[ind].LiquidColor);
        rend.material.SetColor("Color_2fefd8e1a99a4d158a13eba51e575822", chem[ind].SurfaceColor);
        rend.material.SetColor("Color_4beac76ce7c34d629b5cc6460ea6ecdb", chem[ind].FresnelColor);
        Vol = ((fill + 0.1f) / 0.2f);
        Mass = chem[ind].Density * Vol;
        initialfill = fill;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Angle(Vector3.down, LiquidDropsGenerator.transform.forward) <= 90f && fill >= -0.2f && !Empty)
        {
            //dropping.Play();
            //Debug.Log("entered");
            LiquidDropsGenerator.GetComponent<WaterDropsSpawner>().StartDrop();
            float FillDroped = 0.3f * Time.deltaTime;
            fill -= FillDroped;
            //Debug.Log("6");
            if (fill <= -0.131f)
            {
                //Debug.Log("5");
                fill = -1;
                Empty = true;
            }
            LiquidDropsGenerator.GetComponent<WaterDropsSpawner>().IncreaseFillValue(FillDroped/10f);
            LiquidDropsGenerator.GetComponent<WaterDropsSpawner>().LiquidColor = chem[ind].Color;
            LiquidDropsGenerator.GetComponent<WaterDropsSpawner>().SetChemical(chem[ind]);
            rend.material.SetFloat(FillName, fill);
            fillTime = 3f;
        }
        else
        {
            if(Empty)
            {
                //Debug.Log("1");
                fillTime -= Time.deltaTime;
            }
            if(fillTime <= 0)
            {
                Empty = false;
                //Debug.Log("2");
                if (fill < initialfill)
                {
                    //Debug.Log("3");
                    if (fill == -1)
                    {
                        //Debug.Log("4");
                        fill = -0.131f;
                    }
                    fill += 0.1f * Time.deltaTime * tofillTime;
                    if(fill > initialfill)
                    {
                        fill = initialfill;
                    }
                }
            }
            //dropping.Stop();
            LiquidDropsGenerator.GetComponent<WaterDropsSpawner>().EndDrop();
            LiquidDropsGenerator.GetComponent<WaterDropsSpawner>().setStarted();

            //Empty = true;
        }
        rend.material.SetFloat(FillName, fill);

        //Debug.Log(fill);
        fill = rend.material.GetFloat(FillName);
        Vol = ((fill + 0.1f) / 0.2f);
        Mass = chem[ind].Density * Vol;

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
    }
}
