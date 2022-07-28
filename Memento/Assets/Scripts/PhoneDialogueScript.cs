using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.EventSystems;
using Ink.UnityIntegration;

public class PhoneDialogueScript : MonoBehaviour
{
    private static PhoneDialogueScript instance;
    [SerializeField] private Story currentStory;
    [SerializeField] private TextAsset InkJSON;
    [SerializeField] private TextMeshProUGUI dialogue1;
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    [SerializeField] private TextMeshProUGUI dialogue2;
    [SerializeField] private InkFile globalsInkFile;
    private DialogueVariables dialogueVariables;
    
    private void Awake()
    {
        instance = this;

        dialogueVariables = new DialogueVariables(globalsInkFile.filePath);
    }
    public static PhoneDialogueScript GetInstance()
    {
        return instance;
    }
    void Start()
    {
        LoadStory();
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextLine();
        }
        
    }
    private void LoadStory()
    {
        currentStory = new Story(InkJSON.text);
        dialogueVariables.StartListening(currentStory);
    }
    private void NextLine()
    {
        if (currentStory.canContinue)
        {
            string text = currentStory.Continue();
            text = text?.Trim();
            dialogue1.text = text;
            DisplayChoices();
        } else 
        {
            dialogueVariables.StopListening(currentStory);
        }
            
    }
    private void DisplayChoices()
    {
        List<Choice> currentchoices = currentStory.currentChoices;

        if (currentchoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can handle");
        }

        int index = 0;
        foreach(Choice choice in currentchoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
        StartCoroutine(SelectFirstChoice());
    }
    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }
    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }
    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink Variable was found to be null: " +variableName);
        }
        return variableValue;
    }
}
