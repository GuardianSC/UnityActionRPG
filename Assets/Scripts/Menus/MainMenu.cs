using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject classMenuPanel;

    public void ChangeToClassMenu()
    {
        mainMenuPanel.SetActive(false);
        classMenuPanel.SetActive(true);
    }

    public void QuitOnSelect()
    {
//  If playing through the Unity Editor, exit play mode. Otherwise exit to desktop
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
