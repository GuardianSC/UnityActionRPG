using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueButton : MonoBehaviour
{
    public bool isOverRogue = false;
    public void OnMouseOver()
    {
        isOverRogue = true;
    }
}
