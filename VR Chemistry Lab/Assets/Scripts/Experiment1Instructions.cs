using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experiment1Instructions : MonoBehaviour
{
    public Text changingText;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    AudioSource audioSource;
    [SerializeField] AudioClip buttonSound;
    [SerializeField] AudioClip instruction1Sound;
    [SerializeField] AudioClip instruction2Sound;
    [SerializeField] AudioClip instruction3Sound;
    float delay = 1f;
    bool instruction1Done = false;
    bool instruction2Done = false;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        TextChange();
        if (Input.GetKeyDown(KeyCode.Space) && instruction1Done == true)
        {
            //third instruction
            Invoke("SecondInstruction", delay);
        }

    }

    void ButtonClick()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(buttonSound);
        btn1.gameObject.SetActive(false);
        btn2.gameObject.SetActive(false);
        btn3.gameObject.SetActive(false);
        Invoke("FirstInstruction", delay);

    }

    public void TextChange()
    {

        btn1.onClick.AddListener(ButtonClick);
    }
    public void FirstInstruction()
    {
        changingText.text = "Add the solution of Ferric Chloride to the beaker.";
        audioSource.Stop();
        audioSource.PlayOneShot(instruction1Sound);
        instruction1Done = true;

    }
    public void SecondInstruction()
    {
        changingText.text = "Add the solution of Potassium Thiocyanate to the beaker and mix the two solutions.";
        
        audioSource.Stop();
        audioSource.PlayOneShot(instruction2Sound);
        if (Input.GetKeyDown(KeyCode.Space) && instruction2Done == false)
        {
            //third instruction
            Invoke("ThirdInstruction", delay);
        }
    }
    public void ThirdInstruction()
    {
        changingText.text = "When they contact each other blood red color appears.";
        instruction2Done = true;
        audioSource.Stop();
        audioSource.PlayOneShot(instruction3Sound);
    }

}