using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGenerator : MonoBehaviour
{
    [Header("Tilemap Settings")]
    public Tilemap tilemap;
    public TileBase groundTile;

    [Header("Terrain Settings")]
    public float range = 5f; // Диапазон высоты земли
    public float noiseScale = 0.2f; // Масштаб шума
    private float noiseOffset; // Смещение для шума
    void Start()
    {
        // Генерация случайного смещения
        noiseOffset = Random.Range(0f, 1000f);
        // Генерация земли
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        for (int x = -160; x < 160; x ++)
        {
            // Вычисляем высоту точки с использованием Perlin Noise
            int terrainHeight = Mathf.RoundToInt((2 * Mathf.PerlinNoise(x * noiseScale + noiseOffset, 0) - 1) * range / 2);

            // Заполняем тайлы земли ниже уровня
            for (int y = -96; y <= terrainHeight; y++)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), groundTile);
            }
        }
    }
}
