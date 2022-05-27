using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizChallenge : MonoBehaviour
{
    [Header("Question Objects")]
    private QuestionScriptableObject questionObject;
    [SerializeField] private List<QuestionScriptableObject> questionObjects = new List<QuestionScriptableObject>();
    [SerializeField] private TextMeshProUGUI questionText;

    [Header("Answer Objects")]
    [SerializeField] private GameObject[] answerObjects;
    [SerializeField] private int correctAnswerIndex;
    [SerializeField] private Sprite defaultAnswerSprite;
    [SerializeField] private Sprite correctAnswerSprite;
    [SerializeField] private bool isAnsweredEarly;

    [Header("Timer Objects")]
    [SerializeField] private Image timerImage;
    private TimerChallenge timer;

    [Header("Score Manager")]
    [SerializeField] private TextMeshProUGUI scoreText;
    private QuizScoreRecorder scoreRecorder;
    private int answersCount;

    public bool isComplete;

    private void Awake()
    {
        timer = FindObjectOfType<TimerChallenge>();
        scoreRecorder = FindObjectOfType<QuizScoreRecorder>();
    }

    // Start is called before the first frame update
    void Start()
    {
        answersCount = 0;
        GetQuestion();
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;

        if (timer.loadNextQuestion)
        {
            if (questionObjects.Count < 0 || answersCount == 1) 
            {
                ManagerGame.instance.ReviveGame();
                isComplete = true;
                return;
            }

            isAnsweredEarly = false;
            GetQuestion();
            timer.loadNextQuestion = false;
        }

        else if (!isAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    private void WriteQuestions()
    {
        questionText.text = questionObject.GetQuestion();

        for (int i = 0; i < answerObjects.Length; i++)
        {
            TextMeshProUGUI buttonText = answerObjects[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = questionObject.GetAnswer(i);
        }

    }

    private void GetQuestion()
    {
        if (questionObjects.Count > 0)
        {
            SetButtonState(true);
            SetButtonSprites();
            GetRandomQuestion();
            WriteQuestions();
            scoreRecorder.IncrementQuestionSeen();
        }

    }

    private void GetRandomQuestion()
    {
        int random = Random.Range(0, questionObjects.Count);
        questionObject = questionObjects[random];

        if (questionObjects.Contains(questionObject))
        {
            questionObjects.Remove(questionObject);
        }

    }

    private void SetButtonState(bool state)
    {
        for (int i = 0; i < answerObjects.Length; i++)
        {
            Button answerButton = answerObjects[i].GetComponent<Button>();
            answerButton.interactable = state;
        }
    }

    private void SetButtonSprites()
    {
        for (int i = 0; i < answerObjects.Length; i++)
        {
            Button answerButtons = answerObjects[i].GetComponent<Button>();
            answerButtons.image.sprite = defaultAnswerSprite;
        }
    }

    public void OnAnswerSelected(int index)
    {
        isAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score: " + scoreRecorder.CalculateScore() + "%";
    }

    private void DisplayAnswer(int index)
    {
        Image buttonImage;

        if (index == questionObject.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerObjects[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            scoreRecorder.IncrementCorrectAnswers();
            answersCount++;
        }

        else
        {
            correctAnswerIndex = questionObject.GetCorrectAnswerIndex();
            string correctAnswer = questionObject.GetAnswer(correctAnswerIndex);
            questionText.text = "Wrong answer, the correct answer is:\n" + correctAnswer;

            buttonImage = answerObjects[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }
}
