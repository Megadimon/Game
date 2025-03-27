using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTankMovementModule : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] protected float _baseSpeed = 5f;
    [SerializeField] protected Rigidbody2D _rb;

    protected virtual void Awake()
    {
        if (_rb == null) { _rb = GetComponent<Rigidbody2D>(); }
        if (_rb == null) { Debug.Log("Rigidbody2D не найден для " + gameObject.name); }
    }

    public abstract Vector2 GetMovementDirection();

    public virtual void ApplyMovement()
    {
        if (_rb != null) { _rb.velocity = GetMovementDirection() * _baseSpeed; }
    }
}
