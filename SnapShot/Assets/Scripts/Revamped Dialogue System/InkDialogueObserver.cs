using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkDialogueObserver
{
    public Dictionary<string, Ink.Runtime.Object> variables { get; private set; }
    public InkDialogueObserver(TextAsset loadGlobalsFile)
    {
        Story globalVariablesStory = new Story(loadGlobalsFile.text);
        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string name in globalVariablesStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
        }
    }
    public void StartListening(Story story)
    {
        story.variablesState.variableChangedEvent += VariableChanged;
    }
    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }
    private void VariableChanged(string name, Ink.Runtime.Object value)
    {
        if (variables.ContainsKey(name))
        {
            variables.Remove(name);
            variables.Add(name, value);
        }
    }
}
