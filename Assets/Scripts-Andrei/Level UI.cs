using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    public GUISkin guiSkin;
    public Texture2D pauseButtonTexture;

    private float startTime;

    private Rect timerRect = new Rect(0, 0, 120, 60);
    private Rect pauseRect = new Rect(0, 0, 70, 70);
    private Rect finishRect = new Rect(0, 0, 200, 100);
    private bool isPaused = false;
    private bool isLevelFinished = false;
    void Start()
    {
        startTime = Time.time;

        timerRect.x = 30;
        timerRect.y = 40;

        pauseRect.x = Screen.width - timerRect.width;
        pauseRect.y = 40;

        finishRect.x = (Screen.width - finishRect.width) / 2;
        finishRect.y = (Screen.height - finishRect.height) / 2;
    }

    void Update()
    {

    }

    void OnGUI()
    {
        GUI.skin = guiSkin;
        timerRect = GUI.Window(0, timerRect, TimerWindow, "Time");

        GUI.DrawTexture(pauseRect, pauseButtonTexture);
        if (Event.current.type == EventType.MouseDown && pauseRect.Contains(Event.current.mousePosition))
        {
            TogglePause();
        }

        if (isLevelFinished)
        {
            finishRect = GUI.Window(1, finishRect, FinishWindow, "You finished the level!");
            Time.timeScale = 0;
        }

    }

    void TimerWindow(int windowID)
    {
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        GUI.Label(new Rect(5, 30, 100, 20), minutes + ":" + seconds);
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        Time.timeScale = isPaused ? 0 : 1;
    }

    void FinishWindow(int windowID)
    {

        if (GUI.Button(new Rect(50, 60, 100, 20), "Main Menu"))
        {
            SceneManager.LoadScene("MenuSceen");
        }
    }

    public void DrawFinishWindow()
    {
        isLevelFinished = true;
    }
}
