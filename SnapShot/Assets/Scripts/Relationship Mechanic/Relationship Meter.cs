using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class RelationshipMeter : MonoBehaviour
{
    public UnityEvent relScoreChange;
    [SerializeField] GameObject relationship_meter;
    [SerializeField] GameObject[] meter_bars;
    int relationshipScore;
    int maxRelationshipScore = 5;
    private int inkRelationshipScore;
    void Start()
    {
        relScoreChange.AddListener(inkScoreTracker);
        relScoreChange.AddListener(() => SoundManager.instance.Play("relScoreChange"));
    }
    void Update()
    {
        inkRelationshipScore = (int)InkDialogueManager.instance.inkStoryScript.variablesState["relationship_score"];
        if (inkRelationshipScore != relationshipScore)
        {
            relScoreChange.Invoke();
        }
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
    void inkScoreTracker()
    {
        relationshipScore = inkRelationshipScore;
    }
    public void Fill(int fillAmount)
    {
        if (relationshipScore < maxRelationshipScore) relationshipScore += fillAmount;
        Debug.Log(relationshipScore);
    }
    public void Empty(int emptyAmount)
    {
        if (relationshipScore > 0) relationshipScore -= emptyAmount;
    }

}