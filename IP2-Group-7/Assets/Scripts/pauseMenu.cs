using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour
{
    public GameObject menu;
    public string pauseMenuActive;

    void Start()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        pauseMenuActive = "false";
    }

    void Update()
    {
        if (Input.GetKeyDown("p") && pauseMenuActive == "false")
        {
            Pause();
        }

        if (Input.GetKeyDown("p") && pauseMenuActive == "true")
        {
            Resume();
        }
    }

    public void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        pauseMenuActive = "false";
    }

    public void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        pauseMenuActive = "true";
    }
}
