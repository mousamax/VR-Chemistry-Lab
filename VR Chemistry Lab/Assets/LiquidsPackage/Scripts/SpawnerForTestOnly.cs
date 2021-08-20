using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerForTestOnly : MonoBehaviour
{
    // Start is called before the first frame update

    public Chemicals[] chem;
    public GameObject waterdrops;
    float time = 1f;
    float currtime = 0;
    public int ind;
    int count;

    void Start()
    {
        count = 0;
        chem = new Chemicals[3];

        chem[0] = new Chemicals("Potassium Thiocyanate", "Blue", new UnityEngine.Color(0.54f, 0.792f, 0.73f), new UnityEngine.Color(0.651f, 0.980f, 1f), new UnityEngine.Color(0.247f, 0.557f, 0.6784f), 1.886f);
        chem[1] = new Chemicals("Ferric Chloride", "Orange", new UnityEngine.Color(0.9803f, 0.894f, 0.44705f), new UnityEngine.Color(1, 0.843f, 0), new UnityEngine.Color(0.7725f, 0.2588f, 0), 2.9f);
        chem[2] = new Chemicals("Ferric thiocyanate", "Red", new UnityEngine.Color(0.54117f, 0.0117f, 0.0117f), new UnityEngine.Color(0.4f, 0f, 0f), new UnityEngine.Color(1f, 0.0117f, 0), 0.9487f);
    }

    // Update is called once per frame
    void Update()
    {
        currtime += Time.deltaTime;
        if (currtime >= time)
        {
            count++;
            currtime = 0;
            GameObject newdrop = Instantiate(waterdrops, transform.position, Quaternion.identity);
            newdrop.GetComponent<WaterDropBehavior>().chem = chem[ind];
            newdrop.GetComponent<WaterDropBehavior>().SetFill(0.015f);
        }
        if(count >= 3)
        {
            gameObject.SetActive(false);
        }
        //Debug.Log(count);
    }
}
