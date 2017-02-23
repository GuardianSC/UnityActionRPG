using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Player player;

    public Text healthText;
    public Text manaText;
    public Text strengthText;
    public Text intelligenceText;
    public Text dexterityText;

    // Use this for initialization
    void Start ()
    {
        // Find the gameobject Player is attached to in order to access attributes (null reference exception occurs otherwise and not set in Unity Editor)
        player = GameObject.Find("Player").GetComponent<Player>();
        healthText.text = "HP/MaxHP: "     + player.health + "/"  + player.maxHealth;
        manaText.text   = "Mana/MaxMana: " + player.mana   + "/"  + player.maxMana;

        strengthText.text     = "Strength: "     + player.strength;
        intelligenceText.text = "Intelligence: " + player.intelligence;
        dexterityText.text    = "Dexterity: "    + player.dexterity;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }
}