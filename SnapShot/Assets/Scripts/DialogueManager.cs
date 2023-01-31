using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [Header("C# Scripts")]
    private SceneChanger sceneSwitch;
    private playAnimation play;
    private PausingScript pause;

    [Header("Unity Hiearchy")]
    [SerializeField] private Animator charIcon;
    [SerializeField] private GameObject charPanel;
    public GameObject NameTagPanel;
    public GameObject FriendTagPanel;
    public GameObject DialoguePanel;
    public GameObject ButtonPanel;
    public GameObject Inventory;
    public GameObject Picture;
    public GameObject ArrowSprite;
    public TextMeshProUGUI dialogueText;
    //public TMP_InputField NameInput;
    public TextMeshProUGUI nameTag;
    public TextMeshProUGUI friendTag;
    private AudioSource sounds;
    private Animation bgAnims;
    public GameObject Background;

    [Header("Ink Editor")]
    [SerializeField] private Story _StoryScript;
    [SerializeField] private TextAsset _InkJsonFile;
    private Coroutine displayTextCoroutine;
    private bool canContinueToNextLine = true;
    private bool submitButtonPressed = true;
    [SerializeField] private GameObject[] choices;
    public Background[] backgrounds;
    [SerializeField] private GameObject[] triggers;
    private TextMeshProUGUI[] choicesText;
    private static string _loadedState;

    [Header("Ink Tags")]
    private const string SPEAKER_TAG = "speaker";
    private const string ICON = "icon";
    private const string SCENE = "endScene";
    private const string NOTIFICATION = "notif";
    private const string AUDIO = "PlaySound";
    private const string PLAY = "playAnimation";
    private const string END = "EndGame";

    /// Variable Observers
    private bool _photoMode;
    private string _activebgName;
    private bool _activateButton;
    private bool _cameraCheck;
    private bool _inventoryCheck;
    public bool DialoguePaused;
    private bool pictureTaken;

    public bool PhotoMode
    {
        get => _photoMode;
        private set
        {
            Debug.Log($"Updating PhotoMode value. Old value: {_photoMode}. new value: {value}");
            _photoMode = value;
        }
    }
    public bool CameraCheck
    {
        get => _cameraCheck;
        private set
        {
            Debug.Log($"Updating Camera CheckPoint. Old value: {_cameraCheck}. new value: {value}");
            _cameraCheck = value;
        }
    }
    public bool InventoryCheck
    {
        get => _inventoryCheck;
        private set
        {
            Debug.Log($"Updating Inventory CheckPoint. Old value: {_inventoryCheck}. new value: {value}");
            _inventoryCheck = value;
        }
    }
    public bool ActivateButton
    {
        get => _activateButton;
        private set
        {
            Debug.Log($"Updating Button value. Old value: {_activateButton}. new value: {value}");
            _activateButton = value;
        }
    }
    public string ActivateBackground
    {
        get => _activebgName;
        private set
        {
            Debug.Log($"Updating ActiveBackgroundName value. Old value: {_activebgName}. new value: {value}");
            _activebgName = value;
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
        pause = FindObjectOfType<PausingScript>();
    }
    private void InitializeVariables()
    {
        PhotoMode = (bool)_StoryScript.variablesState["photoMode"];
        CameraCheck = (bool)_StoryScript.variablesState["cameraCheck"];
        InventoryCheck = (bool)_StoryScript.variablesState["inventoryCheck"];
        ActivateButton = (bool)_StoryScript.variablesState["ActivateButton"];
        ActivateBackground = (string)_StoryScript.variablesState["ActivateScene"];

        _StoryScript.ObserveVariable("photoMode", (arg, value) =>
        {
            PhotoMode = (bool)value;
        });
        _StoryScript.ObserveVariable("cameraCheck", (arg, value) =>
       {
           CameraCheck = (bool)value;
       });
        _StoryScript.ObserveVariable("inventoryCheck", (arg, value) =>
       {
           InventoryCheck = (bool)value;
       });
        _StoryScript.ObserveVariable("ActivateButton", (arg, value) =>
        {
            ActivateButton = (bool)value;
        });
        _StoryScript.ObserveVariable("ActivateScene", (arg, value) =>
        {
            ActivateBackground = (string)value;
        });
    }
    /// Ink Variable Functions ///
    public void ActivateScene()
    {
        foreach (Background bg in backgrounds)
        {
            if (ActivateBackground == bg.name)
            {
                if (Background.GetComponent<Image>() == null)
                {
                    Image img = Background.AddComponent<Image>();
                    Sprite bgsprite = img.GetComponent<Sprite>();
                    bgsprite = bg.backgroundSprite;
                    img.sprite = bgsprite;
                    return;
                }
                else 
                {
                    Image img = Background.GetComponent<Image>();
                    Sprite bgsprite = img.GetComponent<Sprite>();
                    bgsprite = bg.backgroundSprite;
                    img.sprite = bgsprite;
                }
            }
        }
    }
    public void activatePhotoMode()
    {
        if (PhotoMode == true)
        {
            DialoguePanel.SetActive(false);
            NameTagPanel.SetActive(false);
            FriendTagPanel.SetActive(false);
        }
    }

    void Update()
    {
        /// Ink Variables Calls ///
        ActivateScene();
        activatePhotoMode();
        if(triggers[0].activeInHierarchy)
        {
            DialoguePanel.SetActive(false);
        }
        if (PausingScript.gameIsPaused == false)
        {
            if (Input.GetButtonDown("Jump"))
            {
                submitButtonPressed = true;
                if (DialoguePanel.activeInHierarchy)
                {
                    if (CameraCheck == true && InventoryCheck == true)
                    {
                        if (canContinueToNextLine && submitButtonPressed)
                        {
                            submitButtonPressed = false;
                            DisplayNextLine();
                        }
                    }
                }
            }
            if (Input.GetButtonDown("Fire2"))
            {
                if (CameraCheck == false)
                {
                    pictureTaken = false;
                    DialoguePaused = true;
                }
                if (pictureTaken == false)
                {
                    if (ActivateBackground == "CafePhoto")
                    {
                        triggers[1].SetActive(true);
                        pictureTaken = true;
                    }
                    else if (ActivateBackground == "ParkPhoto")
                    {
                        triggers[2].SetActive(true);
                        pictureTaken = true;
                    }
                    else if (ActivateBackground == "BirdPhotoScene")
                    {
                        triggers[3].SetActive(true);
                        pictureTaken = true;
                    }
                }
            }
            if (Input.GetButtonDown("Fire3") && ActivateBackground == "photoWall")
            {
                Inventory.SetActive(true);
            }
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
        HideStoryChoices();
        canContinueToNextLine = false;
        bool isAddingRichText = false;
        ArrowSprite.SetActive(false);
        foreach (char letter in sentence.ToCharArray())
        {
            if (submitButtonPressed)
            {
                submitButtonPressed = false;
                dialogueText.text = sentence;
                break;
            }
            if (letter == '<' || isAddingRichText)
            {
                isAddingRichText = true;
                dialogueText.text += letter;
                if (letter == '>')
                {
                    isAddingRichText = false;
                }
            }
            else
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.01f);
            }
        }
        canContinueToNextLine = true;
        StoryChoices();
        if (canContinueToNextLine && CameraCheck == true)
        {
            ArrowSprite.SetActive(true);
        }
    }
    public void DisplayNextLine()
    {
        if (PausingScript.gameIsPaused == false && !Inventory.activeInHierarchy && !triggers[1].activeInHierarchy && !Picture.activeInHierarchy)
        {
            if (_StoryScript.canContinue)
            {
                if (displayTextCoroutine != null && pause.pauseMenuUI.activeInHierarchy == false)
                {
                    StopCoroutine(displayTextCoroutine);
                }
                displayTextCoroutine = StartCoroutine(TypeSentence(_StoryScript.Continue()));
            }
            HandleTags(_StoryScript.currentTags);
        }
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
                    if (tagValue == "")
                    {
                        NameTagPanel.SetActive(false);
                    }
                    //Player Name Input: WIP
                    /*if(NameInput.text != "")
                    {
                        tagValue = NameInput.text;
                        nameTag.text = tagValue;
                        NameTagPanel.SetActive(true);
                        FriendTagPanel.SetActive(false);
                    }*/
                    else if (tagValue == "StarRail")
                    {
                        nameTag.text = tagValue;
                        NameTagPanel.SetActive(true);
                        FriendTagPanel.SetActive(false);
                    }
                    else
                    {
                        friendTag.text = tagValue;
                        FriendTagPanel.SetActive(true);
                        NameTagPanel.SetActive(false);
                    }
                    break;
                case ICON:
                    if (tagValue == "")
                    {
                        charPanel.SetActive(false);
                    }
                    else
                    {
                        charPanel.SetActive(true);
                        charIcon.Play(tagValue);
                    }
                    break;
                case NOTIFICATION:
                    foreach (GameObject trigger in triggers)
                    {
                        if (tagValue == trigger.name)
                        {
                            trigger.SetActive(true);
                        }
                    }
                    break;
                case SCENE:
                    DialoguePanel.SetActive(false);
                    NameTagPanel.SetActive(false);
                    break;
                case AUDIO:
                    FindObjectOfType<SoundManager>().Play(tagValue);
                    break;
                case END:
                    if (tagValue == "true")
                    {
                        SceneManager.LoadScene("EndCreditScene");
                    }
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
    private void HideStoryChoices()
    {
        List<Choice> currentchoices = _StoryScript.currentChoices;
        foreach (Choice choice in currentchoices)
        {
            for (int i = 0; i < choices.Length; i++)
            {
                choices[i].gameObject.SetActive(false);
            }
        }
    }
    public void MakeChoice(int choiceIndex)
    {
        _StoryScript.ChooseChoiceIndex(choiceIndex);
    }

    public void CameraCheckPoint()
    {
        CameraCheck = true;
    }
    public void InventoryCheckPoint()
    {
        InventoryCheck = true;
    }
}
