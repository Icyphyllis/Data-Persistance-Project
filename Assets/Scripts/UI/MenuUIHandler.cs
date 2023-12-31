using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        UIManager.Instance.LoadHighScore();
        scoreText.text = $"HigherScore : {UIManager.Instance.playerName}   {UIManager.Instance.highScore}";
    }

    public void StartGame()
    {
        //optimisation
        /*if (nameInput.text != null || nameInput.text != "")
        {UIManager.Instance.playerName = nameInput.text; }
        else { UIManager.Instance.playerName = "Stupid"; }*/
        UIManager.Instance.playerName = (nameInput != null && !string.IsNullOrEmpty(nameInput.text)) ? nameInput.text : "Stupid";

        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        UIManager.Instance.SaveHighScore();
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
