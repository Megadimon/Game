using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardTank : AbstractTankClass
{

    protected override Vector2 GetMovementDirection()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), 0);
        //return direction.normalized;
        return direction;
    }

    void FixedUpdate()
    {
        ApplyMovement(GetMovementDirection());

        Debug.Log("Direction = " + GetMovementDirection());
    }

    //[SerializeField] private GameObject projectilePrefab; // Префаб снаряда
    //[SerializeField] private Transform shootingPoint;       // Точка выстрела

    //private Camera _mainCamera;
    //private bool canShoot = true; // Флаг: можно ли стрелять

    //private void Awake()
    //{
    //    _speedOfPlayer = 5f;
    //    _rb = GetComponent<Rigidbody2D>();
    //}

    //private void Update()
    //{
    //    _moveInput = Input.GetAxis("Horizontal");

    //    RotationWeapon();
    //}

    //private void FixedUpdate()
    //{
    //    PlayerMove();
    //}

    //public override void PlayerMove()
    //{
    //    _rb.velocity = new Vector2(_moveInput * _speedOfPlayer, _rb.velocity.y);
    //}

    //public override void RotationWeapon()
    //{
    //    Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    //    diff.z = 0f;
    //    diff.Normalize();

    //    Cannon.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg);
    //}

    //public override void PlayerShot()
    //{
    //    if (!canShoot)
    //        return; // Если снаряд уже в сцене – выстрел невозможен

    //    if (projectilePrefab != null && shootingPoint != null)
    //    {
    //        // Создаем снаряд
    //        GameObject projectileInstance = Instantiate(projectilePrefab, shootingPoint.position, Cannon.transform.rotation);

    //        // Передаем ссылку на танк, чтобы снаряд мог уведомить об уничтожении
    //        Projectile projectileScript = projectileInstance.GetComponent<Projectile>();
    //        if (projectileScript != null)
    //        {
    //            projectileScript.SetShooter(this);
    //        }

    //        canShoot = false; // Выстрел произведён, пока снаряд не уничтожен повторный выстрел невозможен
    //    }
    //}

}
