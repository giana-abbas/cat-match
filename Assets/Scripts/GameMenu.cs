using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject gameMenu;

    public void ResumeGame()
    {
        gameMenu.gameObject.SetActive(false);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameMenu.activeInHierarchy == true)
            {
                gameMenu.gameObject.SetActive(false);
            }

        }
    }

}
