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
    [SerializeField] private GameObject inputNameObject;
    [SerializeField] private GameObject quizCanvasObject;
    [SerializeField] private IntValue levelIndexValue;
    [SerializeField] private SaveManager saveManager;

    public bool canRevive;

    private void Awake()
    {
        levelIndexValue.runtimeValue = SceneManager.GetActiveScene().buildIndex;
        instance = this;
        canRevive = false;
    }

    public void ChangePlayStates() 
    {
        
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
        SceneManager.LoadScene("Level 1");
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
        SceneManager.LoadScene("Level 1");
    }

    public void EnableInputArea() 
    {
        deathChoiceCanvasObject.SetActive(false);
        inputNameObject.SetActive(true);
    }

    public void GoToHighScore() 
    {
        SceneManager.LoadScene("HighscoreList");
    }
}
