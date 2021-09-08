using UnityEngine;

public class GlassBreaking : MonoBehaviour
{
    public Transform brokenGlass;
    Quaternion q;
    Vector3 positionOffset;
    public int XpositionOffset;
    public int YpositionOffset;
    public int ZpositionOffset;
    void OnCollisionEnter(Collision collision)
    {
        if ( collision.collider.tag == "Ground" )
        {
            q.x = 70;
            q.y = 45;
            q.z = 70;
            q.w = 70;
            positionOffset.x = XpositionOffset;
            positionOffset.y = YpositionOffset+0.3f;
            positionOffset.z = ZpositionOffset;
            Destroy(gameObject);
            Instantiate(brokenGlass, transform.position + positionOffset,q);
        }
    }
}
