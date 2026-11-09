using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode ExitKey = KeyCode.Escape;
    public GameObject panel_s;
    public GameObject panel_e;
    bool p_a = false;
    void Start()
    {
        panel_s.SetActive(true);
        panel_e.SetActive(false);
        Time.timeScale = 0;
        p_a = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKeyDown(ExitKey)) return;

        p_a = !p_a;
        panel_e.SetActive(p_a);
        Time.timeScale = p_a ? 0 : 1;
    }

    public void start()
    {
        panel_s.SetActive(false);
        p_a = false;
        panel_e.SetActive(false);
        Time.timeScale = 1;
    }

    public void exit()
    {
        Application.Quit();
    }

    public void restart()
    {
        SceneManager.LoadSceneAsync("Maze");
        Time.timeScale = 1;
    }
}
