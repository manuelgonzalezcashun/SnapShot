using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipMeter : MonoBehaviour
{
    [field: SerializeField] public GameObject relationship_meter { get; private set; }
    [SerializeField] GameObject[] meter_bars;
    public int inkRelationshipScore { get; private set; }
    private int relationshipScore;
    private int maxRelationshipScore = 5;
    void Update()
    {
        inkRelationshipTracker();
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
    void inkRelationshipTracker()
    {
        inkRelationshipScore = (int)InkDialogueManager.instance.inkStoryScript.variablesState["relationship_score"];

        #region Relationship Score Observer
        if (inkRelationshipScore >= maxRelationshipScore)
        {
            inkRelationshipScore = maxRelationshipScore;
        }
        else if (inkRelationshipScore <= 0)
        {
            inkRelationshipScore = 0;
        }

        if (relationshipScore > inkRelationshipScore)
        {
            SnapshotEvents.instance?.DecrementRelScore.Invoke();
        }
        else if (relationshipScore < inkRelationshipScore)
        {
            SnapshotEvents.instance.IncrementRelScore?.Invoke();
        }
        #endregion

        relationshipScore = inkRelationshipScore;
    }
}