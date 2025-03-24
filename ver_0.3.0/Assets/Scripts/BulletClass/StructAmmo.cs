using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AmmoType
{
    public string Name; // Название снаряда
    public GameObject ProjectilePrefab; // Префаб снаряда
    public float ReloadTime; // Время перезарядки
    public int MaxAmmo; // Максимальное количество
}