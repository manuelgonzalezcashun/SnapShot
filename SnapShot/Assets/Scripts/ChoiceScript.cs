using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceScript : MonoBehaviour
{
    [SerializeField] private GameObject textTrigger;
    [SerializeField] private GameObject Choice01;
    [SerializeField] private GameObject Choice02;

    private bool viewingText;

    public int ChoiceMade;


    public void TextShow()
    {
        viewingText = true;
        textTrigger.SetActive(true);

    }

    public void ChoiceOption1()
    {
        viewingText = true;
        ChoiceMade = 1; 
    }

    public void ChoiceOption2()
    {
        viewingText = true;
        ChoiceMade = 2;
    }

    void Update()
    {
        if (ChoiceMade >= 1)
        {
            Choice01.SetActive(false);
            Choice02.SetActive(false);
        }
    }
}
