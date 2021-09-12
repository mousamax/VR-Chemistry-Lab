using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamrokhController : MonoBehaviour
{
    [SerializeField]
    AudioClip shamrokhClip;
    public void StartShamrokh()
    {
        this.GetComponent<AudioSource>().Stop();
        this.GetComponent<AudioSource>().PlayOneShot(shamrokhClip);
        this.GetComponent<ParticleSystem>().Play();
    }
    public void StopShamrokh()
    {
        this.GetComponent<AudioSource>().Stop();
        this.GetComponent<ParticleSystem>().Stop();
    }
}
