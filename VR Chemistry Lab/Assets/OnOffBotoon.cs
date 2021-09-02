using UnityEngine;

public class OnOffBotoon : MonoBehaviour
{
    public ParticleSystem firePS;
    public Material OnOff;
    public AudioSource fireAS;

    bool clicked;
    Vector3 startFireScale;
    Vector3 startFirePosition;
    float startAudioVolume;

    // Start is called before the first frame update
    void Start()
    {
        startFireScale = new Vector3(19, 15, 45);
        startFirePosition = new Vector3(firePS.transform.localPosition.x, firePS.transform.localPosition.y, 12.4f);
        startAudioVolume = 0.5f;
        firePS.transform.localPosition = startFirePosition;
        firePS.transform.localScale = startFireScale;
        fireAS.volume = startAudioVolume;
        OnOff.color = new Color(0x00, 0xff, 0xff);
        firePS.Stop();
        fireAS.Stop();
        clicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (clicked)
        {
            OnOff.color = new Color(0x00, 0xff, 0xff);
            firePS.Stop();
            fireAS.Stop();
            clicked = false;
        }
        else
        {
            OnOff.color = new Color(0xff, 0x00, 0x00);
            firePS.Play();
            fireAS.Play();
            clicked = true;
        }
    }
}
