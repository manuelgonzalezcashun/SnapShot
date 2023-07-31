using UnityEngine;
using System;
using Ink.Runtime;

public class InkDialogueObserver
{
    public static event Action<int> UpdateRelationshipScore;

    private int _relationshipScore;
    public int RelationshipScore
    {
        get => _relationshipScore; private set => _relationshipScore = value;
    }
    public void ObserveInkVariables(Story story)
    {
        RelationshipScore = (int)story.variablesState["relationship_score"];
        story.ObserveVariable("relationship_score", (arg, value) =>
        {
            RelationshipScore = (int)value;

            if (RelationshipScore > 5) RelationshipScore = 5;
            else if (RelationshipScore < -5) RelationshipScore = -5;

            UpdateRelationshipScore?.Invoke(RelationshipScore);
        });
    }
}
