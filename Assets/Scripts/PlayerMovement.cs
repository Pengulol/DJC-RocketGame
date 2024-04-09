using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    const bool DEBUG_PLAYER_NO_THRUST = false;

    [SerializeField]
    public float _playerThrusterForce = 0.1f;
    [SerializeField]
    public float _playerYawSpeed = 30f;
    [SerializeField]
    public float _playerPitchSpeed = 40f;
    [SerializeField]
    public float _playerMaxVelocity = 0.8f;

    private GameObject _player;
    private Rigidbody _playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        this._player = this.gameObject;
        this._playerRigidbody = _player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");

        var horizontalTurn = this._playerYawSpeed * horizontalInput * Time.deltaTime;
        var quaternionTurnHor = Quaternion.Euler(0f, horizontalTurn, 0f);

        var verticalTurn = this._playerPitchSpeed * verticalInput * Time.deltaTime;
        var quaternionTurnVer = Quaternion.Euler(verticalTurn, 0f, 0f);

        this._playerRigidbody.MoveRotation(this._playerRigidbody.rotation * quaternionTurnHor);
        this._playerRigidbody.MoveRotation(this._playerRigidbody.rotation * quaternionTurnVer);

        if (!DEBUG_PLAYER_NO_THRUST)
        {
            this._playerRigidbody.AddRelativeForce(Vector3.forward * _playerThrusterForce, ForceMode.Impulse);
            this._playerRigidbody.velocity = this._playerRigidbody.velocity.normalized * _playerMaxVelocity; //speed cap
        }
    }
}
