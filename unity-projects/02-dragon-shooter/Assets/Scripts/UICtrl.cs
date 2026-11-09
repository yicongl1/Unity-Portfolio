using UnityEngine;
using UnityEngine.SceneManagement;

public class UICtrl : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit(0);
    }
}
