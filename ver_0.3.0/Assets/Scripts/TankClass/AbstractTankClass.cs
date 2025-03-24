using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractTankClass : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] protected float _baseSpedd = 5f;
    [SerializeField] protected Rigidbody2D _rb;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        if(_rb == null)
        {
            Debug.Log("Rigidbody2D не найден для " + gameObject.name);
        }
    }

    protected virtual void ApplyMovement(Vector2 direction)
    {
        _rb.velocity = direction * _baseSpedd;
    }

    protected abstract Vector2 GetMovementDirection();

    //protected float _healthOfPlayer;
    //protected float _speedOfPlayer;
    //public Rigidbody2D _rb;
    //public float _moveInput;
    //public GameObject Cannon;

    //public abstract void PlayerMove();
    //public abstract void PlayerShot();

    //public abstract void RotationWeapon();
}
