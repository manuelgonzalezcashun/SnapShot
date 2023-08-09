using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelationshipMeter : MonoBehaviour
{
    [SerializeField] private Slider relMeter;
    [SerializeField] private Image fill;

    private void Awake()
    {
        InkDialogueObserver.UpdateRelationshipScore += RelationshipScoreUpdater;
    }
    private void OnDestroy()
    {
        InkDialogueObserver.UpdateRelationshipScore -= RelationshipScoreUpdater;
    }
    private void Start()
    {
        relMeter.value = 0;
    }
    public void RelationshipScoreUpdater(int score)
    { 
        relMeter.value = score;
        if (score >  0)
        {
            fill.color = Color.green;
        }

        if (score < 0) 
        {
            relMeter.value = Mathf.Abs(score);
            fill.color = Color.red;
        }
    }
}