using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    [SerializeField]
    GameObject bulletPrefab;
    public bool AlreadyShot;
    public float spawnTime;
    public float BulletSpeed;


    public GameObject MakeShot()
    {
        if(Input.GetMouseButtonDown(0) && !AlreadyShot)
        {
            AlreadyShot = true;

            var bullet = Instantiate(bulletPrefab);

            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();
            bullet.GetComponent<Shape>().speed = new Vector3(diff.x * BulletSpeed, diff.y * BulletSpeed, 0);

            bullet.transform.position = transform.position;
            bullet.GetComponent<Shape>().lifeTime = spawnTime;

            return bullet;
        }
        return null;
    }
}
