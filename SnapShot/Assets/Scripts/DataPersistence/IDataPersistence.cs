using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence
{
    void LoadData(SaveData data);

    void SaveData(ref SaveData data);

}
