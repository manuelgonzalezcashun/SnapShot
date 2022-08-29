using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.EventSystems;

public class PhoneTextManager : MonoBehaviour
{
    [SerializeField] private Story phoneStory;
    [SerializeField] private TextAsset inkJsonFile;
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    public GameObject[] TextMessages;
    public TextMeshProUGUI[] Dialogue;

    private const string SENTENCE = "sentence";
    private int _sentenceNum;

    public int Sentence
    {
        get => _sentenceNum;
        private set
        {
            Debug.Log($"Updating sentenceNum value. Old value: {_sentenceNum}. new value: {value}");
            _sentenceNum = value;
        }
    }
    void Start()
    {
        LoadStory();
        InitializeVariables();
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }
    private void InitializeVariables()
    {
        Sentence = (int)phoneStory.variablesState["sentenceNum"];
        phoneStory.ObserveVariable("sentenceNum", (arg, value) =>
        {
            Sentence = (int)value;
        });
    }
    public void SentenceNum()
    {
        foreach (GameObject text in TextMessages)
        {
            if (TextMessages[Sentence] == text)
            {
                text.SetActive(true);
            }
        }
    }
    void LoadStory()
    {
        phoneStory = new Story(inkJsonFile.text);
    }
    void Update()
    {
        SentenceNum();
        if (Input.GetButtonDown("Jump") && phoneStory.canContinue)
        {
            DisplayNextLine(phoneStory.Continue());
        }
    }
    public void DisplayNextLine(string sentence)
    {
        if (phoneStory.canContinue)
        {
            Dialogue[Sentence].text = sentence;
        }
        StoryChoices();
    }
    private void StoryChoices()
    {
        List<Choice> currentchoices = phoneStory.currentChoices;

        if (currentchoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can handle");
        }

        int index = 0;
        foreach (Choice choice in currentchoices)
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
    public void MakeChoice(int choiceIndex)
    {
        phoneStory.ChooseChoiceIndex(choiceIndex);
    }
    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }
}
