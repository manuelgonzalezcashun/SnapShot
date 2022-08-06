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
    private playAnimation play;

    [Header("Unity Hiearchy")]
    [SerializeField] private Animator charIcon;
    [SerializeField] private GameObject charPanel;
    public GameObject NameTagPanel;
    public GameObject DialoguePanel;
    public TMP_Text dialogueText;
    public TextMeshProUGUI nameTag;
    private AudioSource sounds;
    private Animation bg;

    [Header("Ink Editor")]
    [SerializeField] private Story _StoryScript;
    [SerializeField] private TextAsset _InkJsonFile;
    [SerializeField] private GameObject[] choices;
    [SerializeField] private GameObject[] backgrounds;
    private TextMeshProUGUI[] choicesText;
    [SerializeField] private GameObject PhoneTrigger;
    private static string _loadedState;
    [Header("Ink Tags")]
    private const string SPEAKER_TAG = "speaker";
    private const string ICON = "icon";
    private const string ENTER = "entersChat";
    private const string SCENE = "endScene";
    private const string NOTIFICATION = "notif";
    private const string AUDIO = "PlaySound";
    private const string PLAY = "playAnimation";

    /// Variable Observers
    private bool _deactivateScene;
    private bool _saveCharacterData;
    private bool _saveBackgroundData;
    private string _bgName;
    private string _deactivebgName;
    public bool DeactivateScene
    {
        get => _deactivateScene;
        private set
        {
            Debug.Log($"Updating deactivateScene value. Old value: {_deactivateScene}. new value: {value}");
            _deactivateScene = value;
        }
    }
    public bool SaveCharacterData
    {
        get => _saveCharacterData;
        private set
        {
            Debug.Log($"Updating saveCharacterData value. Old value: {_saveCharacterData}. new value: {value}");
            _saveCharacterData = value;
        }
    }
    public bool SaveBackgroundData
    {
        get => _saveBackgroundData;
        private set
        {
            Debug.Log($"Updating saveBackgroundData value. Old value: {_saveBackgroundData}. new value: {value}");
            _saveBackgroundData = value;
        }
    }
    public string BackgroundName
    {
        get => _bgName;
        private set
        {
            Debug.Log($"Updating BackgroundName value. Old value: {_bgName}. new value: {value}");
            _bgName = value;
        }
    }
    public string DeactivateBackgroundName
    {
        get => _deactivebgName;
        private set
        {
            Debug.Log($"Updating DeactiveBackgroundName value. Old value: {_deactivebgName}. new value: {value}");
            _deactivebgName = value;
        }
    }
    /// END LINE

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
        SaveCharacterData = (bool)_StoryScript.variablesState["saveCharacterData"];
        SaveBackgroundData = (bool)_StoryScript.variablesState["saveBackgroundData"];
        DeactivateScene = (bool)_StoryScript.variablesState["deactivateScene"];
        BackgroundName = (string)_StoryScript.variablesState["bgName"];
        DeactivateBackgroundName = (string)_StoryScript.variablesState["deactivebgName"];

        _StoryScript.ObserveVariable("saveCharacterData", (arg, value) =>
        {
            SaveCharacterData = (bool)value;
        });
        _StoryScript.ObserveVariable("saveBackgroundData", (arg, value) =>
        {
            SaveBackgroundData = (bool)value;
        });
        _StoryScript.ObserveVariable("deactivateScene", (arg, value) =>
        {
            DeactivateScene = (bool)value;
        });
        _StoryScript.ObserveVariable("bgName", (arg, value) =>
        {
            BackgroundName = (string)value;
        });
        _StoryScript.ObserveVariable("deactivebgName", (arg, value) =>
        {
            DeactivateBackgroundName = (string)value;
        });
    }
    public void sceneChange()
    {
        if (BackgroundName == "DormBackground")
        {
            backgrounds[0].SetActive(true);
        }
        if (BackgroundName == "KitchenBackground")
        {
            backgrounds[1].SetActive(true);
        }
        if (BackgroundName == "CafeBackground")
        {
            backgrounds[2].SetActive(true);
        }
    }
    public void removeBackground()
    {
        if (DeactivateScene == true)
        {
            if (DeactivateBackgroundName == "DormBackground")
            {
                backgrounds[0].SetActive(false);
            }
            else if (DeactivateBackgroundName == "KitchenBackground")
            {
                backgrounds[1].SetActive(false);
            }
            else if (DeactivateBackgroundName == "CafeBackground")
            {
                backgrounds[2].SetActive(false);
            }
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            DisplayNextLine();
        }
        if (SaveCharacterData == true)
        {
            charPanel.SetActive(true);
        }
        if (SaveBackgroundData == true)
        {
            GameObject findBG = GameObject.Find(BackgroundName);
            //findBG = backgrounds[1];
            //backgrounds[1].SetActive(true);
        }
        removeBackground();
        sceneChange();
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
                    if(tagValue == "")
                    {
                        NameTagPanel.SetActive(false);
                    }
                    else{
                        NameTagPanel.SetActive(true);
                    }
                    break;
                case ICON:
                    charIcon.Play(tagValue);
                    break;
                case NOTIFICATION:
                    PhoneTrigger.SetActive(true);
                    break;
                case SCENE:
                    DialoguePanel.SetActive(false);
                    NameTagPanel.SetActive(false);
                    break;
                case PLAY:
                    GameObject FindAnim = GameObject.Find(tagValue);
                    bg = FindAnim.GetComponent<Animation>();
                    bg.Play();
                    Debug.Log(FindAnim.name);
                    break;
                case AUDIO:
                    GameObject FindSound = GameObject.Find(tagValue);
                    sounds = FindSound.GetComponent<AudioSource>();
                    sounds.Play();
                    Debug.Log(FindSound.name);
                    break;
                case ENTER:
                    charPanel.SetActive(true);
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
