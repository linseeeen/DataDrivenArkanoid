using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Brick", menuName = "Arkanoid/Brick", order = 1)]
public class Brick : ScriptableObject
{
    public string Prefabname;
    public Sprite PrefabSprite;
    public int Health;
    public int Points;
    public bool Destructable;
    

}
