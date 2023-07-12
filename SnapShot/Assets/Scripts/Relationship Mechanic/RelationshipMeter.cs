using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RelationshipMeter : MonoBehaviour
{
    [field: SerializeField] public GameObject relationship_meter { get; private set; }
    [SerializeField] GameObject[] meter_bars;
    public int inkRelationshipScore { get; private set; }
    private int relationshipScore;
    private int maxRelationshipScore = 5;

    void Update()
    {
        inkRelationshipScore = (int)InkDialogueManager.instance.inkStoryScript.variablesState["relationship_score"];

        #region Relationship Score Observer

        if (inkRelationshipScore >= maxRelationshipScore)
        {
            inkRelationshipScore = maxRelationshipScore;
            if (inkRelationshipScore != relationshipScore)
            {
                SnapshotEvents.instance.relScoreChange.Invoke();
                relationshipScore = inkRelationshipScore;
            }
        }
        else if (inkRelationshipScore <= 0)
        {
            inkRelationshipScore = 0;
            if (inkRelationshipScore != relationshipScore)
            {
                SnapshotEvents.instance.relScoreChange.Invoke();
                relationshipScore = inkRelationshipScore;
            }
        }
        else
        {
            if (inkRelationshipScore != relationshipScore)
            {
                SnapshotEvents.instance.relScoreChange.Invoke();
                relationshipScore = inkRelationshipScore;
            }
        }

        #endregion

        RelationshipMeterFiller();
    }
    void RelationshipMeterFiller()
    {
        for (int i = 0; i < meter_bars.Length; i++)
        {
            meter_bars[i].SetActive(!DisplayScorePoints(relationshipScore, i));
        }
    }
    bool DisplayScorePoints(int _relationshipScore, int pointNumber)
    {
        return pointNumber >= _relationshipScore;
    }
}