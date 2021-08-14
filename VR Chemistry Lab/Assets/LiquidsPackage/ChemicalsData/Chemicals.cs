using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chemicals
{
    public string Name;
    public string Color;
    public UnityEngine.Color SurfaceColor;
    public UnityEngine.Color LiquidColor;
    public UnityEngine.Color FresnelColor;
    public float Density;

    public Chemicals(string name, string color, Color Scol, Color Lcol, Color Fcol, float den)
    {
        Name = name;
        Color = color;
        SurfaceColor = Scol;
        LiquidColor = Lcol;
        FresnelColor = Fcol;
        Density = den;
    }

}
