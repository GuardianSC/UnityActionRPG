using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classes : MonoBehaviour
{
    public string ClassName { get; set; }
    public GameObject classPrefab { get; set; }

    public int strengthBonus { get; set; }      // Attack damage, health
    public int intelligenceBonus { get; set; }  // Amount of mana
    public int dexterityBonus { get; set; }     // Attack rate
    //public int healthBonus { get; set; }
    //public int maxHealthBonus { get; set; }
    //public int manaBonus { get; set; }
    //public int maxManaBonus { get; set; }
}