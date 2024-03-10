using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody2d;
    public float _playerSpeed;
    private Vector2 _playerDirection;
    private bool Ataque = false;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        _playerRigidbody2d.MovePosition(_playerRigidbody2d.position + _playerDirection * _playerSpeed * Time.fixedDeltaTime);
    }



}
