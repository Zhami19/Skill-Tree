using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public class GameData
{
    public int moneyCount;

    public List<int> unlockedNumbers;

    public GameData()
    {
        this.moneyCount = 0;
        this.unlockedNumbers = new List<int>();
    }
}
