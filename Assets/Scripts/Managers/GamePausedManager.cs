using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePausedManager : MonoBehaviour {
    
    public GameObject gameOverUIPanel;
    public GameObject StickControlls;
    public bool IsGamePaused
    {
        get { return gamePaused; }
    }


    private bool gamePaused = false;
    Animator anim;
    Animator controllsAnim;
    float restartTimer;
    private


    void Awake()
    {
        anim = GetComponent<Animator>();
        controllsAnim = StickControlls.GetComponent<Animator>();
        anim.SetBool("GamePaused", false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            /*back pressed*/
            if (!gamePaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        gamePaused = false;
        SetAnimators();
    }


    public void PauseGame()
    {
        gamePaused = true;
        SetAnimators();
    }

    private void SetAnimators()
    {
        anim.SetBool("GamePaused", gamePaused);
        controllsAnim.SetBool("GamePaused", gamePaused);
    }

}
