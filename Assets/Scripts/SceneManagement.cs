using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public static void WinScreen()
    {
        SceneManager.LoadScene("WinScreen");
    }

    public static void DeathScreen()
    {
        SceneManager.LoadScene("DeathScreen");
    }

    public static void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
