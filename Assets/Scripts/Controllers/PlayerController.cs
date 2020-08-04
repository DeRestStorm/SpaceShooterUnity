using System.Collections;
using System.Collections.Generic;
using Components;
using Models;
using ScriptableObjects;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 10;
    public float Tilt = 4;
    private Boundary _boundary;

    private float _currentTime = 0.0F;
    private float _nextFire = 0.5F;
    private Rigidbody _rigidbody;
    private VariableJoystick _joystick;
    public PlayerData PlayerData;

    private void Start()
    {
        var health = GetComponent<IHealth>();
        health.SetHealth(PlayerData.Health);
        health.OutOfHealth += () => Destroy(gameObject);

        _boundary = new Boundary(Camera.main);
        _joystick = FindObjectOfType<VariableJoystick>();
        _rigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        var moveHorizontal = _joystick.Horizontal;
        var moveVertical = _joystick.Vertical;

#if UNITY_EDITOR
        moveHorizontal += Input.GetAxis("Horizontal");
        moveVertical += Input.GetAxis("Vertical");
#endif

        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        _rigidbody.velocity = movement * Speed;

        _rigidbody.position = new Vector3(
            Mathf.Clamp(_rigidbody.position.x, _boundary.xMin, _boundary.xMax),
            0.0f,
            Mathf.Clamp(_rigidbody.position.z, _boundary.zMin, _boundary.zMax)
        );

        _rigidbody.rotation = Quaternion.Euler(
            0.0f,
            0.0f,
            _rigidbody.velocity.x * -Tilt
        );
    }
}