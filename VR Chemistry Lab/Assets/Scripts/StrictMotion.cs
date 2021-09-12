using UnityEngine;

public class StrictMotion : MonoBehaviour
{
    Rigidbody rb;

    void Update()
    {
        rb = GetComponent<Rigidbody>();
        
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
    }
}