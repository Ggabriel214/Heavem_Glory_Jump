using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerChallenge : MonoBehaviour
{
    [SerializeField] private float timeValue;
    [SerializeField] private float timeToCompleteValue;
    [SerializeField] private float timeToShowAnswer;

    public bool loadNextQuestion;
    public bool isAnsweringQuestion;
    public float fillFraction;

    // Start is called before the first frame update
    void Start()
    {
        timeValue = timeToCompleteValue;
        isAnsweringQuestion = true;
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseTime();
    }

    public void CancelTimer()
    {
        timeValue = 0;
    }

    private void DecreaseTime()
    {
        timeValue -= Time.deltaTime;

        if (isAnsweringQuestion == true)
        {
            if (timeValue > 0)
            {
                fillFraction = timeValue / timeToCompleteValue;
            }

            if (timeValue <= 0)
            {
                isAnsweringQuestion = false;
                loadNextQuestion = false;
                timeValue = timeToShowAnswer;
            }
        }

        if (isAnsweringQuestion == false)
        {
            if (timeValue > 0)
            {
                fillFraction = timeValue / timeToShowAnswer;
            }

            if (timeValue <= 0)
            {
                isAnsweringQuestion = true;
                timeValue = timeToCompleteValue;
                loadNextQuestion = true;
            }
        }
    }
}
