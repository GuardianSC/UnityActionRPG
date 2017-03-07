using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    Player player;
    // Use this for initialization
    void Start()
    {
        player.classes.Add(new Classes()
        {
            ClassName = "Warrior",
            classPrefab = GameObject.Find("WarriorPrefab"),
            strengthBonus = 5,
            intelligenceBonus = 1,
            dexterityBonus = 1
        });
    }
}
