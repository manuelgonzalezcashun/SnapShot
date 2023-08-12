using System;
using UnityEngine;
using UnityEngine.UI;

public class RelationshipMeter : MonoBehaviour
{
    public static event Action scoreUp;
    public static event Action scoreDown;

    [SerializeField] private Slider relMeter;
    [SerializeField] private Image fill;

    [SerializeField] private Color positiveColor;
    [SerializeField] private Color negativeColor;

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
        if (relMeter.value < score)
        {
            scoreUp?.Invoke();
        }
        else if (relMeter.value > score)
        {
            scoreDown?.Invoke();
        }
        relMeter.value = score;
        if (score >  0)
        {
            fill.color = positiveColor;
        }

        if (score < 0) 
        {
            relMeter.value = Mathf.Abs(score);
            fill.color = negativeColor;
        }
    }
}