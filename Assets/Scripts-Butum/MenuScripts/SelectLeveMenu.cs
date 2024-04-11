using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLeveMenu : MonoBehaviour
{
    private string personName;

    public void SetPersonName(string name)
    {
        personName = name;
    }

    public void Play(int number)
    {
        SceneManager.LoadScene("Level_"+personName+"_"+number.ToString());
    }
}
