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
            AddHighscoreEntry(53800, "JAH");
            AddHighscoreEntry(47600, "TW");
            AddHighscoreEntry(40400, "RBJ");
            AddHighscoreEntry(38200, "JAH");
            AddHighscoreEntry(37400, "TW");
            AddHighscoreEntry(36900, "RBJ");
            AddHighscoreEntry(34800, "BGB");
            AddHighscoreEntry(34100, "LRD");
            AddHighscoreEntry(33900, "PRG");
            AddHighscoreEntry(33700, "ROY");
            AddHighscoreEntry(31800, "DEL");
            AddHighscoreEntry(31600, "DOG");
            AddHighscoreEntry(31100, "AYN");
            AddHighscoreEntry(30800, "EDY");

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
                        highscores.highscoreEntryList.RemoveRange(3, highscores.highscoreEntryList.Count - 3);
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
