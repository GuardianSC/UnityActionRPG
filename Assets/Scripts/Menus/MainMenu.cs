using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject classMenuPanel;

    void Start()
    {
        mainMenuPanel  = GameObject.Find("MainPanel");
        mainMenuPanel.SetActive(true);
        classMenuPanel = GameObject.Find("ClassPanel");
        classMenuPanel.SetActive(false);
    }

	public void LoadSceneOnSelect()
    {
        SceneManager.LoadScene("TestScene");
	}

    public void ChangeToClassMenu()
    {
        mainMenuPanel.SetActive(false);
        classMenuPanel.SetActive(true);
    }

    public void ChangeToMainMenu()
    {
        classMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
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
