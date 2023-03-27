using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject fadeEffect;

    private void Start()
    {
        fadeEffect.SetActive(false);
    }

    public static void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayGame(MonoBehaviour instance)
    {
        fadeEffect.SetActive(true);
        instance.StartCoroutine(StartGame());
    }

    public static void WinScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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

    public static IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Game");
    }
}
