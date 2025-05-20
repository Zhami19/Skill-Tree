using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text moneyText;
    [SerializeField] TMP_Text skillText;
    [SerializeField] GameObject moneySystem;
    private MoneySystem m;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m = moneySystem.GetComponent<MoneySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money: " + m.Money.ToString();
    }
}
