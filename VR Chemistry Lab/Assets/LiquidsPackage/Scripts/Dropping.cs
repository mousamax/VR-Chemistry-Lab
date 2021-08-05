using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Dropping : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject particles;
    public ParticleSystem dropping;
    public Material shader;
    //float fill;
    void Start()
    {
        //dropping = gameObject.GetComponent<ParticleSystem>();
        //fill = 1f;
        //shader.SetFloat("_WobbleX", fill);
    }

    // Update is called once per frame
    void Update()
    {
        //Invoke("Fill decreasing in 2 seconds", 2);//this will happen after 2 seconds
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("entered");
        //    fill -= 0.1f;
        //    shader.SetFloat("_WobbleX", fill / 1f);
        //}
        //Debug.Log(shader.GetFloat("Vector1_608b72011eae447ea01a63f1e9d24c02"));

        //if (true)
        //{
        //    shader.SetFloat("Vector1_608b72011eae447ea01a63f1e9d24c02", shader.GetFloat("Vector1_608b72011eae447ea01a63f1e9d24c02") - 0.2f);
        //}
        if (Vector3.Angle(Vector3.down, dropping.gameObject.transform.forward) <= 90f)
        {
            dropping.Play();
            //if (shader.GetFloat("Vector1_608b72011eae447ea01a63f1e9d24c02") > 0f)
            //{
            //    shader.SetFloat("Vector1_608b72011eae447ea01a63f1e9d24c02", shader.GetFloat("Vector1_608b72011eae447ea01a63f1e9d24c02") - 0.1f);
            //}
        }
        else
        {
            dropping.Stop();
        }
    }
}
