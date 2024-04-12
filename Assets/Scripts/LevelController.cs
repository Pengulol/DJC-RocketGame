using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject _StartPoint;
    [SerializeField]
    public GameObject _EndPoint;
    [SerializeField]
    public GameObject _PlayerInstance;
    [SerializeField]
    public CinemachineVirtualCamera _CameraRig;
    
    private Camera _Camera;

    private void levelInit()
    {
        this._PlayerInstance.transform.position = _StartPoint.transform.position;
        this._PlayerInstance.transform.rotation = _StartPoint.transform.rotation;

        this._CameraRig.Follow = this._PlayerInstance.transform;
        this._CameraRig.LookAt = this._PlayerInstance.transform;

    }
    void Start()
    {
        Physics.gravity = Vector3.zero;
        this.levelInit();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuSceen");
        }
    }
}
