using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using Ink.UnityIntegration;
public class ScriptReader : MonoBehaviour
{
    private static ScriptReader instance;
    [SerializeField] private TextAsset _InkJsonFile;
    [SerializeField] private Story _StoryScript;
    [SerializeField] private InkFile globalsInkFile;
    private DialogueVariables dialogueVariables;

    public TMP_Text dialogueText;
    public TMP_Text nameTag;
    public bool boolCheck;

    public Image characterIcon;

    [SerializeField] private GridLayoutGroup choiceHolder;
    [SerializeField] private Button choiceBasePrefab;
    [SerializeField] private GameObject PhoneTrigger;
    private SceneChanger sceneSwitch;
    //[SerializeField] AudioSource m_AudioSRC;
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
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            DisplayNextLine();
            //m_AudioSRC.Play();
        }
        //Tests for SceneChanger Script
        /*if (Input.GetKeyDown(KeyCode.S))
        {
            sceneSwitch.LoadScene();
        }*/
    }

    void LoadStory()
    {
        _StoryScript = new Story(_InkJsonFile.text);
        dialogueVariables.StartListening(_StoryScript);
        _StoryScript.BindExternalFunction("Name", (string charName) => ChangeName(charName));
        _StoryScript.BindExternalFunction("Icon", (string charName) => CharacterIcon(charName));
        _StoryScript.BindExternalFunction("TEXT", (bool txt) => ShowObject(txt));
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
        }
        else if (_StoryScript.currentChoices.Count > 0)
        {
            DisplayChoices();
            dialogueVariables.StopListening(_StoryScript);
        }
    }
    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink Variable was found to be null: " +variableName);
        }
        return variableValue;
    }

    public void ChangeName(string name)
    {
        string SpeakerName = name;

        nameTag.text = SpeakerName;
    }

    public void CharacterIcon (string name)
    {
        var charIcon = Resources.Load<Sprite>("charactericons/"+name);
        characterIcon.sprite = charIcon;
    }
        private void ShowObject(bool txt)
    {
        if (txt == true)
        {
            PhoneTrigger.SetActive(true);
        }
    }


    private void DisplayChoices()
    {
        if (choiceHolder.GetComponentsInChildren<Button>().Length > 0) return; 

        for (int i = 0; i < _StoryScript.currentChoices.Count; i++)
        {
            var choice = _StoryScript.currentChoices[i];
            var button = CreateChoiceButton(choice.text);
            button.onClick.AddListener(()=> OnClickChoiceButton(choice));
        }
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
            foreach(var button in choiceHolder.GetComponentsInChildren<Button>())
            {
                Destroy(button.gameObject);
            }
        }
    }
}
