using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
public class ScriptReader : MonoBehaviour
{
    [SerializeField] private TextAsset _InkJsonFile;
    [SerializeField] private Story _StoryScript;

    public TMP_Text dialogueBox;
    public TMP_Text nameTag;
    public bool boolCheck;

    public Image characterIcon;

    [SerializeField] private GridLayoutGroup choiceHolder;
    [SerializeField] private Button choiceBasePrefab;
    private SceneChanger sceneSwitch;
    //[SerializeField] AudioSource m_AudioSRC;
        void Start()
    {
        sceneSwitch = new SceneChanger();
        LoadStory();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
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
        _StoryScript.BindExternalFunction("Name", (string charName) => ChangeName(charName));
        _StoryScript.BindExternalFunction("Icon", (string charName) => CharacterIcon(charName));
        _StoryScript.BindExternalFunction("BOOL", (bool isPlaying) => isPlayingCheck(isPlaying));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueBox.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueBox.text += letter;
            yield return null;
        }
        yield return null;
    }

    public void DisplayNextLine()
    {
        //bool boolCheck = true;
        if (_StoryScript.canContinue)
        {
            string text = _StoryScript.Continue();
            text = text?.Trim();
            dialogueBox.text = text;
            StartCoroutine(TypeSentence(text));
        }
        else if (_StoryScript.currentChoices.Count > 0)
        {
            DisplayChoices();
        }
        else if (_StoryScript.currentChoices.Count == 0)
        {
            if (boolCheck == true){
                sceneSwitch.LoadScene();
            }
        }
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
    public void isPlayingCheck(bool isPlaying) {
        boolCheck = isPlaying; 
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
