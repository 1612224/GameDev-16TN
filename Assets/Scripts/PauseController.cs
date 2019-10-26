using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public List<MonoBehaviour> ScriptsToDisable;
    public GameObject PauseUI;

    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause();
        }
    }

    private void togglePause()
    {
        if (isPaused)
        {
            PauseUI.SetActive(false);
            ScriptsToDisable.ForEach(new Action<MonoBehaviour>(script => script.enabled = true));
            Time.timeScale = 1;
        }
        else
        {
            PauseUI.SetActive(true);
            ScriptsToDisable.ForEach(new Action<MonoBehaviour>(script => script.enabled = false));
            Time.timeScale = 0;
        }
        isPaused = !isPaused;
    }

    public void Resume()
    {
        if (isPaused)
        {
            PauseUI.SetActive(false);
            ScriptsToDisable.ForEach(new Action<MonoBehaviour>(script => script.enabled = true));
            Time.timeScale = 1;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
