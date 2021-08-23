using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBoard1 : MonoBehaviour
{
    public Text changingText;
    public Button btn1;
    public Button btn2;

    private void Update()
    {
        TextChange();
    }

    void FirstInstruction()
    {
        changingText.text = "Add 25 ml of hydrochloric acid(HCl) to beaker.";

        btn1.gameObject.SetActive(false);
        btn2.gameObject.SetActive(false);
    }

    public void TextChange()
    {
        btn1.onClick.AddListener(FirstInstruction); 
        if(Input.GetKeyDown(KeyCode.Space))
        {
            changingText.text = "Add 25 ml of soduim hydroxide(NaOH) to the same beaker.";
        }
    }
}
