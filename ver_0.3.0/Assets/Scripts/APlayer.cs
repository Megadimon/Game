using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class APlayer : MonoBehaviour
{
    private int _healthOfPlayer;
    private float _speedOfPlayer;
    private float _fuelOfPlayer;
    public Slider _hpBar;
    public Slider _fuelBar;
    public bool _isYouTurn;

    public abstract int HealthSetup { get; set; }
    public abstract int SpeedSetup { get; set; }
    public abstract int FuelOfPlayerSetup { get; set; }

    public abstract void PlayerMove();
    public abstract void PlayerShot();
    public abstract void OnCollisionEnter2D(Collision2D collision);
    public abstract void RotationWeapon();
}
