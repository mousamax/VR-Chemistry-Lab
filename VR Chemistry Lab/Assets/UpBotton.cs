using UnityEngine;

public class UpBotton : MonoBehaviour
{
    //public ParticleSystem upfirePS;
    public Material up;
    //public AudioSource upfireAS;

    /*Vector3 upPositionValue;
    Vector3 upScaleValue;
    float upVolumeValue;

    Vector3 maxPositionValus;
    Vector3 maxScaleValue;
    float maxVolumeValue;*/

    // Start is called before the first frame update
    void Start()
    {
        up.color = new Color(0x00, 0xbf, 0x7a);


        /*upPositionValue = new Vector3(upfirePS.transform.localPosition.x, upfirePS.transform.localPosition.y, 0.2f);
        upScaleValue = new Vector3(2, 5, 10);
        upVolumeValue = 0.25f;

        maxPositionValus = new Vector3(upfirePS.transform.localPosition.x, upfirePS.transform.localPosition.y, 12.8f);
        maxScaleValue = new Vector3(23, 25, 65);
        maxVolumeValue = 1;*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        up.color = new Color(0x00, 0xbf, 0x7a);
    }


    private void OnMouseDown()
    {
        Debug.Log("I am Here");
       /* upfirePS.transform.localPosition += upPositionValue;
        upfirePS.transform.localScale += upScaleValue;
        upfireAS.volume = upVolumeValue;*/
        up.color = new Color(0x00, 0xff, 0xa8);


       /* if (upfirePS.transform.localPosition.z > maxPositionValus.z)
            upfirePS.transform.localPosition = maxPositionValus;
        
        if (upfirePS.transform.localScale.x > maxScaleValue.x || upfirePS.transform.localScale.y > maxScaleValue.y || upfirePS.transform.localScale.z > maxScaleValue.z)
            upfirePS.transform.localScale = maxScaleValue;

        if (upfireAS.volume > maxVolumeValue)
            upfireAS.volume = maxVolumeValue;*/
    }
}
