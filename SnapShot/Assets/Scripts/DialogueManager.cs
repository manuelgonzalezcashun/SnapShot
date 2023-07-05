using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [Header("C# Scripts")]
    private playAnimation play;
    [SerializeField] private bool stopAudio;
    [SerializeField] private float typingSpeed = 0.04f;
    [SerializeField] private int frequecy = 2;

    [Header("Unity Hiearchy")]
    [SerializeField] private GameObject characterSprite;
    [SerializeField] GameObject phone;

    public GameObject NameTagPanel;
    public GameObject FriendTagPanel;
    public GameObject DialoguePanel;
    public GameObject ButtonPanel;
    public GameObject Inventory;
    public GameObject ArrowSprite;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameTag;
    public TextMeshProUGUI friendTag;

    [Header("Ink Editor")]
    [SerializeField] private Story _StoryScript;
    [SerializeField] private TextAsset _InkJsonFile;
    private Coroutine displayTextCoroutine;
    private bool canContinueToNextLine = true;
    private bool submitButtonPressed = true;
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    private static string _loadedState;

    # region Ink Tags
    private const string SPEAKER_TAG = "speaker";
    private const string ICON = "icon";
    private const string SCENE = "endScene";
    private const string AUDIO = "PlaySound";
    private const string PLAY = "playAnimation";
    private const string END = "EndGame";
    private const string PHONE = "phone";
    # endregion

    # region Variable Observers
    private bool _photoMode;
    private string _activebgName;
    private bool _cameraCheck;
    private bool _inventoryCheck;
    private string pictureName;
    #endregion

    public bool DialoguePaused;

    public static DialogueManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Dialogue Managers");
        }
        instance = this;
    }
    public bool PhotoMode
    {
        get => _photoMode;
        private set
        {
            _photoMode = value;
        }
    }
    public bool CameraCheck
    {
        get => _cameraCheck;
        private set
        {
            _cameraCheck = value;
        }
    }
    public bool InventoryCheck
    {
        get => _inventoryCheck;
        private set
        {
            _inventoryCheck = value;
        }
    }
    public string ActivateBackground
    {
        get => _activebgName;
        private set
        {
            _activebgName = value;
        }
    }
    public string PictureName
    {
        get => pictureName;
        private set
        {
            pictureName = value;
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
        PhotoMode = (bool)_StoryScript.variablesState["photoMode"];
        CameraCheck = (bool)_StoryScript.variablesState["cameraCheck"];
        InventoryCheck = (bool)_StoryScript.variablesState["inventoryCheck"];
        ActivateBackground = (string)_StoryScript.variablesState["ActivateScene"];
        PictureName = (string)_StoryScript.variablesState["PictureName"];

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
        _StoryScript.ObserveVariable("ActivateScene", (arg, value) =>
        {
            ActivateBackground = (string)value;
        });
        _StoryScript.ObserveVariable("PictureName", (arg, value) =>
        {
            PictureName = (string)value;
        });
    }
    /// Ink Variable Functions ///
    public void ActivateScene()
    {
        FindObjectOfType<BackgroundManager>().SetBackground(ActivateBackground);
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
    void PausingDialogue()
    {
        if (!CameraCheck || !InventoryCheck || Inventory.activeInHierarchy)
        {
            DialoguePaused = true;
        }
        else
        {
            DialoguePaused = false;
        }
    }
    void Update()
    {
        if (PauseMenu.gameIsPaused == true)
            return;
        /// Ink Variables Calls ///
        ActivateScene();
        activatePhotoMode();
        PausingDialogue();
        if (Input.GetButtonDown("Jump"))
        {
            submitButtonPressed = true;
            if (canContinueToNextLine && submitButtonPressed)
            {
                submitButtonPressed = false;
                DisplayNextLine();
            }
        }
        PictureCapture.instance.LoadTrigger();


        /// ADD TO INVENTORY SCRIPT WHEN INVENTORY GETS ADDED !
        if (Input.GetButtonDown("Fire3") && ActivateBackground == "photoWall")
        {
            Inventory.SetActive(true);
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
        dialogueText.maxVisibleCharacters = 0;
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
                dialogueText.maxVisibleCharacters = sentence.Length;
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
                dialogueText.maxVisibleCharacters++;
                //TypingSound(dialogueText.maxVisibleCharacters);
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
        StoryChoices();
        canContinueToNextLine = true;
        if (canContinueToNextLine && CameraCheck == true)
        {
            ArrowSprite.SetActive(true);
        }
    }
    private void TypingSound(int visibleCharacters)
    {
        if (visibleCharacters % frequecy == 0)
        {
            if (stopAudio)
            {
                FindObjectOfType<SoundManager>().StopAudio("TypingSound");
            }
            FindObjectOfType<SoundManager>().PlayOneShot("TypingSound");
        }
    }
    public void DisplayNextLine()
    {
        if (DialoguePaused || !DialoguePanel.activeInHierarchy)
            return;
        if (_StoryScript.canContinue)
        {
            if (displayTextCoroutine != null)
            {
                StopCoroutine(displayTextCoroutine);
            }
            displayTextCoroutine = StartCoroutine(TypeSentence(_StoryScript.Continue()));
        }
        HandleTags(_StoryScript.currentTags);
    }

    # region Story State
    public string GetStoryState()
    {
        return _StoryScript.state.ToJson();
    }

    public static void LoadState(string state)
    {
        _loadedState = state;
    }
    #endregion

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
                    if (tagValue != null)
                    {
                        //friendTag.text = Character.instance.character.name;
                        FriendTagPanel.SetActive(true);
                        NameTagPanel.SetActive(false);
                    }
                    else if (tagValue == "Sam")
                    {
                        nameTag.text = tagValue;
                        NameTagPanel.SetActive(true);
                        FriendTagPanel.SetActive(false);
                    }
                    else
                    {
                        NameTagPanel.SetActive(false);
                    }
                    break;
                case ICON:
                    if (tagValue == "")
                    {
                        characterSprite.SetActive(false);
                    }
                    else
                    {
                        characterSprite.SetActive(true);
                        //Character.instance.CharacterExpressions(tagValue);
                    }
                    break;
                case PHONE:
                    if (tagValue == "text")
                        phone.SetActive(true);
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

    # region Choice UI
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
        StartCoroutine(SelectFirstChoice());
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
    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    #endregion

    public void CameraCheckPoint()
    {
        CameraCheck = true;
    }
    public void InventoryCheckPoint()
    {
        InventoryCheck = true;
    }
}