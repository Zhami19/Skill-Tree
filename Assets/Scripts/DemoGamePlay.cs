using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DemoGamePlay : MonoBehaviour
{
    [SerializeField] GameObject triangle1, triangle2, triangle3, triangle4, triangle5, triangle, triangle7, triangle8, triangle9, triangle10, triangle11, triangle12, triangle13;




    private List<GameObject> unlockedSkills;
    public void PlayerSkills()
    {
        unlockedSkills = new List<GameObject>();
        unlockedSkills[0] = triangle1;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
