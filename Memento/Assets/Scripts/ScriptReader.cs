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

    [SerializeField]
    private GridLayoutGroup choiceHolder;

    [SerializeField]
    private Button choiceBasePrefab;

    void Start()
    {
        LoadStory();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
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
        else if (_StoryScript.currentChoices.Count > 0)
        {
            DisplayChoices();
        }
        else 
        {
            dialogueBox.text = "Bye";
        }
    }


    private void DisplayChoices()
    {
        if (choiceHolder.GetComponentsInChildren<Button>().Length > 0) return; 

        for (int i = 0; i < _StoryScript.currentChoices.Count; i++)
        {
            var choice = _StoryScript.currentChoices[i];
            var button = CreateChoiceButton(choice.text);

            button.onClick.AddListener(()=> OnClickChoiceButton(choice));
        }
    }

    Button CreateChoiceButton(string text)
    {

        var choiceButton = Instantiate(choiceBasePrefab);
        choiceButton.transform.SetParent(choiceHolder.transform, false);

        var buttonText = choiceButton.GetComponentInChildren<TMP_Text>();
        buttonText.text = text;

        return choiceButton;
    }


    void OnClickChoiceButton(Choice choice)
    {
        _StoryScript.ChooseChoiceIndex(choice.index);
        RefreshChoiceView();
        DisplayNextLine();
    }
    
    void RefreshChoiceView()
    {
        if (choiceHolder != null)
        {
            foreach(var button in choiceHolder.GetComponentsInChildren<Button>())
            {
                Destroy(button.gameObject);
            }
        }
    }
}
