using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Question Value", fileName = "New Question")]
public class QuestionScriptableObject : ScriptableObject
{
    [TextArea(3, 5)]
    [SerializeField] private string questionString;
    [SerializeField] private string[] answerString = new string[4];
    [SerializeField] private int correctAnswerIndex;

    public string GetQuestion()
    {
        return questionString;
    }

    public string GetAnswer(int index)
    {
        return answerString[index];
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }
}
