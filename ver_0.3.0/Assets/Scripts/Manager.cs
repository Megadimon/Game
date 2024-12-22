using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class APlayer : MonoBehaviour
{
    private int healthOfPlayer { get; set; }
    private float speedOfPlayer;
    private float fuelOfPlayer;
    public Slider hpBar;
    public Slider fuelBar;
    public bool isYouTurn;

    public abstract void PlayerMove();
    public abstract void PlayerShot();
    public abstract void OnCollisionEnter2D(Collision2D collision);
    public abstract void RotationWeapon();
}
