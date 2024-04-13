using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoBehaviour
{
    private static CoroutineManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static CoroutineManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("CoroutineManager instance is null!");
            }
            return instance;
        }
    }
}
