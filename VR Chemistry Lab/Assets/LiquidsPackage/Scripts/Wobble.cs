using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour
{
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
    float fill = 1f;
    public string FillName;
    public ParticleSystem dropping;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.SetFloat("_fill2", fill);
    }
    private void Update()
    {

        if (Vector3.Angle(Vector3.down, dropping.gameObject.transform.forward) <= 90f && fill >= -1f)
        {
            dropping.Play();
            fill -= 0.3f * Time.deltaTime;
            rend.material.SetFloat(FillName, fill);
            
        }
        else
        {
            dropping.Stop();
        }

        //if (fill > 0)
        //{
        //    fill -= 0.1f * Time.deltaTime;
        //    rend.material.SetFloat("_fill2", fill);
        //}

        time += Time.deltaTime;
        // decrease wobble over time
        wobbleAmountToAddX = Mathf.Lerp(wobbleAmountToAddX, 0, Time.deltaTime * (Recovery));
        wobbleAmountToAddZ = Mathf.Lerp(wobbleAmountToAddZ, 0, Time.deltaTime * (Recovery));

        // make a sine wave of the decreasing wobble
        pulse = 2 * Mathf.PI * WobbleSpeed;
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

    private void OnParticleCollision(GameObject other)
    {
        if (fill <= 1f)
        {
            fill += 0.3f * Time.deltaTime;
            if (fill > 1f)
                fill = 1f;
            rend.material.SetFloat(FillName, fill);
            //ParticleSystem.Particle[] particles = new ParticleSystem.Particle[dropping.particleCount];
            //int size = dropping.GetParticles(particles);
            ////for(int i = 0; i < size;i++)
            ////{
            ////    particles[i].remainingLifetime = 0;
            ////}
            ////dropping.SetParticles(particles, size);

        }
    }

}

