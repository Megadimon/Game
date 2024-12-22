using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Shape : MonoBehaviour
{
    public float lifeTime;
    public Vector3 speed;
    public bool phisic;
    public GameObject explos;
    public GameObject explosion;
    public float gravity;
    float ExplosionTimer = 0.1f;
    public float explosionRadius = 2f; // Радиус взрыва
    private Tilemap tilemap; // Ссылка на Tilemap


    Vector3 diff;
    Vector3 LastPos;
    // Для выстрела в сторону мыши
    // https://bunkerbook.ru/unity-lessons/kak-sdelat-strelbu-v-unity-2d/

    public void Start()
    {
        tilemap = FindAnyObjectByType<Tilemap>();
    }
    public bool Move()
    {
        transform.position += speed;
        lifeTime -= Time.deltaTime;
        ExplosionTimer -= Time.deltaTime;
        diff = this.transform.position - LastPos;
        LastPos = this.transform.position;
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90);
        if (phisic)
        {
            speed = speed + new Vector3(0, -0.001f, 0);
        }
        return lifeTime > 0f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish") || collision.gameObject.CompareTag("Dirt"))
        {
            lifeTime = 0f;
            // Создаем эффект взрыва
            var p = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;
            p.GetComponent<ParticleSystem>().Play();

            // Удаляем тайлы в радиусе взрыва
            RemoveTilesInRadius(transform.position, explosionRadius);
            Destroy(p, p.GetComponent<ParticleSystem>().main.duration);
        }
        if (collision.gameObject.tag == "Player")
        {
            if (ExplosionTimer <= 0f)
            {
                lifeTime = 0f;
                var exp = Instantiate(explos, this.transform.position, Quaternion.Euler(0f, 0f, 0f));
                var p = Instantiate(explosion, this.transform.position, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
                p.GetComponent<ParticleSystem>().Play();
                Destroy(p, p.GetComponent<ParticleSystem>().main.duration);
            }
        }
    }
    private void RemoveTilesInRadius(Vector3 explosionPosition, float radius)
    {
        // Преобразуем координаты мира в координаты Tilemap
        Vector3Int centerCell = tilemap.WorldToCell(explosionPosition);

        // Определяем радиус в тайлах
        int radiusInTiles = Mathf.CeilToInt(radius);

        // Проходим по области в радиусе окружности
        for (int x = -radiusInTiles; x <= radiusInTiles; x++)
        {
            for (int y = -radiusInTiles; y <= radiusInTiles; y++)
            {
                // Проверяем, находится ли клетка внутри окружности
                if (x * x + y * y <= radiusInTiles * radiusInTiles)
                {
                    Vector3Int cellPosition = new Vector3Int(centerCell.x + x, centerCell.y + y, 0);
                    if (tilemap.GetTile(cellPosition) != null)
                    {
                        tilemap.SetTile(cellPosition, null); // Удаляем тайл
                    }
                }
            }
        }

        // Обновляем Tilemap
        tilemap.RefreshAllTiles();
    }
}