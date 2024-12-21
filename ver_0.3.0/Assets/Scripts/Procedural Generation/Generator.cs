using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Generator : MonoBehaviour
{
    public SpriteShapeController shape;
    public float Range;
    private int numOfPoints;
    private int distanceBTWPoints = 2;
    private float noiseScale = 0.2f; // Масштаб шума для регулирования плавности
    private float noiseOffset; // Случайное смещение для шума

    private void Start()
    {
        shape = GetComponent<SpriteShapeController>();

        // Генерация случайного смещения
        noiseOffset = Random.Range(0f, 1000f);

        // Установка начальных позиций
        shape.spline.SetPosition(1, new Vector2(-30, Random.Range(-Range/2, Range/2)));
        shape.spline.SetPosition(0, new Vector2(-30, -50));
        shape.spline.SetPosition(2, new Vector2(30, Random.Range(-Range/2, Range/2)));
        shape.spline.SetPosition(3, new Vector2(30, -50));

        numOfPoints = (int)(Mathf.Abs(shape.spline.GetPosition(1).x) + Mathf.Abs(shape.spline.GetPosition(2).x)) / distanceBTWPoints;

        for (int i = 0; i < numOfPoints; i++)
        {
            float xPos = shape.spline.GetPosition(1).x + i * distanceBTWPoints;

            // Используем Perlin Noise с учетом случайного смещения
            float noiseValue = (2 * Mathf.PerlinNoise(xPos * noiseScale + noiseOffset, 0) - 1) * Range / 2;
            shape.spline.InsertPointAt(i + 2, new Vector2(xPos, noiseValue));

            // Устанавливаем режимы и касательные
            shape.spline.SetTangentMode(i + 2, ShapeTangentMode.Continuous);
            shape.spline.SetLeftTangent(i + 2, new Vector2(-1, 0));
            shape.spline.SetRightTangent(i + 2, new Vector2(1, 0));
        }

        Debug.Log("worked fine!");
    }

    public void RemoveGround(Vector2 hitPoint, float radius)
    {
        // Пройдемся по всем точкам сплайна
        for (int i = 0; i < shape.spline.GetPointCount(); i++)
        {
            Vector2 pointPosition = shape.spline.GetPosition(i);
            float distance = Vector2.Distance(pointPosition, hitPoint);

            if (distance <= radius)
            {
                // Если точка находится в радиусе взрыва, перемещаем её на границу радиуса
                Vector2 direction = (pointPosition - hitPoint).normalized;
                Vector2 newPointPosition = hitPoint + direction * radius;

                // Проверяем, чтобы новая высота точки была не выше текущей
                if (newPointPosition.y > pointPosition.y)
                {
                    // Если точка выше, оставляем её на текущей высоте
                    newPointPosition.y = pointPosition.y;
                }

                // Назначаем новое положение точки
                shape.spline.SetPosition(i, newPointPosition);

                // Устанавливаем касательные для плавности
                shape.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                shape.spline.SetLeftTangent(i, -direction * 0.5f * radius);
                shape.spline.SetRightTangent(i, direction * 0.5f * radius);
            }
        }
    }



}
