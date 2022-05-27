using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreList : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    public FloatValue playerScore;

    private void Awake()
    {
        entryContainer = transform.Find("HighScoreContainer");
        entryTemplate = entryContainer.Find("HighScoreTemplate");

        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        string playerName = PlayerPrefs.GetString("user_name");

        if (playerScore.runtimeValue != 0)
        {

            AddHighscoreEntry(playerScore.runtimeValue, playerName);
        }

        if (highscores == null)
        {
            Debug.Log("Initializing table with default values...");
            AddHighscoreEntry(2000, "JAH");
            AddHighscoreEntry(1500, "TW");
            AddHighscoreEntry(1200, "RBJ");
            AddHighscoreEntry(1000, "JAH");
            AddHighscoreEntry(920, "TW");
            AddHighscoreEntry(870, "RBJ");
            AddHighscoreEntry(510, "BGB");
            AddHighscoreEntry(330, "LRD");
            AddHighscoreEntry(220, "PRG");
            AddHighscoreEntry(200, "ROY");
            AddHighscoreEntry(170, "DEL");
            AddHighscoreEntry(150, "DOG");
            AddHighscoreEntry(130, "AYN");
            AddHighscoreEntry(100, "EDY");

            AddHighscoreEntry(playerScore.runtimeValue, playerName);

            jsonString = PlayerPrefs.GetString("highscoreTable");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

        if (highscores != null)
        {
            jsonString = PlayerPrefs.GetString("highscoreTable");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

        Debug.Log(jsonString);


        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {

                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;

                    if (highscores.highscoreEntryList.Count > 10)
                    {
                        highscores.highscoreEntryList.RemoveRange(9, highscores.highscoreEntryList.Count - 9);
                    }
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 100f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);


        float score = highscoreEntry.score;
        entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("NameText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }

    private void AddHighscoreEntry(float score, string name)
    {

        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };


        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
        {

            highscores = new Highscores()
            {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }


        highscores.highscoreEntryList.Add(highscoreEntry);


        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public float score;
        public string name;
    }
}