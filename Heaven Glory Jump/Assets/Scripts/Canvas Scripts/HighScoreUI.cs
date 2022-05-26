using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HighScoreUI : MonoBehaviour
{
    public void GoToMain() 
    {
        FindObjectOfType<SaveManager>().ResetScriptables();
        SceneManager.LoadScene("Level 1");
    }
}
