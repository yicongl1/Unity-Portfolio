using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void RB()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("Rolling Ball");
    }

    public void Maze()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("Maze");
    }

    public void PTB()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("PullTheBox");
    }
}
