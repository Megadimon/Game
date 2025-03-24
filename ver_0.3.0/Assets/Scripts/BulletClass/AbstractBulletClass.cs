using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBulletClass : MonoBehaviour
{
    public float _speed;
    public float _damage;
    public float _lifetime;
    public AbstractTankClass _owner;

    public abstract void SetShooter(StandardTank tank);
    public abstract void OnCollisionEnter2D(Collision2D collision);
    public abstract void OnDestroy();
}
