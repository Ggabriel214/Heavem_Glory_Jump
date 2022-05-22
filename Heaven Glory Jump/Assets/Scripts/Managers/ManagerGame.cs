using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame instance;
    [SerializeField] private GameObject startCanvasObject;
    [SerializeField] private GameObject scoreCanvasObject;
    [SerializeField] private GameObject deathChoiceCanvasObject;
    [SerializeField] private GameObject quizCanvasObject;
    [SerializeField] private SaveManager saveManager;

    public bool canRevive;

    private void Awake()
    {
        instance = this;
        canRevive = false;
    }

    public void ChangePlayStates() 
    {
        saveManager.ResetScriptables();
        startCanvasObject.SetActive(false);
        scoreCanvasObject.SetActive(true);
        Ball.instance.playerState = PlayerState.playing;
    }

    public void CheckDeathState() 
    {
        deathChoiceCanvasObject.SetActive(true);
    }

    public void PlayQuizGame() 
    {
        quizCanvasObject.SetActive(true);
        deathChoiceCanvasObject.SetActive(false);
    }

    public void ResetGame() 
    {
        SceneManager.LoadScene("MainScene");
        deathChoiceCanvasObject.SetActive(false);
    }

    public void ReviveGame() 
    {
        quizCanvasObject.SetActive(false);
        canRevive = true;
    }

    public void EnableSettings() 
    {
        SceneManager.LoadScene("Ball Selection");
    }

    public void DisableSettings() 
    {
        SceneManager.LoadScene("MainScene");
    }
}
