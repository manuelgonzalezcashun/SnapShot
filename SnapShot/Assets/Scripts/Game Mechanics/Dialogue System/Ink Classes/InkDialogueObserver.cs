using UnityEngine;
using System;
using Ink.Runtime;

public class InkDialogueObserver
{
    public static event Action<int> onReachedMaxScore;
    public static event Action<int> UpdateRelationshipScore;
    public static event Action<bool> UpdateShowCharacters;
    public static event Action<string> CharacterLeaveScene;

    private int maxScore = 5;
    private int minScore = -5;

    private int _relationshipScore;
    private bool _showCharacters;
    private string _characterLeave;
    public int RelationshipScore
    {
        get => _relationshipScore; private set => _relationshipScore = value;
    }
    public bool ShowCharacters
    {
        get => _showCharacters; private set => _showCharacters = value;
    }
    public string CharacterLeave
    {
        get => _characterLeave; private set => _characterLeave = value;
    }
    public void ObserveInkVariables(Story story)
    {
        RelationshipScore = (int)story.variablesState["relationship_score"];
        ShowCharacters = (bool)story.variablesState["show_characters"];
        CharacterLeave = (string)story.variablesState["char_leave"];

        story.ObserveVariable("relationship_score", (arg, value) =>
        {
            RelationshipScore = (int)value;

            if (RelationshipScore >= maxScore)
            {
                RelationshipScore = maxScore;
                onReachedMaxScore?.Invoke(RelationshipScore);
            }
            else if (RelationshipScore < minScore) RelationshipScore = minScore;

            UpdateRelationshipScore?.Invoke(RelationshipScore);
        });

        story.ObserveVariable("show_characters", (arg, value) =>
        {
            ShowCharacters = (bool)value;
            UpdateShowCharacters?.Invoke(ShowCharacters);
        });
        story.ObserveVariable("char_leave", (arg, value) =>
        {
            CharacterLeave = (string)value;
            CharacterLeaveScene?.Invoke(CharacterLeave);
        });
    }
}
