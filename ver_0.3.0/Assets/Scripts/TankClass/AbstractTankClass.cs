using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractTankClass : MonoBehaviour
{
    [Header("Modules")]
    [SerializeField] protected AbstractTankMovementModule _movementModule;

    protected virtual void Awake()
    {
        if (_movementModule == null) { _movementModule = GetComponent<StandardTankMovement>(); }
        if (_movementModule == null) { Debug.LogError($"TankMovementModule не найден для {gameObject.name}. Добавьте модуль движения!", this);  }
            
    }

    protected virtual void FixedUpdate()
    {
        _movementModule?.ApplyMovement();

        Debug.Log("Direction = " + _movementModule.GetMovementDirection());
    }

}
