using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityActionRPG.UI
{
    public class MainMenu : MonoBehaviour
    {
	    public void LoadSceneOnSelect()
	    {
		    SceneManager.LoadScene("TestScene");
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
}


