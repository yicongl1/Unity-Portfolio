using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public GameObject panele;
    public GameObject panelw;
    // Start is called before the first frame update
    void Start()
    {
        if (panele)
        {
            panele.SetActive(false);
        }
        if (panelw)
        {
            panelw.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void GameOver()
    {
        Time.timeScale = 0;
        panele.SetActive(true);
    }

    public void RestartRollingBall()
    {
        SceneManager.LoadScene("Rolling Ball");
        Time.timeScale = 1;
    }

    public void RestartMaze()
    {
        SceneManager.LoadScene("Maze");
        Time.timeScale = 1;
    }

    public void RestartPullTheBox()
    {
        SceneManager.LoadScene("PullTheBox");
        Time.timeScale = 1;
    }

    public void Win()
    {
        Time.timeScale = 0;
        panelw.SetActive(true);
    }

    public void Back()
    {
        SceneManager.LoadSceneAsync("UI");
    }
}
