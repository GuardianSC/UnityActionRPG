using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : MonoBehaviour
{
    Player player;
    // Use this for initialization
    void Start()
    {
        player.classes.Add(new Classes()
        {
            ClassName = "Rogue",
            classPrefab = GameObject.Find("RoguePrefab"),
            strengthBonus = 2,
            intelligenceBonus = 2,
            dexterityBonus = 5
        });
    }
}
