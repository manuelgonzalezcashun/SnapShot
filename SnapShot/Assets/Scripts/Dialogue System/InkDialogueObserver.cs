using UnityEngine;
using System;
using Ink.Runtime;

public class InkDialogueObserver
{
    public static event Action<int> UpdateRelationshipScore;
    public static event Action<bool> UpdateShowCharacters;

    private int _relationshipScore;
    private bool _showCharacters;
    public int RelationshipScore
    {
        get => _relationshipScore; private set => _relationshipScore = value;
    }
    public bool ShowCharacters
    {
        get => _showCharacters; private set => _showCharacters = value;
    }
    public void ObserveInkVariables(Story story)
    {
        RelationshipScore = (int)story.variablesState["relationship_score"];
        ShowCharacters = (bool)story.variablesState["show_characters"];

        story.ObserveVariable("relationship_score", (arg, value) =>
        {
            RelationshipScore = (int)value;

            if (RelationshipScore > 5) RelationshipScore = 5;
            else if (RelationshipScore < -5) RelationshipScore = -5;

            UpdateRelationshipScore?.Invoke(RelationshipScore);
        });

        story.ObserveVariable("show_characters", (arg, value) =>
        {
            ShowCharacters = (bool)value;

            UpdateShowCharacters?.Invoke(ShowCharacters);
        });
    }
}
