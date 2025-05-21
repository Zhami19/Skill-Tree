using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] TMP_Text moneyText;
    [SerializeField] GameObject moneySystem;
    private MoneySystem m;

    [SerializeField] GameObject button1, button2, button3, button4, button5, button6, button7;
    private List<GameObject> buttonList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m = moneySystem.GetComponent<MoneySystem>();
        buttonList = new List<GameObject> { button1, button2, button3, button4, button5, button6, button7 };    
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money: " + m.Money.ToString();
    }

    public void ChangeAlphaValue(int button)
    {
        Image buttonImage = buttonList[button].GetComponent<Image>();
        Color c = buttonImage.color;
        c.a = 255;
        buttonImage.color = c;
    }
}
