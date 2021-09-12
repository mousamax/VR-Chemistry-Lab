using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamareekhController : MonoBehaviour
{
    public ShamrokhController[] shamrokhController;
   
    public void StartShamareekh()
    {
        foreach (ShamrokhController shamrokh in shamrokhController)
        {
            shamrokh.StartShamrokh();
        }
    }
    public void StopShamareekh()
    {
        foreach (ShamrokhController shamrokh in shamrokhController)
        {
            shamrokh.StopShamrokh();
        }
    }
}
