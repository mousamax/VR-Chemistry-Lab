using UnityEngine;
using UnityEngine.Events;

public class OnOfBotton : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;
    [SerializeField] private ParticleSystem firePS;
    [SerializeField] private Material OnOff;
    [SerializeField] private AudioSource fireAS;

    private bool isPressed;
    private bool clicked;
    float startAudioVolume;
    private Vector3 startPosition;
    private Vector3 startFireScale;
    private Vector3 startFirePosition;
    private ConfigurableJoint joint;
    public UnityEvent onPressed, onReleased;
 
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();

        startFireScale = new Vector3(0.03f, 0.01f, 0.03f);
        startFirePosition = new Vector3(firePS.transform.localPosition.x, firePS.transform.localPosition.y, 12.4f);
        startAudioVolume = 1.00f;
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
        if (!isPressed && GetValue() + threshold >= 1)
            Pressed();
        if (isPressed && GetValue() - threshold <= 0)
            Released();
    }

    private void Pressed()
    {
        isPressed = true;
        onPressed.Invoke();
        Debug.Log("Pressed");
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

    private void Released()
    {
        isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
        
    }

    private float GetValue()
    {   
        var Value = Vector3.Distance(startPosition, transform.localPosition) / joint.linearLimit.limit;
        if (Mathf.Abs(Value) < deadZone)
            Value = 0;

        return Mathf.Clamp(Value, -1, 1);
    }

}
