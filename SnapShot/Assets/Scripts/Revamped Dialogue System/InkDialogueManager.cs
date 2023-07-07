using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Ink.UnityIntegration;
using UnityEngine.Events;

public class InkDialogueManager : MonoBehaviour
{
    [Header("Unity UI")]
    #region Unity Variables

    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public GameObject NameTagPanel;
    public TMP_Text NameTagText;
    public GameObject characterPrefab;
    public GameObject responseBox;
    public RectTransform responseBoxTransform;
    public GameObject responsePrefab;
    List<GameObject> tempButtons = new List<GameObject>();

    [Header("Ink Editor")]

    [SerializeField] TextAsset inkJsonFile;
    private static string _loadedState;
    [SerializeField] InkFile globalsInkFile;
    public Story inkStoryScript { get; private set; }

    [Header("Game Runtime Variables")]
    private float typingSpeed = 0.03f;
    private bool submitButtonPressed = true;
    private bool canContinueToNextLine = true;
    private Coroutine displayTextCoroutine;
    private InkDialogueObserver dialogueObserver;
    private InkExternalFunctions inkExternalFunctions;
    private InkTagHandler tagHandler;
    #endregion
    # region Ink Tags
    private const string SPEAKER_TAG = "speaker";
    private const string BACKGROUND_TAG = "background";
    private const string ICON_TAG = "icon";
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

        dialogueObserver = new InkDialogueObserver(globalsInkFile.filePath);
        inkExternalFunctions = new InkExternalFunctions();
        tagHandler = new InkTagHandler();
    }
    # endregion
    void Start()
    {
        LoadStory();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            submitButtonPressed = true;
            if (canContinueToNextLine && submitButtonPressed)
            {
                submitButtonPressed = false;
                DisplayNextLine();
            }
        }
    }
    void LoadStory()
    {
        inkStoryScript = new Story(inkJsonFile.text);
        if (!string.IsNullOrEmpty(_loadedState))
        {
            inkStoryScript?.state?.LoadJson(_loadedState);
            _loadedState = null;
        }

        dialogueObserver.StartListening(inkStoryScript);
        inkExternalFunctions.Bind(inkStoryScript);
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
        NameTagPanel.SetActive(false);
        dialogueText.text = "";
        dialogueBox.SetActive(false);

        inkExternalFunctions.Unbind(inkStoryScript);
        dialogueObserver.StopListening(inkStoryScript);
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
        dialogueText.text = "";
        dialogueText.maxVisibleCharacters = 0;
        canContinueToNextLine = false;
        bool isAddingRichText = false;
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
                dialogueText.text += letter;
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
        if (responseBox.activeSelf) StartCoroutine(SelectFirstChoice());
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
    # endregion
    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueObserver.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink Variable is null: " + variableName);
        }
        return variableValue;
    }
}
