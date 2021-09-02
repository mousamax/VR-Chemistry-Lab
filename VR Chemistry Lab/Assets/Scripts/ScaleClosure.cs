
using UnityEngine;

public class ScaleClosure : MonoBehaviour
{
    // Start is called before the first frame update
   public bool isClosed = false;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "ScaleDoor")
        {
            isClosed = true;
            Debug.Log("Hello");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "ScaleDoor")
        {
            isClosed = false;
        }
    }

}
