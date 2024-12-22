using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGenerator : MonoBehaviour
{
    [Header("Tilemap Settings")]
    public Tilemap tilemap;
    public TileBase groundTile;

    [Header("Terrain Settings")]
    public float range = 5f; // �������� ������ �����
    public float noiseScale = 0.2f; // ������� ����
    private float noiseOffset; // �������� ��� ����
    void Start()
    {
        // ��������� ���������� ��������
        noiseOffset = Random.Range(0f, 1000f);
        // ��������� �����
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        for (int x = -160; x < 160; x ++)
        {
            // ��������� ������ ����� � �������������� Perlin Noise
            int terrainHeight = Mathf.RoundToInt((2 * Mathf.PerlinNoise(x * noiseScale + noiseOffset, 0) - 1) * range / 2);

            // ��������� ����� ����� ���� ������
            for (int y = -96; y <= terrainHeight; y++)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), groundTile);
            }
        }
    }
}
