using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
[CreateAssetMenu(fileName = "New Brick", menuName = "Arkanoid/Brick", order = 1)]
public class Brick : ScriptableObject
{
    public string Prefabname = "New Brick";
    public Sprite PrefabSprite;
    public int Health = 1;
    public int Points = 1;
    public bool Destructable = true;
    public Brick NextBrick;
    public List<GameObject> PossiblePowerUps = new List<GameObject>();
    [Range(0,1)]
    public float PowerUpSpawnPossibility;


    private void Awake()
    {
        if (PrefabSprite == null)
        {
            Debug.LogWarning("Missing sprite in " + Prefabname, this);
        }

        
    }

    private void OnEnable()
    {
        foreach (GameObject g in PossiblePowerUps)
        {
            if (!g.CompareTag("Capsule"))
            {
                PossiblePowerUps.Remove(g);
                Debug.LogWarning(g + "Is not a powerUp caspsule, removing.");
            }
        }
    }
}
