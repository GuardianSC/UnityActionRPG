using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityActionRPG.ThePlayer
{
    public class ClassMenu : MonoBehaviour
    {
        //Classes charClass;
        Player  player;

        public Text       classText;
        public GameObject mainMenuPanel;
        public GameObject classMenuPanel;
        public GameObject playButton;

        bool mageSelected    = false;
        bool rogueSelected   = false;
        bool warriorSelected = false;

        public void LoadTestSceneOnSelect()
        {
            SceneManager.LoadScene("TestScene");
        }

        public void SelectMage()
        {
            mageSelected = true;
            classText.text = "The mage is a powerful magic user.";
            playButton.SetActive(true);
        }

        public void SelectRogue()
        {
            rogueSelected = true;
            classText.text = "The rogue is a stealth-based character.";
            playButton.SetActive(true);
        }

        public void SelectWarrior()
        {
            warriorSelected = true;
            classText.text = "The warrior is a frontline soldier.";
            playButton.SetActive(true);
        }

        public void ChangeToMainMenu()
        {
            classMenuPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
        }

        // Update is called once per frame
        void Update ()
        {
            //if (!mageSelected || !rogueSelected || !warriorSelected)
            //    playButton.SetActive(false);
            //else
            //    playButton.SetActive(true);
	    }
    
        //public void SetClassPrefab()
        //{
        //    if (mageSelected)
        //        player..Equals(0);
        //    if (rogueSelected)
        //        player.classes.Equals(1);
        //    if (warriorSelected)
        //        player.classes.Equals(2);
        //}
    }
}