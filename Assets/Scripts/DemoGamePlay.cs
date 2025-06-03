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

    private bool path1 = false;
    private bool path2 = false;

    public enum Level
    {
        Level1,
        Level2,
        Level3,
        Over
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
                theUI.AvailableColor(0);
                break;
            case Level.Level2:
                theUI.EnableButton(1);
                theUI.EnableButton(2);
                theUI.AvailableColor(1);
                theUI.AvailableColor(2);
                break;
            case Level.Level3:
                if (path1)
                {
                    theUI.EnableButton(3);
                    theUI.EnableButton(4);
                    theUI.AvailableColor(3);
                    theUI.AvailableColor(4);
                }
                else if (path2)
                {
                    theUI.EnableButton(5);
                    theUI.EnableButton(6);
                    theUI.AvailableColor(5);
                    theUI.AvailableColor(6);
                }
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
        Debug.Log(currentLevel);
    }

    // Update is called once per frame
    void Update()
    {
        LevelManagement();
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
        theUI.ChosenSkill(6);
        m.SubtractMoney(70);
        theUI.NoButton(3);
        theUI.NoButton(4);
        theUI.NoButton(5);
        currentLevel = Level.Over;
    }

    public void UnlockSkill6()
    {
        if (m.Money < 60 || unlockedSkills.Contains(triangle7)) { return; }
        unlockedSkills.Add(triangle7);
        theUI.ChosenSkill(5);
        m.SubtractMoney(60);
        theUI.NoButton(3);
        theUI.NoButton(4);
        theUI.NoButton(6);
        currentLevel = Level.Over;
    }

    public void UnlockSkill5()
    {
        if (m.Money < 50 || unlockedSkills.Contains(triangle6)) { return; }
        unlockedSkills.Add(triangle6);
        theUI.ChosenSkill(4);
        m.SubtractMoney(50);
        theUI.NoButton(3);
        theUI.NoButton(5);
        theUI.NoButton(6);
        currentLevel = Level.Over;
    }

    public void UnlockSkill4()
    {
        if (m.Money < 40 || unlockedSkills.Contains(triangle5)) { return; }
        unlockedSkills.Add(triangle5);
        theUI.ChosenSkill(3);
        m.SubtractMoney(40);
        theUI.NoButton(4);
        theUI.NoButton(5);
        theUI.NoButton(6);
        currentLevel = Level.Over;
    }

    public void UnlockSkill3()
    {
        if (m.Money < 30 || unlockedSkills.Contains(triangle4)) { return; }
        unlockedSkills.Add(triangle4);
        theUI.ChosenSkill(2);
        m.SubtractMoney(30);
        theUI.NoButton(1);
        currentLevel = Level.Level3;
        path2 = true;
    }

    public void UnlockSkill2()
    {
        if (m.Money < 20 || unlockedSkills.Contains(triangle3)) { return; }
        unlockedSkills.Add(triangle3);
        theUI.ChosenSkill(1);
        m.SubtractMoney(20);
        theUI.NoButton(2);
        currentLevel = Level.Level3;
        path1 = true;
    }

    public void UnlockSkill1()
    {
        if (m.Money < 10 || unlockedSkills.Contains(triangle2)) { return; }
        unlockedSkills.Add(triangle2);
        theUI.ChosenSkill(0);
        m.SubtractMoney(10);
        currentLevel = Level.Level2;
    }

    //Have different lists (maybe "unused", "not chosen", and "selected") and load all of these.
}
