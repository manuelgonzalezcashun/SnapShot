using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RelationshipMeter : MonoBehaviour
{
  [SerializeField] GameObject relationship_meter;
  [SerializeField] GameObject[] meter_bars;

  int relationshipScore, maxRelationshipScore;

  void Start()
  {
    maxRelationshipScore = 5;
    relationshipScore = 0;

    Debug.Log("Max Relationship Score: " + maxRelationshipScore);
    Debug.Log("Relationship Score: " + relationshipScore);
  }

  void Update()
  {
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
    if (relationshipScore < maxRelationshipScore)
        relationshipScore += fillAmount;
  }

  public void Empty(int emptyAmount)
  {
    if (relationshipScore > 0)
        relationshipScore -= emptyAmount;
  }
}
