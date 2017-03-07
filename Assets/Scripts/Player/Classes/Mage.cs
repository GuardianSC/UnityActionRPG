using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    Player player;
	// Use this for initialization
	void Start ()
    {
        player.classes.Add(new Classes()
        { ClassName = "Mage",
          classPrefab = GameObject.Find("MagePrefab"),
          strengthBonus = 1,
          intelligenceBonus = 5,
          dexterityBonus = 1 });
	}
}