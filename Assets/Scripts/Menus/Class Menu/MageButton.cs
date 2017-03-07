using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MageButton : MonoBehaviour
{
    public bool isOverMage = false;
	public void OnMouseOver()
    {
        isOverMage = true;
    }
}
