using UnityEngine;

public class StrictMotion : MonoBehaviour
{
    Rigidbody rb;

    void Update()
    {
        rb = GetComponent<Rigidbody>();
        
        rb.constraints = RigidbodyConstraints.FreezePositionX;
        rb.constraints = RigidbodyConstraints.FreezePositionZ;

        rb.constraints = RigidbodyConstraints.FreezeRotationX;
        rb.constraints = RigidbodyConstraints.FreezeRotationY;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ;
    }
}