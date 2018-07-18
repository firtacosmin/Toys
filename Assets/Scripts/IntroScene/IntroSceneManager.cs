using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroSceneManager : MonoBehaviour {
    public Text highScoreText;

	public void StartGame()
    {
        SceneManager.LoadScene("Scenes/Level 01");
    }

    private void Start()
    {
        if ( GameDataManager.instance.highScore >= 0 )
        {
            highScoreText.text = "HighScore: " + GameDataManager.instance.playerName + ":" + GameDataManager.instance.highScore;
        }
        else
        {
            highScoreText.text = "";
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
