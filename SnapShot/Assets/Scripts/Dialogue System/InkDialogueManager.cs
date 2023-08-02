using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InkDialogueManager : MonoBehaviour
{
    [Header("Unity UI")]
    #region Unity Variables

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject NameTagPanel;
    public TMP_Text NameTagText;
    public GameObject characterPrefab;
    [SerializeField] private GameObject responseBox;
    [SerializeField] private RectTransform responseBoxTransform;
    [SerializeField] private GameObject responsePrefab;

    List<GameObject> tempButtons = new List<GameObject>();

    [Header("Ink Editor")]

    [SerializeField] TextAsset inkJsonFile;
    private static string _loadedState;
    [SerializeField] TextAsset loadGlobalsFile;
    public Story inkStoryScript { get; private set; }

    [Header("Game Runtime Variables")]
    private float typingSpeed = 0.03f;
    private bool submitButtonPressed = true;
    private bool canContinueToNextLine = true;
    private bool pauseDialogue;

    private Coroutine displayTextCoroutine;

    private InkDialogueObserver observer;
    private InkExternalFunctions inkExternalFunctions;
    private InkTagHandler tagHandler;
    #endregion

    #region Singleton Stuff
    public static InkDialogueManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Dialogue Managers");
        }
        instance = this;

        observer = new InkDialogueObserver();
        inkExternalFunctions = new InkExternalFunctions();
        tagHandler = new InkTagHandler();

        PauseManager.onPauseEvent += PauseDialogue;
    }
    private void OnDestroy()
    {
        PauseManager.onPauseEvent -= PauseDialogue;
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
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !pauseDialogue)
        {
            submitButtonPressed = true;
            if (canContinueToNextLine && submitButtonPressed)
            {
                submitButtonPressed = false;
                DisplayNextLine();
            }
        }
    }
    private void PauseDialogue(bool gameIsPaused)
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
        if (responseBox.activeSelf)
        {
            StartCoroutine(SelectFirstChoice());
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
    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(tempButtons[0].gameObject);
    }
    #endregion
}
