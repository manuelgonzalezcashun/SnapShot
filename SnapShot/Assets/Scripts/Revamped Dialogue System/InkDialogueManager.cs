using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Ink.UnityIntegration;

public class InkDialogueManager : MonoBehaviour
{
    #region Unity Variables
    [Header("Unity UI")]
    [SerializeField] GameObject dialogueBox;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] GameObject NameTagPanel;
    [SerializeField] TMP_Text NameTagText;
    [SerializeField] GameObject responseBox;
    [SerializeField] RectTransform responseBoxTransform;
    [SerializeField] GameObject responsePrefab;
    List<GameObject> tempButtons = new List<GameObject>();

    [Header("Ink Editor")]
    [SerializeField] Story inkStoryScript;
    [SerializeField] TextAsset inkJsonFile;
    private static string _loadedState;
    [SerializeField] InkFile globalsInkFile;

    [Header("Game Runtime Variables")]
    [SerializeField] private float typingSpeed = 0.04f;
    private bool submitButtonPressed = true;
    private bool canContinueToNextLine = true;
    private Coroutine displayTextCoroutine;
    private InkDialogueObserver dialogueObserver;
    #endregion
    # region Ink Tags
    private const string SPEAKER_TAG = "speaker";
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
    }

    public void DisplayNextLine()
    {
        if (inkStoryScript.canContinue)
        {
            if (displayTextCoroutine != null)
            {
                StopCoroutine(displayTextCoroutine);
            }
            displayTextCoroutine = StartCoroutine(TypeSentence(inkStoryScript.Continue()));
        }
        else if (!inkStoryScript.canContinue)
        {
            NameTagPanel.SetActive(false);
            dialogueText.text = "";
            dialogueObserver.StopListening(inkStoryScript);
        }
        HandleTags(inkStoryScript.currentTags);
    }
    #region Ink Tag Handler
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
                        NameTagPanel.SetActive(true);
                        NameTagText.text = tagValue;
                    }
                    break;
                default:
                    Debug.LogWarning("Tag came in but it is currently being handled: " + tag);
                    break;
            }
        }
    }
    #endregion
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
