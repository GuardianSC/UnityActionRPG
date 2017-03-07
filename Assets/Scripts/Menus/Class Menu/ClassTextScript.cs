using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassTextScript : MonoBehaviour
{
    MageButton    mageButton;
    RogueButton   rogueButton;
    WarriorButton warriorButton;

    Text classText;

    void Update()
    {
        if(mageButton.isOverMage)
        {
            classText.text = "The mage is a powerful magic user.";
        }
        if (rogueButton.isOverRogue)
        {
            classText.text = "The rogue is a stealth-based character.";
        }
        if (warriorButton.isOverWarrior)
        {
            classText.text = "The warrior is a frontline soldier.";
        }
    }
}
