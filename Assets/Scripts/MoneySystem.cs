using UnityEngine;

public class MoneySystem : MonoBehaviour
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
}
