using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGround : MonoBehaviour
{
    public Transform[] spawnPoints;  // Массив точек спауна.
    public GameObject[] enemyPrefabs; // Массив разных врагов.
    public int amountEnemies;  // Общее количество врагов для спауна.
    private int i;

    public float noiseScale = 0.1f; // Масштаб шума, чтобы контролировать плотность объектов.

    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        Spawn();
    }

    public void Spawn()
    {
        float offsetX = 0f;
        float offsetY = 0f;

        for (i = 0; i < amountEnemies; i++) // Сколько врагов нужно заспаунить.
        {
            GameObject obj = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]; // Рандомизация врагов.

            // Используем Perlin Noise для плавных переходов по осям X и Y.
            offsetX = Mathf.PerlinNoise(i * noiseScale, 0f) * 20f - 10f; // Плавное изменение по X.
            offsetY = Mathf.PerlinNoise(0f, i * noiseScale) * 6f - 3f; // Плавное изменение по Y.

            // Создаем врага с плавным смещением.
            Instantiate(obj, new Vector3(offsetX, offsetY, 0), Quaternion.Euler(0f, 0f, 0f));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Explo")
        {
            Destroy(collision.gameObject);
        }
    }
}
