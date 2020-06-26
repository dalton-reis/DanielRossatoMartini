using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuActions : MonoBehaviour
{

    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void loadShadowScene()
    {
        SceneManager.LoadScene(1);
    }

    public void loadNormalScene()
    {
        SceneManager.LoadScene(2);
    }

    public void loadPathScene()
    {
        SceneManager.LoadScene(3);
    }

    public void close()
    {
        Application.Quit();
    }
}
