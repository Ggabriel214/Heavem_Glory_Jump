using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizScoreRecorder : MonoBehaviour
{
    [SerializeField] public int correctAnswers;
    [SerializeField] private int questionSeen;

    public int GetCorrectAnswers() 
    {
        return correctAnswers;
    }

    public int GetQuestionSeen() 
    {
        return questionSeen;
    }

    public void IncrementCorrectAnswers() 
    {
        correctAnswers++;
    }

    public void IncrementQuestionSeen() 
    {
        questionSeen++;
    }

    public int CalculateScore() 
    {
        return Mathf.RoundToInt(correctAnswers / (float)questionSeen * 100);
    }
}
