using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Brick", menuName = "Arkanoid/Brick", order = 1)]
public class Brick : ScriptableObject
{
    public string Prefabname = "New Brick";
    public Sprite PrefabSprite;
    public int Health = 1;
    public int Points = 1;
    public bool Destructable = true;

    private void Awake()
    {
        if (PrefabSprite == null)
        {
            Debug.LogWarning("Missing sprite", this);
        }
    }
}
