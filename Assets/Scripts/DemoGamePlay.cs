using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;

public class DemoGamePlay : MonoBehaviour
{
    [SerializeField] GameObject triangle1, triangle2, triangle3, triangle4, triangle5, triangle6, triangle7, triangle8;

    int selectedSkillIndex = 0;
    GameObject selectedSkill;
    [SerializeField] GameObject player;


    private List<GameObject> unlockedSkills;
    [SerializeField] GameObject moneySystem;
    private MoneySystem m;

    [SerializeField] GameObject UI;
    private UI theUI;

    public enum Level
    {
        Level1,
        Level2,
        Level3
    }

    public static Level currentLevel;

    private void LevelManagement()
    {
        switch(currentLevel)
        {
            case Level.Level1:
                theUI.EnableButton(0);
                theUI.DisableButton(1);
                theUI.DisableButton(2);
                theUI.DisableButton(3);
                theUI.DisableButton(4);
                theUI.DisableButton(5);
                theUI.DisableButton(6);
                break;
            case Level.Level2:
                theUI.EnableButton(1);
                theUI.EnableButton(2);
                break;
            case Level.Level3:
                theUI.EnableButton(3);
                theUI.EnableButton(4);
                theUI.EnableButton(5);
                theUI.EnableButton(6);
                break;
        }
    }
    void Start()
    {
        currentLevel = Level.Level1;
        theUI = UI.GetComponent<UI>();

        m = moneySystem.GetComponent<MoneySystem>();
        unlockedSkills = new List<GameObject>();
        unlockedSkills.Add(triangle1);
        selectedSkill = unlockedSkills[0];
    }

    // Update is called once per frame
    void Update()
    {
        SelectSkill();
        Shoot();
    }

    private void SelectSkill()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            selectedSkillIndex++;
            if (selectedSkillIndex >= unlockedSkills.Count)
            {
                selectedSkillIndex = 0;
            }
            selectedSkill = unlockedSkills[selectedSkillIndex];
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(selectedSkill, player.transform.localPosition, Quaternion.identity);
        }
    }

    public void UnlockSkill7()
    {
        if (m.Money < 70 || unlockedSkills.Contains(triangle8)) { return; }
        unlockedSkills.Add(triangle8);
        theUI.ChangeAlphaValue(6);
        m.SubtractMoney(70);
        theUI.NoButton(3);
        theUI.NoButton(4);
        theUI.NoButton(5);
    }

    public void UnlockSkill6()
    {
        if (m.Money < 60 || unlockedSkills.Contains(triangle7)) { return; }
        unlockedSkills.Add(triangle7);
        theUI.ChangeAlphaValue(5);
        m.SubtractMoney(60);
        theUI.NoButton(3);
        theUI.NoButton(4);
        theUI.NoButton(6);
    }

    public void UnlockSkill5()
    {
        if (m.Money < 50 || unlockedSkills.Contains(triangle6)) { return; }
        unlockedSkills.Add(triangle6);
        theUI.ChangeAlphaValue(4);
        m.SubtractMoney(50);
        theUI.NoButton(3);
        theUI.NoButton(5);
        theUI.NoButton(6);
    }

    public void UnlockSkill4()
    {
        if (m.Money < 40 || unlockedSkills.Contains(triangle5)) { return; }
        unlockedSkills.Add(triangle5);
        theUI.ChangeAlphaValue(3);
        m.SubtractMoney(40);
        theUI.NoButton(4);
        theUI.NoButton(5);
        theUI.NoButton(6);
    }

    public void UnlockSkill3()
    {
        if (m.Money < 30 || unlockedSkills.Contains(triangle4)) { return; }
        unlockedSkills.Add(triangle4);
        theUI.ChangeAlphaValue(2);
        m.SubtractMoney(30);
        theUI.NoButton(1);
        currentLevel = Level.Level3;
    }

    public void UnlockSkill2()
    {
        if (m.Money < 20 || unlockedSkills.Contains(triangle3)) { return; }
        unlockedSkills.Add(triangle3);
        theUI.ChangeAlphaValue(1);
        m.SubtractMoney(20);
        theUI.NoButton(2);
        currentLevel = Level.Level3;
    }

    public void UnlockSkill1()
    {
        if (m.Money < 10 || unlockedSkills.Contains(triangle2)) { return; }
        unlockedSkills.Add(triangle2);
        theUI.ChangeAlphaValue(0);
        m.SubtractMoney(10);
        currentLevel = Level.Level2;
    }

    /*public void UnlockSkills()
    {


        *//*switch (m.Money)
        {
            case 70:
                {
                    if (m.Money < 70 || unlockedSkills.Contains(triangle8)) { break; }
                    unlockedSkills.Add (triangle8);
                    theUI.ChangeAlphaValue(6);
                    m.SubtractMoney(70);
                    break;
                }
            case 60:
                {
                    if (m.Money < 60 || unlockedSkills.Contains(triangle7)) { break; }
                    unlockedSkills.Add(triangle7);
                    theUI.ChangeAlphaValue(5);
                    m.SubtractMoney(60);
                    break;
                }
            case 50:
                {
                    if (m.Money < 50 || unlockedSkills.Contains(triangle6)) { break; }
                    unlockedSkills.Add(triangle6);
                    theUI.ChangeAlphaValue(4);
                    m.SubtractMoney(50);
                    break;
                }
            case 40:
                {
                    if (m.Money < 40 || unlockedSkills.Contains(triangle5)) { break; }
                    unlockedSkills.Add(triangle5);
                    theUI.ChangeAlphaValue(3);
                    m.SubtractMoney(40);
                    break;
                }
            case 30:
                {
                    if (m.Money < 30 || unlockedSkills.Contains(triangle4)) { break; }
                    unlockedSkills.Add(triangle4);
                    theUI.ChangeAlphaValue(2);
                    m.SubtractMoney(30);
                    break;
                }
            case 20:
                {
                    if (m.Money < 20 || unlockedSkills.Contains(triangle3)) { break; }
                    unlockedSkills.Add(triangle3);
                    theUI.ChangeAlphaValue(1);
                    m.SubtractMoney(20);
                    break;
                }
            case 10:
                {
                    if (m.Money < 10 || unlockedSkills.Contains(triangle2)) { break; }
                    unlockedSkills.Add(triangle2);
                    theUI.ChangeAlphaValue(0);
                    m.SubtractMoney(10);
                    break;
                }
        }*//*
    }*/
}
