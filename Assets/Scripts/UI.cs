using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject gamePlay;
    private DemoGamePlay g;

    [SerializeField] TMP_Text moneyText;
    [SerializeField] GameObject moneySystem;
    private MoneySystem m;

    [SerializeField] Image button1, button2, button3, button4, button5, button6, button7;
    private List<Image> buttonList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        g = gamePlay.GetComponent<DemoGamePlay>();  
        m = moneySystem.GetComponent<MoneySystem>();
        buttonList = new List<Image> { button1, button2, button3, button4, button5, button6, button7 };    
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money: " + m.Money.ToString();
    }

    public void ChangeAlphaValue(int button)
    {
        Image buttonImage = buttonList[button];
        Color c = buttonImage.color;
        c.a = 255;
        buttonImage.color = c;
        buttonImage.color = Color.blue;
    }

    public void DisableButton(int button)
    {
        buttonList[button].gameObject.SetActive(false);
    }

    public void EnableButton(int button)
    {
        buttonList[button].gameObject.SetActive(true);
    }

    public void NoButton(int button)
    {
        Destroy(buttonList[button].gameObject.GetComponent<Button>());
        Image buttonImage = buttonList[button];
        buttonImage.color = Color.red;
    }

    public void ChangeColor()
    {
        /*if (m.Money >= 70 || g.currentLevel )
        {

        }*/
    }

    //Fix Levels, if left side is picked then right side is blocked and vice versa
    //Find how to access enum state

}
