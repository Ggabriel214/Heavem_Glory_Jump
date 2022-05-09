using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGame : MonoBehaviour
{
    [SerializeField] private GameObject startCanvasObject;
    [SerializeField] private GameObject scoreCanvasObject;
    [SerializeField] private SaveManager saveManager;

    public void ChangePlayStates() 
    {
        saveManager.ResetScriptables();
        startCanvasObject.SetActive(false);
        scoreCanvasObject.SetActive(true);
        Ball.instance.playerState = PlayerState.playing;
    }
}
