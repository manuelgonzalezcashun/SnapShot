using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using Ink.Runtime;

public class InkDialogueManager : MonoBehaviour
{
    public static event Action<Scenes> storyEnded;

    #region Dialogue System UI
    [Header("Unity UI")]

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject NameTagPanel;
    public TMP_Text NameTagText;
    public GameObject characterPrefab;
    [SerializeField] private GameObject responseBox;
    [SerializeField] private RectTransform responseBoxTransform;
    [SerializeField] private GameObject responsePrefab;
    [SerializeField] private GameObject arrow;

    [SerializeField] private Scenes endCreditScene;
    List<GameObject> tempButtons = new List<GameObject>();
    #endregion

    #region Ink Files
    [Header("Ink Editor")]

    [SerializeField] TextAsset inkJsonFile;
    private static string _loadedState;
    [SerializeField] TextAsset loadGlobalsFile;
    public Story inkStoryScript { get; private set; }
    #endregion

    #region Runtime Game Variables
    private float typingSpeed = 0.03f;
    private bool submitButtonPressed = true;
    private bool canContinueToNextLine = true;
    private bool pauseDialogue;

    private Coroutine displayTextCoroutine;
    #endregion

    #region Other Dialogue Scripts
    private InkDialogueObserver observer;
    private InkExternalFunctions inkExternalFunctions;
    private InkTagHandler tagHandler;
    #endregion

    #region Player Input
    private PlayerInput playerInput;
    private InputAction continueAction;
    private string currentInput;

    private const string input_KEYBOARD = "space";
    private const string input_MOUSE = "leftButton";
    private const string input_GAMEPAD = "buttonSouth";


    #endregion

    #region Singleton Stuff
    public static InkDialogueManager instance;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        continueAction = playerInput.actions["Continue Dialogue"];

        if (instance != null)
        {
            Debug.LogError("Found more than one Dialogue Managers");
        }
        instance = this;

        observer = new InkDialogueObserver();
        inkExternalFunctions = new InkExternalFunctions();
        tagHandler = new InkTagHandler();
    }
    private void Update()
    {
        if (canContinueToNextLine)
        {
            arrow.SetActive(true);
        }
        else
        {
            arrow.SetActive(false);
        }
    }
    private void OnEnable()
    {
        InventoryUI.onShowInventory += PauseDialogue;
        PauseManager.onPauseEvent += PauseDialogue;
        continueAction.performed += ContinueDialogue;
        CameraScript.pauseDialogueForCamera += PausePlayerInput;
        Picture.pictureCollected += ResumePlayerInput;
    }
    private void OnDisable()
    {
        InventoryUI.onShowInventory -= PauseDialogue;
        PauseManager.onPauseEvent -= PauseDialogue;
        continueAction.performed -= ContinueDialogue;
        CameraScript.pauseDialogueForCamera -= PausePlayerInput;
        Picture.pictureCollected -= ResumePlayerInput;
    }
    # endregion
    void Start()
    {
        LoadStory();
    }
    void LoadStory()
    {
        inkStoryScript = new Story(inkJsonFile.text);
        if (!string.IsNullOrEmpty(_loadedState))
        {
            inkStoryScript?.state?.LoadJson(_loadedState);
            _loadedState = null;
        }
        observer.ObserveInkVariables(inkStoryScript);
        inkExternalFunctions.Bind(inkStoryScript);
        DisplayNextLine();
    }

    private void ContinueDialogue(InputAction.CallbackContext ctx)
    {
        var currentControl = ctx.action.GetBindingForControl(ctx.action.activeControl).Value;
        currentInput = currentControl.path.Split('/')[1];

        if (!pauseDialogue)
        {
            submitButtonPressed = true;
            if (canContinueToNextLine && submitButtonPressed)
            {
                submitButtonPressed = false;
                DisplayNextLine();
            }
        }
    }
    private void ResumePlayerInput()
    {
        playerInput.enabled = true;
    }
    private void PausePlayerInput()
    {
        playerInput.enabled = false;
    }
    public void PauseDialogue(bool gameIsPaused)
    {
        pauseDialogue = gameIsPaused;
    }
    public void DisplayNextLine()
    {
        if (inkStoryScript.canContinue)
        {
            canContinueToNextLine = true;
            if (displayTextCoroutine != null)
            {
                StopCoroutine(displayTextCoroutine);
            }
            displayTextCoroutine = StartCoroutine(TypeSentence(inkStoryScript.Continue()));
        }
        else if (!inkStoryScript.canContinue)
        {
            canContinueToNextLine = false;
            EndStory();
        }

        tagHandler.HandleTags(inkStoryScript.currentTags);
    }
    private void EndStory()
    {
        canContinueToNextLine = false;
        NameTagPanel.SetActive(false);
        dialogueText.text = "";
        dialogueBox.SetActive(false);
        inkExternalFunctions.Unbind(inkStoryScript);

        storyEnded?.Invoke(endCreditScene);

    }
    # region Story State
    public string GetStoryState()
    {
        return inkStoryScript.state.ToJson();
    }

    public static void LoadState(string state)
    {
        _loadedState = state;
    }
    #endregion

    # region Typewriter Effect
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = sentence;
        dialogueText.maxVisibleCharacters = 0;
        canContinueToNextLine = false;
        bool isAddingRichText = false;
        foreach (char letter in sentence.ToCharArray())
        {
            if (submitButtonPressed)
            {
                submitButtonPressed = false;
                dialogueText.maxVisibleCharacters = sentence.Length;
                break;
            }
            if (letter == '<' || isAddingRichText)
            {
                isAddingRichText = true;
                if (letter == '>')
                {
                    isAddingRichText = false;
                }
            }
            else
            {
                dialogueText.maxVisibleCharacters++;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
        StoryChoices();
        if (!responseBox.activeSelf) canContinueToNextLine = true;
    }
    #endregion
    #region Responses
    private void StoryChoices()
    {
        List<Choice> currentResponses = inkStoryScript.currentChoices;
        int index = 0;
        foreach (Choice response in currentResponses)
        {
            responseBox.SetActive(true);
            GameObject responseButton = Instantiate(responsePrefab, responseBoxTransform);
            responseButton.GetComponentInChildren<TMP_Text>().text = response.text;
            responseButton.GetComponent<Button>().onClick.AddListener(() => MakeChoice(response.index));
            tempButtons.Add(responseButton);
            index++;
        }

        if (responseBox.activeSelf && currentInput == input_GAMEPAD)
        {
            SelectFirstChoice();
        }
    }
    void MakeChoice(int choiceIndex)
    {
        responseBox.SetActive(false);
        inkStoryScript.ChooseChoiceIndex(choiceIndex);
        foreach (GameObject button in tempButtons)
        {
            Destroy(button);
        }
        tempButtons.Clear();
        canContinueToNextLine = true;
        DisplayNextLine();
    }
    private void SelectFirstChoice()
    {
        tempButtons[0].GetComponent<Button>().Select();
    }
    #endregion
}
