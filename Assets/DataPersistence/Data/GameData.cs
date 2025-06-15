using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using JetBrains.Annotations;

[System.Serializable]
public class GameData
{
    public int moneyCount;
    public SerializableDictionary<int, string> skillStates;
    public GameLevel currentLevel;
    public bool path1;
    public bool path2;

    public GameData()
    {
        this.moneyCount = 0;

        skillStates = new SerializableDictionary<int, string>();

        currentLevel = GameLevel.Level1;

        path1 = false;
        path2 = false;
    }
}
