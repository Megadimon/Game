using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public float lifeTime;
    public Vector3 speed;
    public bool phisic;
    public GameObject explos;
    public GameObject explosion;
    public float gravity;
    float ExplosionTimer = 0.1f;

    Vector3 diff;
    Vector3 LastPos;
    // Для выстрела в сторону мыши
    // https://bunkerbook.ru/unity-lessons/kak-sdelat-strelbu-v-unity-2d/

    public bool Move()
    {
        transform.position += speed;
        lifeTime -= Time.deltaTime;
        ExplosionTimer -= Time.deltaTime;
        diff = this.transform.position - LastPos;
        LastPos = this.transform.position;
        //diff.Normalize();
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90);
        if (phisic)
        {
            speed = speed + new Vector3(0, -0.001f, 0);
        }
        return lifeTime > 0f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish" || collision.gameObject.tag == "Dirt")
        {
            //explos.gameObject.SetActive(true);
            lifeTime = 0f;
            var exp = Instantiate(explos, this.transform.position, Quaternion.Euler(0f, 0f, 0f));
            var p = Instantiate(explosion, this.transform.position, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
            p.GetComponent<ParticleSystem>().Play();
            Destroy(p, p.GetComponent<ParticleSystem>().main.duration);
            //Destroy(exp);
            //explos.gameObject.SetActive(false);
            //speed = new Vector3(speed.x, -speed.y, 0);
        }
        if (collision.gameObject.tag == "Player")
        {
            if(ExplosionTimer <= 0f)
            {
                lifeTime = 0f;
                var exp = Instantiate(explos, this.transform.position, Quaternion.Euler(0f, 0f, 0f));
                var p = Instantiate(explosion, this.transform.position, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
                p.GetComponent<ParticleSystem>().Play();
                Destroy(p, p.GetComponent<ParticleSystem>().main.duration);
            }
        }
    }
}