using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private static string Horizontal = "Horizontal";

    private Rigidbody2D _rigidbody;
    private bool _isCanJump = true;
    private float _force = 10f;
    private float _speed = 5f;

    public event Action<float> Running;
    public event Action<bool> Jumped;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Moves();
        Jump();
    }

    private void Moves()
    {
        Vector2 diretion = Vector2.right * Input.GetAxis(Horizontal);
        transform.Translate(-diretion * _speed * Time.deltaTime);

        Running?.Invoke(diretion.x);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isCanJump)
        {
            _rigidbody.AddForce(transform.up * _force, ForceMode2D.Impulse);
            Jumped?.Invoke(_isCanJump);

            _isCanJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<TilemapCollider2D>(out TilemapCollider2D ground))
        {
            _isCanJump = true;
            Jumped?.Invoke(!_isCanJump);
        }
    }
}
