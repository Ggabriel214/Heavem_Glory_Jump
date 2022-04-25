using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private FloatValue scoreValue;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = scoreValue.runtimeValue.ToString() + " ";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreValue.runtimeValue.ToString() + " ";
    }

    public void AddPoints(float addPoints) 
    {
        scoreValue.runtimeValue += addPoints;
        scoreText.text = scoreValue.runtimeValue.ToString() + " ";
    }
}
