using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Ball", menuName = "Arkanoid/Capsule", order = 3)]
public class CapsuleScriptObj : ScriptableObject
{
    public Sprite PrefabSprite;
    public string Name;
    public PowerUp PowerUpType;
    public float Speed = 1;
    [Range(0,1)]
    public float SpawnPossibility;
}
