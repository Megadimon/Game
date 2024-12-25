using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class APlayer : MonoBehaviour
{
    private int _healthOfPlayer;
    private float _speedOfPlayer;
    private float _fuelOfPlayer;
    public GameObject Cannon; // добавил пушку, так как у каждого танка должна быть пушка
    public bool _isYouTurn;

    public virtual int Health
    {
        get { return _healthOfPlayer; }
        set { _healthOfPlayer = value; }
    }
    public virtual float Speed
    {
        get { return _speedOfPlayer; }
        set { _speedOfPlayer = value; }
    }
    public virtual float FuelOfPlayer
    {
        get { return _fuelOfPlayer; }
        set { _fuelOfPlayer = value; }
    }

    public abstract void PlayerMove();
    public abstract void PlayerShot();
    public abstract void OnCollisionEnter2D(Collision2D collision);
    public abstract void RotationWeapon();
}
