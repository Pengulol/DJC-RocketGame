using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    public GUISkin guiSkin;
    public Texture2D pauseButtonTexture;
    public Texture2D progressBarTexture;
    public Texture2D progressLineTexture;
    private float startTime;
    private const string TimeKey = "Time";
    private Rect timerRect = new Rect(0, 0, 120, 60);
    private Rect pauseRect = new Rect(0, 0, 70, 70);
    private Rect finishRect = new Rect(0, 0, 200, 100);
    private Rect collisionRect = new Rect(0, 0, 200, 100);
    private Rect progressBarRect = new Rect(0, 0, 50, 220);
    private Rect progressLineRect;
    private bool isPaused = false;
    private bool isLevelFinished = false;
    private bool isCollision = false;
    private int attempts;
    private float reloadTime = 3f;
    private float timer = 3f;
    void Start()
    {
        startTime = Time.time;

        timerRect.x = 30;
        timerRect.y = 40;

        pauseRect.x = Screen.width - timerRect.width;
        pauseRect.y = 40;

        finishRect.x = (Screen.width - finishRect.width) / 2;
        finishRect.y = (Screen.height - finishRect.height) / 2;

        collisionRect.x = (Screen.width - collisionRect.width) / 2;
        collisionRect.y = (Screen.height - collisionRect.height) / 2 - 200;

        progressBarRect.x = Screen.width - timerRect.width + 10;
        progressBarRect.y = 200;

        progressLineRect = new Rect(0, 0, 24, progressBarRect.height / 14);
    }

    void Update()
    {

    }

    void OnGUI()
    {
        GUI.skin = guiSkin;
        timerRect = GUI.Window(0, timerRect, TimerWindow, "Time");
        float progress = PlayerPrefs.GetFloat("PlayerMaxVelocity", 0);
        ProgressBar(progress);
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

        if (isCollision)
        {
            collisionRect = GUI.Window(2, collisionRect, CollisionWindow, "You hit an obstacle!");
        }

    }

    void TimerWindow(int windowID)
    {
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        GUI.Label(new Rect(5, 30, 100, 20), minutes + ":" + seconds);
        PlayerPrefs.SetFloat(TimeKey, t);
        PlayerPrefs.Save();

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

    void CollisionWindow(int windowID)
    {
        timer -= Time.deltaTime;

        GUI.Label(new Rect(50, 25, 120, 50), "Reloading in " +Mathf.Ceil(timer));

        if (timer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }

    public void DrawCollisionWindow()
    {
        isCollision = true;
    }

    void ProgressBar(float value)
    {
        GUI.DrawTexture(progressBarRect,progressBarTexture );

        float scaledValue = Mathf.Clamp01((value - 0.8f) / (1.2f - 0.8f));
        int progress = Mathf.RoundToInt(scaledValue * 14);

        for (int i = 0; i < progress; i++)
        {
            float x = progressBarRect.x + 13;
            float y = progressBarRect.y + i * progressLineRect.height;
            DrawProgressLine(x, y);
        }

        GUI.color = Color.white;
    }

    void DrawProgressLine(float x, float y)
    {
        GUI.DrawTexture(new Rect(x, y, progressLineRect.width, progressLineRect.height + 3), progressLineTexture);
    }
}
