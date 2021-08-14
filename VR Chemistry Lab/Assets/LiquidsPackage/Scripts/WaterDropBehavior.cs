using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class WaterDropBehavior : MonoBehaviour
{

    float FillValue;
    //public GameObject prefabImage;
    public GameObject WaterDropOrange;
    public GameObject WaterDropRed;
    public GameObject WaterDropBlue;

    public string Color;
    public int size;
    public GameObject[] RedPrefabs;
    public GameObject[] OrangePrefabs;
    public GameObject[] BluePrefabs;


    public Chemicals chem;

    static int Ind = 0;


    // Start is called before the first frame update
    void Start()
    {
        //RedPrefabs = new GameObject[size];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Fluid")
        {
            collision.gameObject.GetComponent<LiquidBehavior>().FillLiquidContainer(FillValue,chem.Name);
        }
        else if(collision.gameObject.tag == "Land")
        {
            Vector3 pos = new Vector3(transform.position.x, collision.gameObject.transform.position.y + 0.1f, transform.position.z);
            if (Color == "Orange")
            {
                //int i = Random.Range(0, size);
                if (Ind == 4)
                    Ind = 0;

                GameObject NewImage = Instantiate(OrangePrefabs[Ind]);
                NewImage.transform.position = pos;
                Debug.Log(Ind);
                Ind++;
                GameObject NewParticle = Instantiate(WaterDropOrange);
                NewParticle.transform.position = pos;
            }
            else if(Color == "Red")
            {
                if (Ind == 4)
                    Ind = 0;
                //int i = Random.Range(0, size);
                GameObject NewImage = Instantiate(RedPrefabs[Ind]);
                NewImage.transform.position = pos;
                Ind++;
                GameObject NewParticle = Instantiate(WaterDropRed);
                NewParticle.transform.position = pos;
            }
            else if(Color == "Blue")
            {
                if (Ind == 4)
                    Ind = 0;
                //int i = Random.Range(0, size);
                GameObject NewImage = Instantiate(BluePrefabs[Ind]);
                NewImage.transform.position = pos;
                Ind++;
                GameObject NewParticle = Instantiate(WaterDropBlue);
                NewParticle.transform.position = pos;
            }
        }
        //Debug.Log(chem.Name);
        Destroy(gameObject);
    }

    public void SetFill(float fill)
    {
        FillValue = fill;
    }

    public void SetColor(string input)
    {
        Color = input;
    }

    public void setChemicals(Chemicals chemical)
    {
        chem = chemical;
    }
}
