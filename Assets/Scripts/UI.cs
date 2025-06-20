using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject gamePlay;
    private DemoGamePlay g;

    [SerializeField] TMP_Text moneyText;
    [SerializeField] GameObject moneySystem;
    private MoneySystem m;

    [SerializeField]  GameObject button1, button2, button3, button4, button5, button6, button7;
    private List<GameObject> buttonList;

    [SerializeField] Image Ibutton1, Ibutton2, Ibutton3, Ibutton4, Ibutton5, Ibutton6, Ibutton7;
    private List<Image> IbuttonList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        buttonList = new List<GameObject> { button1, button2, button3, button4, button5, button6, button7 };
        IbuttonList = new List<Image> { Ibutton1, Ibutton2, Ibutton3, Ibutton4, Ibutton5, Ibutton6, Ibutton7 };
    }

    void Start()
    {
        g = gamePlay.GetComponent<DemoGamePlay>();  
        m = moneySystem.GetComponent<MoneySystem>();
            
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money: " + m.Money.ToString();
    }

    public void ChosenSkill(int button)
    {
        Image buttonImage = IbuttonList[button];
        /*Color c = buttonImage.color;
        c.a = 255;
        buttonImage.color = c;*/
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
        Image buttonImage = IbuttonList[button];
        buttonImage.color = Color.red;
    }

    public void AvailableColor(int button)
    {
        Image buttonImage = IbuttonList[button];
        if (button == 0 && m.Money >= 10)
        {
            buttonImage.color = Color.white;
        }
        else if (button == 1 && m.Money >= 20)
        {
            buttonImage.color = Color.white;
        }
        else if (button == 2 && m.Money >= 30)
        {
            buttonImage.color = Color.white;
        }
        else if (button == 3 && m.Money >= 40)
        {
            buttonImage.color = Color.white;
        }
        else if (button == 4 && m.Money >= 50)
        {
            buttonImage.color = Color.white;
        }
        else if (button == 5 && m.Money >= 60)
        {
            buttonImage.color = Color.white;
        }
        else if (button == 6 && m.Money >= 70)
        {
            buttonImage.color = Color.white;
        }
    }

   
}
