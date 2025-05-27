using UnityEngine;

public class MoneySystem : MonoBehaviour, IDataPersistence
{
    public int Money { get; set; }

    private void Start()
    {
        Money = 0;
    }
    public void AddMoney()
    {
        Money += 5;
    }

    public void SubtractMoney(int cost)
    {
        Money -= cost;
    }

    public void LoadData(GameData data)
    {
        Money = data.moneyCount;
    }

    public void SaveData(ref GameData data)
    {
        data.moneyCount = Money;
    }
}
