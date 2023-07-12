using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnapshotEvents : MonoBehaviour
{
    public UnityEvent relScoreChange;

    #region Singleton Stuff
    public static SnapshotEvents instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion


}
