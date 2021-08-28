using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemistryManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] LiquidContainers;

    public GameObject Canvas;

    public Chemicals HCL;
    public Chemicals FeCL3;
    public Chemicals KSCN;
    public Chemicals FeSCN3;

    public bool Exp1;
    public bool Exp2;
    public bool Exp3;

    void Start()
    {
        HCL = new Chemicals("HydroChloric acid", "Blue", new UnityEngine.Color(0.54f, 0.792f, 0.73f), new UnityEngine.Color(0.651f, 0.980f, 1f), new UnityEngine.Color(0.247f, 0.557f, 0.6784f), 1.18f);
        KSCN = new Chemicals("Potassium Thiocyanate", "Blue", new UnityEngine.Color(0.54f, 0.792f, 0.73f), new UnityEngine.Color(0.651f, 0.980f, 1f), new UnityEngine.Color(0.247f, 0.557f, 0.6784f), 1.886f);
        FeCL3 = new Chemicals("Ferric Chloride", "Orange", new UnityEngine.Color(0.9803f, 0.894f, 0.44705f), new UnityEngine.Color(1, 0.843f, 0), new UnityEngine.Color(0.7725f, 0.2588f, 0), 2.9f);
        FeSCN3 = new Chemicals("Ferric thiocyanate", "Red", new UnityEngine.Color(0.54117f, 0.0117f, 0.0117f), new UnityEngine.Color(0.4f, 0f, 0f), new UnityEngine.Color(1f, 0.0117f, 0), 0.9487f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLiquidChem(int index, string name)
    {
        if (name == "HydroChloric acid")
        {
            LiquidContainers[index].GetComponent<LiquidBehavior>().Chem = HCL;
            LiquidContainers[index].GetComponent<LiquidBehavior>().AcquireLiquideProb();
        }
        else if (name == "Potassium Thiocyanate")
        {
            if (Exp1)
            {
                Canvas.GetComponent<Experiment1Instructions>().instruction2Done = true;
            }
            LiquidContainers[index].GetComponent<LiquidBehavior>().Chem = KSCN;
            LiquidContainers[index].GetComponent<LiquidBehavior>().AcquireLiquideProb();
        }
        else if (name == "Ferric Chloride")
        {
            if(Exp1)
            {
                Canvas.GetComponent<Experiment1Instructions>().instruction1Done = true;
            }
            LiquidContainers[index].GetComponent<LiquidBehavior>().Chem = FeCL3;
            LiquidContainers[index].GetComponent<LiquidBehavior>().AcquireLiquideProb();
        }
        else if (name == "Ferric thiocyanate")
        {
            LiquidContainers[index].GetComponent<LiquidBehavior>().Chem = FeSCN3;
            LiquidContainers[index].GetComponent<LiquidBehavior>().AcquireLiquideProb();
        }
    }

    public void StartChemicalReaction(string chem1, string chem2, int index)
    {
        if((chem1 == "Potassium Thiocyanate" && chem2== "Ferric Chloride") || (chem1 == "Ferric Chloride" && chem2 == "Potassium Thiocyanate"))
        {
            if (Exp1)
            {
                Canvas.GetComponent<Experiment1Instructions>().instruction3Done = true;
            }
            LiquidContainers[index].GetComponent<LiquidBehavior>().Chem = FeSCN3;
            LiquidContainers[index].GetComponent<LiquidBehavior>().AcquireLiquideProb();
        }
    }

    public bool StartChemicalReactionOfSodium(string chem, int index)
    {
        if(chem == "HydroChloric acid")
        {
            return true;
        }
        return false;
    }

    public void setExp1()
    {
        Exp1 = true;
    }
}
