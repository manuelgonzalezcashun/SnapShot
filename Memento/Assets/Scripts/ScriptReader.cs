using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using Ink.UnityIntegration;
using TMPro;
public class ScriptReader : MonoBehaviour
{
    [Header("Script")]
    private static ScriptReader instance;
    private SceneChanger sceneSwitch;


    [Header("Unity Hiearchy")]
    [SerializeField] private Animator charIcon;
    private DialogueVariables dialogueVariables;
    public GameObject NameTagPanel;
    public GameObject DialoguePanel;
    public TMP_Text dialogueText;
    public TextMeshProUGUI nameTag;
    public bool boolCheck;

    [Header("Ink Editor")]
    [SerializeField] private Story _StoryScript;
    [SerializeField] private InkFile globalsInkFile;
    [SerializeField] private TextAsset _InkJsonFile;
    private const string SPEAKER_TAG = "speaker";
    private const string ICON = "icon";
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    //[SerializeField] AudioSource m_AudioSRC;


    [SerializeField] private GridLayoutGroup choiceHolder;
    [SerializeField] private Button choiceBasePrefab;
    [SerializeField] private GameObject PhoneTrigger;

    private void Awake()
    {
        instance = this;
        dialogueVariables = new DialogueVariables(globalsInkFile.filePath);
    }
    public static ScriptReader GetInstance()
    {
        return instance;
    }
    void Start()
    {
        LoadStory();
        sceneSwitch = new SceneChanger();
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
        if (Input.GetButtonDown("Fire1"))
        {
            DisplayNextLine();
            //m_AudioSRC.Play();
        }
    }

    void LoadStory()
    {
        _StoryScript = new Story(_InkJsonFile.text);
        dialogueVariables.StartListening(_StoryScript);
        _StoryScript.BindExternalFunction("TEXT", (bool txt) => ShowObject(txt));
        _StoryScript.BindExternalFunction("VAR", (bool didTextPlay) => InkStoryEnd(didTextPlay));
        _StoryScript.BindExternalFunction("HIDE", (bool HidePanel) => hidePanel(HidePanel));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        yield return null;
    }

    public void DisplayNextLine()
    {
        if (_StoryScript.canContinue)
        {
            string text = _StoryScript.Continue();
            text = text?.Trim();
            dialogueText.text = text;
            StartCoroutine(TypeSentence(text));
            DisplayChoices();
            StoryChoices();
        }
        else if (_StoryScript.currentChoices.Count > 0)
        {
            dialogueVariables.StopListening(_StoryScript);
        }
        HandleTags(_StoryScript.currentTags);
    }
    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink Variable was found to be null: " + variableName);
        }
        return variableValue;
    }
    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropritely parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    nameTag.text = tagValue;
                    break;
                case ICON:
                    charIcon.Play(tagValue);
                    break;
                default:
                    Debug.LogWarning("Tag came in but it is currently being handled: " + tag);
                    break;
            }
        }
    }
    private void ShowObject(bool txt)
    {
        if (txt == true)
        {
            PhoneTrigger.SetActive(true);
        }
    }
    private void InkStoryEnd(bool didTextPlay)
    {
        if (didTextPlay == true)
        {
            sceneSwitch.LoadScene();
        }
    }
    private void hidePanel(bool HidePanel)
    {
        if (HidePanel == true)
        {
            DialoguePanel.SetActive(false);
            NameTagPanel.SetActive(false);
        }
    }
    private void DisplayChoices()
    {
        if (choiceHolder.GetComponentsInChildren<Button>().Length > 0) return;

        for (int i = 0; i < _StoryScript.currentChoices.Count; i++)
        {
            var choice = _StoryScript.currentChoices[i];
            var button = CreateChoiceButton(choice.text);
            button.onClick.AddListener(() => OnClickChoiceButton(choice));
        }
    }
    private void StoryChoices()
    {
        List<Choice> currentchoices = _StoryScript.currentChoices;

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
    }
    public void MakeChoice(int choiceIndex)
    {
        _StoryScript.ChooseChoiceIndex(choiceIndex);
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
            foreach (var button in choiceHolder.GetComponentsInChildren<Button>())
            {
                Destroy(button.gameObject);
            }
        }
    }
}


/// New Button Script
/* private void DisplayChoices()
 {
     List<Choice> currentchoices = _StoryScript.currentChoices;

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
 }
     public void MakeChoice(int choiceIndex)
 {
     _StoryScript.ChooseChoiceIndex(choiceIndex);
 } */