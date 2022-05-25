using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallSelection : MonoBehaviour
{
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button selectButton;
    [SerializeField] private IntValue skinIndexValue;
    private int currentCar;

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

    public void ChangeCar(int _change)
    {
        currentCar += _change;
        SelectBall(currentCar);
    }

    public void SelectSkin() 
    {
        skinIndexValue.runtimeValue = currentCar;
    }

    public void GoToMain() 
    {
        SceneManager.LoadScene("Level 1");
    }
}
