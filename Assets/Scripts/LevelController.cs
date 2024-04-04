using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject _StartPoint;
    [SerializeField]
    public GameObject _EndPoint;
    [SerializeField]
    public GameObject _Player;
    private void levelInit()
    {
        var playerInstance = Instantiate(_Player);
        playerInstance.transform.position = _StartPoint.transform.position;
        playerInstance.transform.rotation = _StartPoint.transform.rotation;
    }
    void Start()
    {
        Physics.gravity = Vector3.zero;
        this.levelInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
