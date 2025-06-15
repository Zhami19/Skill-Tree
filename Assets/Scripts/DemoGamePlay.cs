using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using static UnityEditor.Progress;

public class DemoGamePlay : MonoBehaviour, IDataPersistence
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

    private string skill1, skill2, skill3, skill4, skill5, skill6, skill7, skill8;

    public static GameLevel currentLevel;

    private void LevelManagement()
    {
        switch(currentLevel)
        {
            case GameLevel.Level1:
                theUI.EnableButton(0);

                theUI.DisableButton(1);
                theUI.DisableButton(2);
                theUI.DisableButton(3);
                theUI.DisableButton(4);
                theUI.DisableButton(5);
                theUI.DisableButton(6);

                theUI.AvailableColor(0);
                break;
            case GameLevel.Level2:
                theUI.DisableButton(0);
                theUI.DisableButton(3);
                theUI.DisableButton(4);
                theUI.DisableButton(5);
                theUI.DisableButton(6);

                theUI.EnableButton(1);
                theUI.EnableButton(2);

                theUI.AvailableColor(1);
                theUI.AvailableColor(2);
                break;
            case GameLevel.Level3:
                if (path1)
                {
                    theUI.DisableButton(0);
                    theUI.DisableButton(1);
                    theUI.DisableButton(2);
                    theUI.DisableButton(5);
                    theUI.DisableButton(6);

                    theUI.EnableButton(3);
                    theUI.EnableButton(4);

                    theUI.AvailableColor(3);
                    theUI.AvailableColor(4);
                }
                else if (path2)
                {
                    theUI.DisableButton(0);
                    theUI.DisableButton(1);
                    theUI.DisableButton(2);
                    theUI.DisableButton(3);
                    theUI.DisableButton(4);

                    theUI.EnableButton(5);
                    theUI.EnableButton(6);

                    theUI.AvailableColor(5);
                    theUI.AvailableColor(6);
                }
                break;
            case GameLevel.Over:
                theUI.DisableButton(0);
                theUI.DisableButton(1);
                theUI.DisableButton(2);
                theUI.DisableButton(3);
                theUI.DisableButton(4);
                theUI.DisableButton(5);
                theUI.DisableButton(6);
                break;
        }
    }

    void Awake()
    {
        unlockedSkills = new List<GameObject>();
    }
    void Start()
    {
        theUI = UI.GetComponent<UI>();
        m = moneySystem.GetComponent<MoneySystem>();

        unlockedSkills.Add(triangle1);
        skill1 = "Unlocked";

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

    public void UnlockSkill8()
    {
        if (m.Money < 70 || unlockedSkills.Contains(triangle8)) { return; }
        unlockedSkills.Add(triangle8);
        theUI.ChosenSkill(6);
        m.SubtractMoney(70);
        theUI.NoButton(3);
        theUI.NoButton(4);
        theUI.NoButton(5);
        currentLevel = GameLevel.Over;
        skill5 = "Unused";
        skill6 = "Unused";
        skill7 = "Unused";
        skill8 = "Unlocked";
    }

    public void UnlockSkill7()
    {
        if (m.Money < 60 || unlockedSkills.Contains(triangle7)) { return; }
        unlockedSkills.Add(triangle7);
        theUI.ChosenSkill(5);
        m.SubtractMoney(60);
        theUI.NoButton(3);
        theUI.NoButton(4);
        theUI.NoButton(6);
        currentLevel = GameLevel.Over;
        skill5 = "Unused";
        skill6 = "Unused";
        skill8 = "Unused";
        skill7 = "Unlocked";
    }

    public void UnlockSkill6()
    {
        if (m.Money < 50 || unlockedSkills.Contains(triangle6)) { return; }
        unlockedSkills.Add(triangle6);
        theUI.ChosenSkill(4);
        m.SubtractMoney(50);
        theUI.NoButton(3);
        theUI.NoButton(5);
        theUI.NoButton(6);
        currentLevel = GameLevel.Over;
        skill5 = "Unused";
        skill7 = "Unused";
        skill8 = "Unused";
        skill6 = "Unlocked";
    }

    public void UnlockSkill5()
    {
        if (m.Money < 40 || unlockedSkills.Contains(triangle5)) { return; }
        unlockedSkills.Add(triangle5);
        theUI.ChosenSkill(3);
        m.SubtractMoney(40);
        theUI.NoButton(4);
        theUI.NoButton(5);
        theUI.NoButton(6);
        currentLevel = GameLevel.Over;
        skill6 = "Unused";
        skill7 = "Unused";
        skill8 = "Unused";
        skill5 = "Unlocked";
    }

    public void UnlockSkill4()
    {
        if (m.Money < 30 || unlockedSkills.Contains(triangle4)) { return; }
        unlockedSkills.Add(triangle4);
        theUI.ChosenSkill(2);
        m.SubtractMoney(30);
        theUI.NoButton(1);
        currentLevel = GameLevel.Level3;
        path2 = true;
        skill3 = "Unused";
        skill4 = "Unlocked";
    }

    public void UnlockSkill3()
    {
        if (m.Money < 20 || unlockedSkills.Contains(triangle3)) { return; }
        unlockedSkills.Add(triangle3);
        theUI.ChosenSkill(1);
        m.SubtractMoney(20);
        theUI.NoButton(2);
        currentLevel = GameLevel.Level3;
        path1 = true;

        skill4 = "Unused";
        skill3 = "Unlocked";
        Debug.Log(skill3);

    }

    public void UnlockSkill2()
    {
        if (m.Money < 10 || unlockedSkills.Contains(triangle2)) { return; }
        unlockedSkills.Add(triangle2);
        theUI.ChosenSkill(0);
        m.SubtractMoney(10);
        currentLevel = GameLevel.Level2;
        skill2 = "Unlocked";
    }

    public void LoadSkill(int skillNumber)
    {
        switch (skillNumber)
        {
            case 1:
                Debug.Log("case 1 was performed");
                break;
            case 2:
                unlockedSkills.Add(triangle2);
                break;
            case 3:
                unlockedSkills.Add(triangle3);
                break;
            case 4:
                unlockedSkills.Add(triangle4);
                break;
            case 5:
                unlockedSkills.Add(triangle5);
                break;
            case 6:
                unlockedSkills.Add(triangle6);
                break;
            case 7:
                unlockedSkills.Add(triangle7);
                break;
            case 8:
                unlockedSkills.Add(triangle8);
                break;
        }
    }

    public void LoadData(GameData data)
    {
        foreach (KeyValuePair<int, string> pair in data.skillStates)
        {
            if (pair.Value == "Unlocked")
            {
                LoadSkill(pair.Key);
            }
        }

        path1 = data.path1;
        path2 = data.path2;

        currentLevel = data.currentLevel;
    }

    public void SaveData(ref GameData data)
    {
        data.skillStates.Clear();
        data.skillStates.Add(1, skill1);
        if (skill2 != null) data.skillStates.Add(2, skill2);
        if (skill3 != null) data.skillStates.Add(3, skill3);
        if (skill4 != null) data.skillStates.Add(4, skill4);
        if (skill5 != null) data.skillStates.Add(5, skill5);
        if (skill6 != null) data.skillStates.Add(6, skill6);
        if (skill7 != null) data.skillStates.Add(7, skill7);
        if (skill8 != null) data.skillStates.Add(8, skill8);

        data.currentLevel = currentLevel;

        data.path1 = path1;
        data.path2 = path2;
    }

    //Have different lists (maybe "unused", "not chosen", and "selected") and load all of these.
    //get rid of character highlight with shift-insert
}
