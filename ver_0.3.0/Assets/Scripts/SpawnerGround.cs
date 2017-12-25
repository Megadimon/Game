using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGround : MonoBehaviour
{

    public Transform[] spawnPoints;  // Array of spawn points to be used.
    public GameObject[] enemyPrefabs; // Array of different Enemies that are used.
    public int amountEnemies;  // Total number of enemies to spawn.
    private int i;

    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        Spawn();
    }

    public void Spawn()
    {

        int k = 1;
        for (i = 0; i < amountEnemies; i++) // How many enemies to instantiate total.
        {

            GameObject obj = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]; // Randomize the different enemies to instantiate.

            //Instantiate(obj, new Vector3((-9.5f + 0.14f * i)%9.535f, -3.5f + k * 0.07f, 0), Quaternion.Euler(0f, 0f, 0f));
            Instantiate(obj, new Vector3((0.14f * (i % 138)) - 9.6f, -3.5f + k * 0.07f, 0), Quaternion.Euler(0f, 0f, 0f));
            if (i % 138 == 0 && i != 0)
                k = k + 2;

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