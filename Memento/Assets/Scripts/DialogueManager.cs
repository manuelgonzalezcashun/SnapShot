using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    [Header("Script")]
    private SceneChanger sceneSwitch;

    [Header("Unity Hiearchy")]
    [SerializeField] private Animator charIcon;
    [SerializeField] private GameObject charPanel;
    public GameObject NameTagPanel;
    public GameObject DialoguePanel;
    public TMP_Text dialogueText;
    public TextMeshProUGUI nameTag;

    [Header("Ink Editor")]
    [SerializeField] private Story _StoryScript;
    [SerializeField] private TextAsset _InkJsonFile;
    private const string SPEAKER_TAG = "speaker";
    private const string ICON = "icon";
    private const string ENTER = "entersChat";
    private const string SCENE = "endScene";
    private const string NOTIFICATION = "notif";
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    [SerializeField] private GameObject PhoneTrigger;
    private static string _loadedState;
    /// Variable Observers
   // private bool _notification;
    // private bool _endScene;
    /*public bool Notification
    {
        get => _notification;
        private set
        {
            Debug.Log($"Updating Notification value. Old value: {_notification}. new value: {value}");
            _notification = value;
            if (value == true)
            {
                PhoneTrigger.SetActive(true);
            }
            else
            {
                PhoneTrigger.SetActive(false);
            }
        }

    }
    public bool EndScene
    {
        get => _endScene;
        private set
        {
            Debug.Log($"Updating EndScene value. Old value: {_endScene}. new value: {value}");
            _endScene = value;
        }
    } */
    /// END LINE

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
        if (Input.GetButtonDown("Jump"))
        {
            DisplayNextLine();
        }
    }
    void LoadStory()
    {
        _StoryScript = new Story(_InkJsonFile.text);
        if (!string.IsNullOrEmpty(_loadedState))
        {
            _StoryScript?.state?.LoadJson(_loadedState);
            _loadedState = null;
        }
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
            StoryChoices();
        }
        HandleTags(_StoryScript.currentTags);
    }
    public string GetStoryState()
    {
        return _StoryScript.state.ToJson();
    }

    public static void LoadState(string state)
    {
        _loadedState = state;
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
                case ENTER:
                    charPanel.SetActive(true);
                    break;
                case NOTIFICATION:
                    PhoneTrigger.SetActive(true);
                    break;
                case SCENE:
                    DialoguePanel.SetActive(false);
                    NameTagPanel.SetActive(false);
                    break;
                default:
                    Debug.LogWarning("Tag came in but it is currently being handled: " + tag);
                    break;
            }
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

}


    /*
     private void InitializeVariables()
     {
         Notification = (bool)_StoryScript.variablesState["notification"];
         EndScene = (bool)_StoryScript.variablesState["endScene"];
         Debug.Log($"Logging ink variables. Notification: {Notification}");
         Debug.Log($"Logging ink variables. EndScene: {EndScene}");

         _StoryScript.ObserveVariable("notification", (arg, value) =>
         {
             Notification = (bool)value;
         });
         _StoryScript.ObserveVariable("endScene", (arg, value) =>
         {
             EndScene = (bool)value;
         });
     }
 */
