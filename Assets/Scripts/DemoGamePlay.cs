using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DemoGamePlay : MonoBehaviour
{
    [SerializeField] GameObject triangle1, triangle2, triangle3, triangle4, triangle5, triangle6, triangle7, triangle8;

    int selectedSkillIndex = 0;
    GameObject selectedSkill;
    [SerializeField] GameObject player;


    private List<GameObject> unlockedSkills;
    [SerializeField] GameObject moneySystem;
    private MoneySystem m;

    void Start()
    {
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
        UnlockSkills();
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
            Debug.Log("unlockedSkillsCount: " + unlockedSkills.Count);
            Debug.Log("SelectedSkill: " + selectedSkillIndex);
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

    private void UnlockSkills()
    {
        switch (m.Money)
        {
            case 70:
                {
                    if (unlockedSkills.Contains(triangle8)) { break; }
                    unlockedSkills.Add (triangle8);
                    m.SubtractMoney();
                    break;
                }
            case 60:
                {
                    if (unlockedSkills.Contains(triangle7)) { break; }
                    unlockedSkills.Add(triangle7);
                    m.SubtractMoney();
                    break;
                }
            case 50:
                {
                    if (unlockedSkills.Contains(triangle6)) { break; }
                    unlockedSkills.Add(triangle6);
                    m.SubtractMoney();
                    break;
                }
            case 40:
                {
                    if (unlockedSkills.Contains(triangle5)) { break; }
                    unlockedSkills.Add(triangle5);
                    m.SubtractMoney();
                    break;
                }
            case 30:
                {
                    if (unlockedSkills.Contains(triangle4)) { break; }
                    unlockedSkills.Add(triangle4);
                    m.SubtractMoney();
                    break;
                }
            case 20:
                {
                    if (unlockedSkills.Contains(triangle3)) { break; }
                    unlockedSkills.Add(triangle3);
                    m.SubtractMoney();
                    break;
                }
            case 10:
                {
                    if (unlockedSkills.Contains(triangle2)) { break; }
                    unlockedSkills.Add(triangle2);
                    m.SubtractMoney();
                    break;
                }
        }
    }
}
