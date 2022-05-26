using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetPlayerInput : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputName;
    private string saveName;

    // Update is called once per frame
    void Update()
    {
        CreateName();
    }

    public void CreateName() 
    {
        saveName = inputName.text;
        PlayerPrefs.SetString("user_name", saveName);
        PlayerPrefs.Save();
    }
}
