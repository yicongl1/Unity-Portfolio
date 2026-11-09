using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    Transform Panel;
    public static GameMode Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null) return;

        Panel = canvas.transform.Find("GameOverPanel");
        if (Panel != null)
        {
            Panel.gameObject.SetActive(false);
        }
    }
    public void OnRestart()
    {
        SceneManager.LoadScene("run");
    }

    public void OnStart()
    {
        SceneManager.LoadScene("run");
    }

    public void OnPlayerDie()
    {
        if (Panel != null)
        {
            Panel.gameObject.SetActive(true);
        }
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
