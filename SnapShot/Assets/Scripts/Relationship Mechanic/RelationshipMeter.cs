using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelationshipMeter : MonoBehaviour
{
    [SerializeField] private Slider relMeter;
    public int inkRelationshipScore { get; private set; }
    private int relationshipScore;
    private int maxRelationshipScore = 5;
    void Update()
    {
        inkRelationshipTracker();
        Fill();
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
    public void Fill()
    {
        relMeter.value = relationshipScore;
    }
}