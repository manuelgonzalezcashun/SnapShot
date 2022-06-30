using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;

public class ScriptReader : MonoBehaviour
{
    [SerializeField]
    private TextAsset _InkJsonFile;
    private Story _StoryScript;

    public TMP_Text dialogueBox;
    public TMP_Text nameTag;

    void Start()
    {
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            DisplayNextLine();
        }
    }

    void LoadStory()
    {
        _StoryScript = new Story(_InkJsonFile.text);
    }

    public void DisplayNextLine()
    {
        if (_StoryScript.canContinue)
        {
            string text = _StoryScript.Continue();
            text = text?.Trim();
            dialogueBox.text = text;
        }
        else
        {
            dialogueBox.text = "";
        }
    }

}
