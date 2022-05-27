using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallSelection : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button selectButton;
    [SerializeField] private IntValue skinIndexValue;
    [SerializeField] private IntValue levelIndexValue;
    private int currentBall;

    private void Awake()
    {
        SelectBall(0);
    }

    private void SelectBall(int _index)
    {
        previousButton.interactable = (_index != 0);
        nextButton.interactable = (_index != transform.childCount-1);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }
    }

    public void ChangeBall(int _change)
    {
        currentBall += _change;
        SelectBall(currentBall);
    }

    public void SelectSkin() 
    {
        skinIndexValue.runtimeValue = currentBall;
    }

    public void GoToMain() 
    {
        SceneManager.LoadScene(levelIndexValue.runtimeValue);
    }
}
