using UnityEngine;
using UnityEngine.UI;

public class Weight : MonoBehaviour
{
    public TextMesh weight;
    float oldWeight, newweight, colidedweight;
    int colided;

    private void Start()
    {
        oldWeight = newweight = colided = 0;
    }

    private void Update()
    {
        if (colided == 0)
            newweight = 0;

        weight.text = newweight.ToString("#.###");

        oldWeight = newweight;
    }

    private void OnCollisionEnter(Collision collision)
    {
        colidedweight = collision.rigidbody.mass;
        newweight = oldWeight + colidedweight;
        colided++;
    }

    private void OnCollisionExit(Collision collision)
    {
        colidedweight = collision.rigidbody.mass;
        newweight = oldWeight - colidedweight;
        colided--;
    }

}
