using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experiment3Instructions : MonoBehaviour
{
    public Text changingText;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public RawImage wellDone;
    public RawImage beakers;
    public RawImage dixter;
    AudioSource audioSource;
    [SerializeField] AudioClip buttonSound;
    [SerializeField] AudioClip instruction1Sound;
    [SerializeField] AudioClip instruction2Sound;
    [SerializeField] AudioClip finishingExperiment;
    float delay = 1f;
    public bool instruction1Done = false;
    public bool instruction2Done = false;
    public bool instruction3Done = false;


    private void Start()
    {
        wellDone.gameObject.SetActive(false);
        dixter.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        TextChange();
        if (instruction1Done == true)
        {
            //second instruction
            instruction1Done = false;
            Invoke("SecondInstruction", delay);
        }
        if (instruction2Done == true)
        {
            //third instruction
            instruction2Done = false;
            Invoke("Finish", delay);
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

        btn3.onClick.AddListener(ButtonClick);
    }
    public void FirstInstruction()
    {
        changingText.text = "Put some hydrochloric acid in a flask.";
        audioSource.Stop();
        audioSource.PlayOneShot(instruction1Sound);
        //instruction1Done = true;

    }
    public void SecondInstruction()
    {
        changingText.text = "Bring a piece of sodium and throw it in the flask, you will observe evaporating smoke and the liquid gets excited.";

        audioSource.Stop();
        //instruction2Done = true;
        audioSource.PlayOneShot(instruction2Sound);

    }
    public void StartOver()
    {
        wellDone.gameObject.SetActive(false);
        dixter.gameObject.SetActive(false);
        btn1.gameObject.SetActive(true);
        btn2.gameObject.SetActive(true);
        btn3.gameObject.SetActive(true);
        changingText.gameObject.SetActive(true);
        changingText.text = "Choose from the following experiments:";
        beakers.gameObject.SetActive(true);
    }
    public void Finish()
    {
        changingText.gameObject.SetActive(false);
        beakers.gameObject.SetActive(false);
        wellDone.gameObject.SetActive(true);
        dixter.gameObject.SetActive(true);
        audioSource.Stop();
        audioSource.PlayOneShot(finishingExperiment);
        Invoke("StartOver", Experiment1Instructions.instance.startOverDelay);
    }

}