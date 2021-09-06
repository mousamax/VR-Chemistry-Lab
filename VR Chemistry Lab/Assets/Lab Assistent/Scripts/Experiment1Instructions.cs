using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experiment1Instructions : MonoBehaviour
{
    public static Experiment1Instructions instance;

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
    [SerializeField] AudioClip instruction3Sound;
    [SerializeField] AudioClip finishingExperiment;
    float delay = 1f;
    
    public float startOverDelay = 5f;
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
            Invoke("ThirdInstruction", delay);

        }
        if (instruction3Done == true)
        {
            //third instruction
            instruction3Done = false;
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

        btn1.onClick.AddListener(ButtonClick);
    }
    public void FirstInstruction()
    {
        changingText.text = "Add the solution of Ferric Chloride to the beaker.";
        audioSource.Stop();
        audioSource.PlayOneShot(instruction1Sound);
        //instruction1Done = true;

    }
    public void SecondInstruction()
    {
        changingText.text = "Add the solution of Potassium Thiocyanate to the beaker and mix the two solutions.";
        
        audioSource.Stop();
        //instruction2Done = true;
        audioSource.PlayOneShot(instruction2Sound);
       
    }
    public void ThirdInstruction()
    {
        changingText.text = "When they contact each other blood red color appears.";
        audioSource.Stop();
        //instruction3Done = true;
        audioSource.PlayOneShot(instruction3Sound);
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
        Invoke("StartOver", startOverDelay);
    }

}