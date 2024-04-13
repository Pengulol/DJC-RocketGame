using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public GUISkin guiSkin;
    public AudioMixer audioMixer;
    float hSliderValue = 0.0f;
    Rect windowRect = new Rect(0, 0, 200, 160);
    Rect optionsRect = new Rect(0, 0, 200, 160);
    Rect levelSelectionRect = new Rect(0, 0, 200, 160);
    bool showOptionsWindow = false;
    bool showLevelSelectionWindow = false;
    bool showMainMenu = true;

    void Start()
    {
        windowRect.x = (Screen.width - windowRect.width) / 2;
        windowRect.y = (Screen.height - windowRect.height) / 2;

        optionsRect.x = (Screen.width - optionsRect.width) / 2;
        optionsRect.y = (Screen.height - optionsRect.height) / 2;

        levelSelectionRect.x = (Screen.width - levelSelectionRect.width) / 2;
        levelSelectionRect.y = (Screen.height - levelSelectionRect.height) / 2;
    }

    void OnGUI()
    {
        GUI.skin = guiSkin;
        if (showMainMenu)
        {
            windowRect = GUI.Window(0, windowRect, MainMenuWindow, "");
        }

        if (showOptionsWindow)
        {
            optionsRect = GUI.Window(1, optionsRect, OptionsWindow, "Options");
        }

        if (showLevelSelectionWindow)
        {
            levelSelectionRect = GUI.Window(2, levelSelectionRect, LevelSelectionWindow, "Level Selection");
        }

    }



    void MainMenuWindow(int windowID)
    {

        if (GUI.Button(new Rect(52, 40, 100, 20), "START"))
        {
            showLevelSelectionWindow = true;
            showMainMenu = false;
        }

        if (GUI.Button(new Rect(52, 90, 100, 20), "OPTIONS"))
        {
            showOptionsWindow = true;
            showMainMenu = false;
        }

    }

    void OptionsWindow(int windowID)
    {
        GUI.Label(new Rect(50, 40, 100, 20), "Volume");
        hSliderValue = GUI.HorizontalSlider(new Rect(45, 60, 110, 30), hSliderValue, 0.0f, 10.0f);
        SetVolume(hSliderValue);

        if (GUI.Button(new Rect(60, 130, 80, 20), "Close"))
        {

            showOptionsWindow = false;
            showMainMenu = true;
        }

    }

    void LevelSelectionWindow(int windowID)
    {
        if (GUI.Button(new Rect(52, 40, 100, 20), "Level 1"))
        {
            
            SceneManager.LoadScene("Level_1_Cristi");
        }

        if (GUI.Button(new Rect(60, 130, 80, 20), "Close"))
        {

            showLevelSelectionWindow = false;
            showMainMenu = true;
        }

    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
