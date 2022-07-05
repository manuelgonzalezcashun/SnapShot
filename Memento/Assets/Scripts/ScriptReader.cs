using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
public class ScriptReader : MonoBehaviour
{
    [SerializeField] private TextAsset _InkJsonFile;
    [SerializeField] private Story _StoryScript;

    public TMP_Text dialogueBox;
    public TMP_Text nameTag;

    void Start()
    {
        LoadStory();
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
    IEnumerator TypeSentence(string sentence)
    {
        dialogueBox.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueBox.text += letter;
            yield return null;
        }
        /*CharacterScript tempSpeaker = GameObject.FindObjectOfType<CharacterScript>();
        if (tempSpeaker.isTalking)
        {
            SetAnimation("idle");
        }*/
        yield return null;
    }

    public void DisplayNextLine()
    {
        if (_StoryScript.canContinue)
        {
            string text = _StoryScript.Continue();
            text = text?.Trim();
            dialogueBox.text = text;
            StartCoroutine(TypeSentence(text));
        }
        else
        {
            dialogueBox.text = "Bye";
        }
    }

}
