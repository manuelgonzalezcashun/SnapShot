using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class RelationshipMeter : MonoBehaviour
{
    [SerializeField] GameObject relationship_meter;
    [SerializeField] GameObject[] meter_bars;
    int relationshipScore;
    int maxRelationshipScore = 5;
    void Update()
    {
        relationshipScore = (int)InkDialogueManager.instance.inkStoryScript.variablesState["relationship_score"];

        if (relationshipScore > maxRelationshipScore) relationshipScore = maxRelationshipScore;
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

    public void Fill(int fillAmount)
    {
        if (relationshipScore < maxRelationshipScore) relationshipScore += fillAmount;
    }

    public void Empty(int emptyAmount)
    {
        if (relationshipScore > 0) relationshipScore -= emptyAmount;
    }

}
